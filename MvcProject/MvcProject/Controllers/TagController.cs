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
        public IActionResult Index()
        {
            var allTags = this._tagService.GetAllTag();
            return View(allTags);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TagModel model)
        {
            _tagService.Create(model);
            return RedirectToAction("Index");
        }

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

        [HttpPost]
        public IActionResult Update(TagModel model)
        {

            _tagService.Update(model);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            this._tagService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

