using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
	public class DetailsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
