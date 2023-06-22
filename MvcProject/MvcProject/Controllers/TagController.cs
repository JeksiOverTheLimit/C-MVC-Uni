using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;
using MvcProject.Services.Category;
using MvcProject.Services.NewFolder;

namespace MvcProject.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var allTags = this._tagService.GetAllTag();
            return View(allTags);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(TagModel model)
        {
            _tagService.Create(model);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var tag = _tagService.GetTagById(id);

            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(TagModel model)
        {

            _tagService.Update(model);
            return RedirectToAction("Index");

        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            this._tagService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

