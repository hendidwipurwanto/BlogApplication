using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BlogPostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
