using AutoMapper;
using Job_Board.Core;
using Job_Board.Models;
using Job_Board.Models.enums;
using Job_Board.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Job_Board.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        #region Properties
        public JobBoardContext _context { get; }
        public UserManager<UserModel> _usermanager { get; }
        public Paginator _paginator { get; }
        public IMapper _mapper { get; }

        public int PageSize { get; set; }
        #endregion

        // Constructor
        public AdminController(JobBoardContext Context, UserManager<UserModel> usermanager,
                            Paginator paginator, IMapper mapper)
        {
            _context = Context;
            _usermanager = usermanager;
            _paginator = paginator;
            _mapper = mapper;

            PageSize = 5;
        }

        #region Mehtods
        // GET: Admin
        public IActionResult Index()
        {
            // to show old posts with null value
            DashboardViewModel dashboard = new DashboardViewModel
                                            {
                                                TotalPosts = _context.jobs.Count(),
                                                TotalPending = _context.jobs.Where(x => x.IsAccepted == false).Count(),
                                                TotalUsers = _context.Useres.Count(),
                                                RecentPosts = _context.jobs.Where(x => x.IsAccepted != false).OrderByDescending(o => o.PublishedAt).Take(3)
                                                                .Include(x => x.Recruter)
                                                                .Include(x => x.Category)
            };

            return View(dashboard);
        }

        // GET: Admin/PendingPosts
        public IActionResult PendingPosts()
        {
            var jobs = _context.jobs.Where(x => x.IsAccepted == false)
                .Include(x => x.Recruter)
                .Include(x => x.Category)
                .ToList();

            return View(jobs);
        }

        // GET: Admin/Categories
        public IActionResult Categories()
        {
            IEnumerable<PopolarCategoriesViewModel> Categories = _context.Categories
                                .Select(s => new PopolarCategoriesViewModel
                                {
                                    Name = s.Name,
                                    Count = s.jobs.Count()
                                })
                                .ToList();
            return View(Categories.Reverse());
        }
        #endregion
    }
}
