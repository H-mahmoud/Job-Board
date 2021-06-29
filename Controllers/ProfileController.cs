using Job_Board.Models;
using Job_Board.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Board.Controllers
{
    [Authorize(Roles = "Recruiter,Developer")]
    public class ProfileController : Controller
    {
        #region Properties
        public UserManager<UserModel> ManageUser { get; }
        private readonly IHostingEnvironment Environment;
        #endregion

        // Constructor
        public ProfileController(UserManager<UserModel> manageUser, IHostingEnvironment _hosting)
        {
            ManageUser = manageUser;
            Environment = _hosting;
        }

        #region Methods
        // GET: Profile
        // GET: Profile/Index
        public async Task<IActionResult> Index()
        {
            UserModel user = await ManageUser.GetUserAsync(User);
            return View(user);
        }

        // GET: Profile/Settings
        public async Task<IActionResult> Settings()
        {
            ViewBag.User = await ManageUser.GetUserAsync(User);
            return View();
        }

        // POST: Profile/Settings
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Settings(SettingsViewModel model)
        {
            if (ModelState.IsValid) {
                UserModel user = await ManageUser.GetUserAsync(User);
                if (model.ProfilePicture != null)
                    user.ProfilePicture = UploadImage(model.ProfilePicture, user.ProfilePicture);

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.JobTitle = model.JobTitle;
                user.LinkedInUrl = model.LinkInUrl;

                var result = await ManageUser.UpdateAsync(user);
                if (result.Succeeded) {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        private string UploadImage(IFormFile profilePicture, string currentPicture)
        {
            string DefaultPath = "/img/Profile/Default.jpg";
            /*
            if (DefaultPath != currentPicture) {
                System.IO.File.Delete(currentPicture);
            }*/
            string FileName = Guid.NewGuid().ToString() + ".jpg";
            string uploadsFolder = Path.Combine(this.Environment.WebRootPath, "img/Profile");
            string filePath = Path.Combine(uploadsFolder, FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                profilePicture.CopyTo(fileStream);
            }

            return "/img/Profile/"+FileName;
        }
        #endregion
    }
}
