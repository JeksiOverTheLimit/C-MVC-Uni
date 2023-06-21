using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using MvcProject.Models;
using MvcProject.Services.BlogPosts;
using MvcProject.Services.Category;
using MvcProject.Services.NewFolder;
using System.Security.Claims;

namespace MvcProject.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IBlogPostService _blogPostService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        public BlogPostController(IBlogPostService blogPostService, UserManager<IdentityUser> userManager, ICategoryService categoryService, ITagService tagservice)
        {
            _blogPostService = blogPostService;
            _userManager = userManager;
            _categoryService = categoryService;
            _tagService = tagservice;
        }

        public IActionResult Index(int id)
        {
            var post = this._blogPostService.FindById(id);
            return View(post);
        }

        [Authorize]
        public IActionResult Create()
        {
            var model = new BlogCategoryViewModel()
            {
                AllCategories = this._categoryService.GetAllCategory(),
                CategoryIds = new List<int>(),
                AllTags = this._tagService.GetAllTag(),
                TagIds = new List<int>()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BlogCategoryViewModel model)
        {
            

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            this._blogPostService.Create(model, userId);

            return Redirect("/");
        }

        [Authorize]
        public IActionResult Read(BlogPostModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var allPost = this._blogPostService.FindAllPostsByUserId(model, userId);
            return View(allPost);
        }

        [HttpGet]
        public IActionResult Update()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            BlogPostModel post = this._blogPostService.FindByUserId(userId);
            return View(post);
        }

        [HttpPost]
        public IActionResult Update(BlogPostModel model)
        {
            this._blogPostService.Update(model);
            return Redirect("/BlogPost/Read");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            this._blogPostService.Delete(id);
            return RedirectToAction("Read");
        }
    }
}
