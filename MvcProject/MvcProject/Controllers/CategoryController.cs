using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcProject.Data.Entities;
using MvcProject.Models;
using MvcProject.Services.Category;
using System.Security.Claims;

namespace MvcProject.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var allCategories = this._categoryService.GetAllCategory();
            return View(allCategories);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            _categoryService.Create(model);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(CategoryModel model)
        {
  
               _categoryService.Update(model);
               return RedirectToAction("Index");
            
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            this._categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
