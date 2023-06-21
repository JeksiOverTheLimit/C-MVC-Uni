using Microsoft.AspNetCore.Mvc;

namespace MvcProject.Controllers
{
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
