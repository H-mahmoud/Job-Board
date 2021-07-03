using Job_Board.Models;
using Job_Board.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Job_Board.Controllers.Api
{
    [ApiController]
    [Route("Api/[controller]/")]
    public class JobController : ControllerBase
    {

        #region Properties
        public JobBoardContext _context { get; }
        public UserManager<UserModel> _usermanager { get; }

        #endregion

        // Constructor
        public JobController(JobBoardContext Context, UserManager<UserModel> usermanager)
        {
            _context = Context;
            _usermanager = usermanager;
        }

        // GET: Api/JobController?pageNumber=1
        [HttpGet]
        public ActionResult<IEnumerable<AllJobsViewModel>> Get(int pageNumber)
        {
            
            if (pageNumber < 1)
                pageNumber = 1;
            int take = 5;
            int skip = (pageNumber-1) * take;
            IEnumerable<AllJobsViewModel> Jobs = _context.jobs.OrderByDescending(z => z.PublishedAt)
                                                                .Select(s => new AllJobsViewModel { 
                                                                    Id = s.Id,
                                                                    Title = s.Title,
                                                                    Location = s.Location,
                                                                    JobNature = (s.JobNature == Models.enums.JobNature.FullTime ? "Full TIme" : "Part TIme"),
                                                                    Category = (s.Category != null ? s.Category.Name : null),
                                                                    PublishedAt = s.PublishedAt,
                                                                    PublisherImage = HttpContext.Request.Host.ToString() + s.Recruter.ProfilePicture
                                                                })
                                                                .Skip(skip).Take(take)
                                                                .ToList();
            return Ok(Jobs);
        }

        // GET: Api/JobController/Details/Id
        [HttpGet("{id}")]
        public ActionResult<JobDetailsViewModel> Get(string id)
        {

            JobDetailsViewModel Job = _context.jobs.Where(x => x.Id == id)
                                                                .Select(s => new JobDetailsViewModel
                                                                {
                                                                    Id = s.Id,
                                                                    Title = s.Title,
                                                                    Location = s.Location,
                                                                    JobNature = (s.JobNature == Models.enums.JobNature.FullTime ? "Full TIme" : "Part TIme"),
                                                                    Category = (s.Category != null ? s.Category.Name : null),
                                                                    PublishedAt = s.PublishedAt,
                                                                    PublisherImage = HttpContext.Request.Host.ToString() + s.Recruter.ProfilePicture,
                                                                    Description = s.Description,
                                                                    Salary = s.Salary,
                                                                    Vacancy = s.Vacancy
                                                                }).FirstOrDefault();
            if (Job == null)
                return NotFound();
            return Ok(Job);
        }

        // DELETE: Api/JobController/ConfirmDelete/JobId
        [HttpDelete("Delete/{Id}")]
        [Authorize(Roles = "Recruiter,Admin")]
        [ValidateAntiForgeryToken]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult Delete(string id)
        {
            try 
            {
                if (User.IsInRole("Admin")) {
                    var job = _context.jobs.Where(x => x.Id == id)
                                            .FirstOrDefault();
                    _context.jobs.Remove(job);
                }
                else {
                    string UserId = _usermanager.GetUserId(User);
                    var job = _context.jobs.Where(x => x.RecruterId == UserId && x.Id == id)
                                            .FirstOrDefault();
                    _context.jobs.Remove(job);
                }

                _context.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest();
            }

            return Ok();
        }

        // Get: Api/JobController/ConfirmDelete/JobId
        [HttpPut("Accept/{Id}")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult Accept(string id)
        {
            try
            {
                var job = _context.jobs.Where(x => x.Id == id)
                                            .FirstOrDefault();
                job.IsAccepted = true;

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: Api/JobController/Apply
        [HttpPost]
        [Route("Apply")]
        [Authorize(Roles = "Developer")]
        [ValidateAntiForgeryToken]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult Apply([FromForm] ApplyViewModel model)
        {
            try {
                string UserId = _usermanager.GetUserId(User);
                JobModel job = _context.jobs.Where(x => x.Id == model.JobId).FirstOrDefault();

                UserJob user = new UserJob { UserId = UserId, JobId = job.Id };
                _context.Candidates.Add(user);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            

            return Ok();
        }
    }
}
