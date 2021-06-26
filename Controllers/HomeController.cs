using Job_Board.Models;
using Job_Board.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Job_Board.Controllers
{
    public class HomeController : Controller
    {
        public JobBoardContext _context { get; }

        public HomeController(JobBoardContext context)
        {
            _context = context;  
        }

        public IActionResult Index()
        {
            ViewBag.TotalJobs = _context.jobs.Count();
            ViewBag.Categories = _context.Categories.ToList();

            IEnumerable<PopolarCategoriesViewModel> PopolarCategories = _context.jobs
                                .GroupBy(g => g.Category.Name)
                                .Select(s => new PopolarCategoriesViewModel
                                {
                                    Name = s.Key,
                                    Count = s.Count()
                                })
                                .ToList();
            
            return View(PopolarCategories);
        }

        public IActionResult NotFound()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
