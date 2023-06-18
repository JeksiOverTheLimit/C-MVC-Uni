using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using MvcProject.Models;
using MvcProject.Services.BlogPosts;
using System.Security.Claims;

namespace MvcProject.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IBlogPostService _blogPostService;
        private readonly UserManager<IdentityUser> _userManager;

        public BlogPostController(IBlogPostService blogPostService, UserManager<IdentityUser> userManager)
        {
            _blogPostService = blogPostService;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            var post =  this._blogPostService.FindById(id);
            return View(post);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogPostModel model)
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
        

    }
}
