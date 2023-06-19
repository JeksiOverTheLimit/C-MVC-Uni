using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;
using MvcProject.Services.BlogPosts;
using MvcProject.Services.Category;
using System.Diagnostics;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogPostService _blogPostService;
    

        public HomeController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
            
        }

        public IActionResult Index()
        {
            
            var allPost = this._blogPostService.FindAllPosts();
            return View(allPost);
        }

    }
}