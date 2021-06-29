using AutoMapper;
using Job_Board.Core;
using Job_Board.Models;
using Job_Board.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;
using Newtonsoft.Json.Linq;

namespace Job_Board.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        #region Properties
        public SignInManager<UserModel> SignManager { get; }
        public UserManager<UserModel> ManageUser { get; }
        public RoleManager<IdentityRole> ManageRole { get; }
        public List<IdentityRole> Roles { get; set; }
        public IMapper _mapper { get; }
        private readonly MailSettings _mailSettings;

        #endregion

        // Constructor
        public AccountController(SignInManager<UserModel> signManager, UserManager<UserModel> manageUser, 
            RoleManager<IdentityRole> manageRole, IMapper mapper, IOptions<MailSettings> mailsetting)
        {
            SignManager = signManager;
            ManageUser = manageUser;
            ManageRole = manageRole;

            Roles = ManageRole.Roles.ToList();
            _mapper = mapper;
            _mailSettings = mailsetting.Value;
        }

        #region Methods

        // GET: Account/Login
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Profile");
            return View();
        }

        // POST: Account/Login
        // POST: Account/Login?returnUrl=url
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string returnUrl, LoginViewModel model)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Profile");

            if (ModelState.IsValid)
            {
                UserModel user = await ManageUser.FindByEmailAsync(model.Email);
                if (user != null && await ManageUser.CheckPasswordAsync(user, model.Password))
                {
                    
                    if (await ManageUser.IsEmailConfirmedAsync(user))
                    {
                        var result = await SignManager.PasswordSignInAsync(user, model.Password, true, false);

                        if (result.Succeeded)
                        {
                            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                            {
                                return LocalRedirect(returnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Error", result.ToString());
                        }
                    }
                    else {
                        ModelState.AddModelError("Error", "Email is not verified.");
                    }

                }
                else
                {
                    ModelState.AddModelError("Error", "Failed : Invalid Login Attempt");
                }
            }
            
            return View(model);
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Profile");
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Profile");

            IdentityRole role = Roles.FirstOrDefault(r => r.Name == model.Role);

            if (ModelState.IsValid && role != null)
            {
                model.Username = model.Email.ToLower().Split("@")[0];
                UserModel user = _mapper.Map<UserModel>(model);
                var result = await ManageUser.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await ManageUser.AddToRoleAsync(user, role.Name);
                    var token = await ManageUser.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { token = token, email = user.Email });

                    var url = "https://" + Request.Host + callbackUrl;
                    MailRequest mailrequest = new MailRequest {
                        ToEmail = model.Email,
                        Subject = "Email Verification Token",
                        Body = "<div style='text-align:center'> <h1 style='margin:20px;'> Thanks for signing up, " + model.FirstName + " </h1> <a href='" + url + "' > Verify Email </a> </div>"
                    };

                    var confirm = await SendToken(mailrequest);
                    if (!confirm) {
                        // Failed to send verification token
                        await ConfirmEmail(token, model.Email);
                    }

                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
            }

            return View(model);
        }


        // GET: Account/ConfirmEmail?token=value&email=value
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Profile");

            UserModel user = await ManageUser.FindByEmailAsync(email);
            if (user != null && !await ManageUser.IsEmailConfirmedAsync(user)) {

                var result = await ManageUser.ConfirmEmailAsync(user, token);
                if (result.Succeeded) {

                    return RedirectToAction("Login");
                }
            }
            
            return View("Verify");
        }

        // GET: Account/ForgetPassword
        public IActionResult ForgetPassword()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Profile");

            return View();
        }

        // POST: Account/ForgetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Profile");

            UserModel user = await ManageUser.FindByEmailAsync(model.Email);
            ViewBag.Sent = false;
            if (user != null)
            {
                var token = await ManageUser.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { token = token, email = user.Email });
                var url = "https://" + Request.Host + callbackUrl;

                MailRequest mailrequest = new MailRequest
                {
                    ToEmail = model.Email,
                    Subject = "Password Reset Token",
                    Body = "<div style='text-align:center'> <h1 style='margin:20px;'> Reset Your Password. </h1> <a href='" + url + "' > Reset Password </a> </div>"
                };

                var result = await SendToken(mailrequest);
                if(result)
                    ViewBag.Sent = true;
            }

            return View();
        }

        // GET: Account/ResetPassword?token=value&email=value
        public IActionResult ResetPassword(string token, string email)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Profile");

            ViewBag.token = token;
            ViewBag.email = email;
            return View();
        }

        // POST: Account/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Profile");

            UserModel user = await ManageUser.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var passwordValidator = new PasswordValidator<UserModel>();
                var result = await passwordValidator.ValidateAsync(ManageUser, null, model.Password);

                if (result.Succeeded)
                {

                    result = await ManageUser.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }

                    ViewBag.token = model.Token;
                    ViewBag.email = model.Email;

                    return View("ResetPassword");
                }

            }

            return View("Verify");
        }

        // GET: Account/Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await SignManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<bool> SendToken(MailRequest mailRequest)
        {
            try
            {
                MailjetClient client = new MailjetClient(
                    _mailSettings.MJ_APIKEY_PUBLIC,
                    _mailSettings.MJ_APIKEY_PRIVATE);

                MailjetRequest request = new MailjetRequest
                {
                    Resource = Send.Resource,
                };

                var email = new TransactionalEmailBuilder()
                    .WithFrom(new SendContact(_mailSettings.Mail))
                    .WithSubject(mailRequest.Subject)
                    .WithHtmlPart(mailRequest.Body)
                    .WithTo(new SendContact(mailRequest.ToEmail))
                    .Build();

                var response = await client.SendTransactionalEmailAsync(email);
                Console.WriteLine(response);
                if (response.Messages.Length != 1)
                    throw new Exception();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);

                return false;
            }

            return true;
        }

        #endregion
    }
}
