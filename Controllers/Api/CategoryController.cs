using Job_Board.Models;
using Job_Board.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Board.Controllers.Api
{
    [ApiController]
    [Route("Api/[controller]/")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        #region Properties
        public JobBoardContext _context { get; }
        public UserManager<UserModel> _usermanager { get; }

        #endregion

        // Constructor
        public CategoryController(JobBoardContext Context, UserManager<UserModel> usermanager)
        {
            _context = Context;
            _usermanager = usermanager;
        }

        // POST: API/controller
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Post([FromForm] AddCategoryViewModel model)
        {
            try
            {
                if (model.Name == null)
                    throw new Exception();

                CategoryModel category = new CategoryModel { Id = Guid.NewGuid().ToString(), Name = model.Name };
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
