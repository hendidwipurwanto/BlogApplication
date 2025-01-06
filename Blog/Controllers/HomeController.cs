using Blog.Entities;
using Blog.Models;
using Blog.Repositories;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<TestEntity> _genericRepository;
        private readonly IInitializedScrutorService _initializedScrutorService;
        public HomeController(ILogger<HomeController> logger, IGenericRepository<TestEntity> genericRepository,IInitializedScrutorService initializedScrutorService)
        {
            _logger = logger;
            _genericRepository = genericRepository;
            _initializedScrutorService= initializedScrutorService;
        }

        public async Task<IActionResult> Index()
        {
            var temp = await _genericRepository.GetAllAsync();
            var temp2= _initializedScrutorService.GetScrutorName();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
