using AutoMapper;
using Job_Board.Core;
using Job_Board.Models;
using Job_Board.Models.enums;
using Job_Board.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Job_Board.Controllers
{
    public class JobController : Controller
    {
        #region Properties
        public JobBoardContext _context { get; }
        public UserManager<UserModel> _usermanager { get; }
        public Paginator _paginator { get; }
        public IMapper _mapper { get; }

        public int PageSize { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public List<JobNature> JobsNature { get; set; }
        #endregion

        // Constructor
        public JobController(JobBoardContext Context, UserManager<UserModel> usermanager,
                            Paginator paginator,IMapper mapper)
        {
            _context = Context;
            _usermanager = usermanager;
            _paginator = paginator;
            _mapper = mapper;

            PageSize = 5;
            Categories = _context.Categories.ToList();
            JobsNature = _context.jobs.Select(x => x.JobNature).ToList();
        }


        #region Methods
        // GET: JobController
        public ActionResult Index(int id)
        {
            if (id < 1)
                id = 1;

            int skip = (id - 1) * PageSize;
            int take = PageSize;

            // to show old posts with null value
            var pageOfResults = _context.jobs.Where(x => x.IsAccepted != false).OrderByDescending(z => z.PublishedAt).Skip(skip).Take(take).
                Include(x => x.Category).Include(y => y.Recruter).
                ToList();

            var count = _context.jobs.Count();

            ViewBag.Categories = Categories;
            ViewBag.TotalJobs = count;


            _paginator.page(count, PageSize, id);
            ViewBag.Paginator = _paginator;


            return View(pageOfResults);
        }

        // GET: JobController/Details/JobId
        public ActionResult Details(string id)
        {
            // to show details of old posts with null value
            var jobs = _context.jobs.Where(z => z.Id == id && z.IsAccepted != false)
                .Include(x => x.Category)
                .Include(t => t.Recruter)
                .FirstOrDefault();

            if (jobs == null)
                return RedirectToAction("NotFound", "Home");

            string UserId = _usermanager.GetUserId(User);
            ViewBag.IsApplied = _context.Candidates.Where(z => z.JobId == id && z.UserId == UserId).FirstOrDefault();
            return View(jobs);
        }

        // GET: JobController/Search?_search=value&_jobnature=value&_category=value
        public ActionResult Search(int id, string? _search, int _jobnature, string? _category)
        {
            if (id < 1)
                id = 1;

            int skip = (id - 1) * PageSize;
            int take = PageSize;

            JobNature JobType = (JobNature)Enum.Parse(typeof(JobNature), _jobnature.ToString());

            // to show old posts with null value
            var pageOfResults = _context.jobs
                .Where(x => x.IsAccepted != false)
                .Where(z => (_search != null && z.Title.Contains(_search)) || (_search == null))
                .Where(z => (_jobnature != 0 && z.JobNature == JobType) || (_jobnature == 0))
                .Where(z => (_category != null && z.Category.Name == _category) || (_category == null))
                .Skip(skip)
                .Take(take)
                .Include(x => x.Category)
                .Include(t => t.Recruter).ToList();

            // to show old posts with null value
            var count = _context.jobs
                .Where(x => x.IsAccepted != false)
                .Where(z => (_search != null && z.Title.Contains(_search)) || (_search == null))
                .Where(z => (_jobnature != 0 && z.JobNature == JobType) || (_jobnature == 0))
                .Where(z => (_category != null && z.Category.Name == _category) || (_category == null)).Count();

            ViewBag.SearchKey = _search;
            ViewBag.JobNature = _jobnature;
            ViewBag.Category = _category;

            ViewBag.Categories = Categories;
            ViewBag.TotalJobs = count;

            _paginator.page(count, PageSize, id);
            ViewBag.Paginator = _paginator;

            return View(pageOfResults);
        }

        // GET: JobController/Create
        [Authorize(Roles = "Recruiter")]
        public ActionResult Create()
        {
            ViewBag.Categories = Categories;

            return View();
        }

        // POST: JobController/Create
        [HttpPost]
        [Authorize(Roles = "Recruiter")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateJobViewModel model)
        {
            if (ModelState.IsValid) {

                try
                {
                    JobModel job = _mapper.Map<JobModel>(model);
                    job.Description = job.Description.Replace(System.Environment.NewLine, "<br />");
                    job.RecruterId = _usermanager.GetUserId(User);

                    _context.jobs.Add(job);
                    var result = _context.SaveChanges();
                    if (result == 1)
                        return RedirectToAction("Index");
                }
                catch {
                    ModelState.AddModelError("Error", "Unexpected Error.");
                }
                
            }

            ViewBag.Categories = Categories;

            return View(model);
        }

        // GET: JobController/Delete/JobId
        [Authorize(Roles = "Recruiter")]
        public ActionResult Delete(string id)
        {
            string UserId = _usermanager.GetUserId(User);
            var jobs = _context.jobs.Where(x => x.RecruterId == UserId && x.Id == id)
                                    .Include(x => x.Category)
                                    .Include(x => x.Recruter)
                                    .FirstOrDefault();
            if (jobs == null)
                return RedirectToAction("NotFound", "Home");

            return View(jobs);
        }


        // POST: JobController/Apply/JobId
        [HttpPost]
        [Authorize(Roles = "Developer")]
        [ValidateAntiForgeryToken]
        public ActionResult Apply(string _id)
        {
            
            string UserId = _usermanager.GetUserId(User);
            JobModel job = _context.jobs.Where(x => x.Id == _id && x.IsAccepted != false).FirstOrDefault();

            if (job == null)
                return RedirectToAction("NotFound", "Home");

            UserJob applied = _context.Candidates.Where(x => x.JobId == job.Id && x.UserId == UserId).FirstOrDefault();

            if (applied == null) {
                UserJob user = new UserJob { UserId = UserId, JobId = job.Id };
                _context.Candidates.Add(user);
                _context.SaveChanges();
            }

            return RedirectToAction("Details", new {job.Id});
        }

        // GET: JobController/MyJobs/PageId
        [Authorize(Roles = "Recruiter")]
        public  ActionResult MyJobs(int id)
        {
            if (id < 1)
                id = 1;

            int skip = (id - 1) * PageSize;
            int take = PageSize;


            string UserId = _usermanager.GetUserId(User);

            var pageOfResults = _context.jobs.Where(x => x.RecruterId == UserId).OrderByDescending(z => z.PublishedAt)
                                .Select(s => new MyJobsViewModel
                                {
                                    Id = s.Id,
                                    Title = s.Title,
                                    Category = s.Category.Name,
                                    JobNature = s.JobNature,
                                    Location = s.Location,
                                    PublishedAt = s.PublishedAt,
                                    ProfilePicture = s.Recruter.ProfilePicture,
                                    Count = _context.Candidates.Where(x => x.JobId == s.Id).Count(),
                                    IsAccepted = s.IsAccepted
                                })
                                .Skip(skip).Take(take)
                                .ToList();

            var count = _context.jobs.Where(x => x.RecruterId == UserId).Count();

            _paginator.page(count, PageSize, id);
            ViewBag.Paginator = _paginator;

            return View(pageOfResults);
        }

        // GET: JobController/AppliedJobs/PageId
        [Authorize(Roles = "Developer")]
        public ActionResult AppliedJobs(int id)
        {
            if (id < 1)
                id = 1;

            int skip = (id - 1) * PageSize;
            int take = PageSize;

            string UserId = _usermanager.GetUserId(User);
            var pageOfResults = _context.Candidates.Where(x => x.UserId == UserId)
                                    .OrderByDescending(z => z.Job.PublishedAt)
                                    .Skip(skip).Take(take)
                                    .Include(x => x.Job)
                                    .Include(x => x.Job.Category)
                                    .Include(x => x.Job.Recruter)
                                    .ToList();

            var count = _context.Candidates.Where(x => x.UserId == UserId).Count();

            _paginator.page(count, PageSize, id);
            ViewBag.Paginator = _paginator;

            return View(pageOfResults);
        }

        // GET: JobController/AppliedJobs/JobId?page=Id
        [Authorize(Roles = "Recruiter")]
        public ActionResult Candidates(string id, int page)
        {
            if (page < 1)
                page = 1;

            int skip = (page - 1) * PageSize;
            int take = PageSize;

            string UserId = _usermanager.GetUserId(User);
            ViewBag.Job = _context.jobs.Where(x => x.Id == id && x.RecruterId == UserId).FirstOrDefault();
            if (ViewBag.Job == null)
                return RedirectToAction("NotFound", "Home");

            var Candidates = _context.Candidates.Where(x => x.JobId == id)
                                    .Skip(skip)
                                    .Take(take)
                                    .Include(x => x.User)
                                    .ToList();

            var count = _context.Candidates.Where(x => x.JobId == id).Count();

            ViewBag.TotalCandidates = count;

            _paginator.page(count, PageSize, page);
            ViewBag.Paginator = _paginator;

            return View(Candidates);
        }
        #endregion
    }
}