using AutoMapper;
using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.Controllers
{

    public class BlogAdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public BlogAdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager, IMapper mapper)
        {

            this.signInManager = signInManager;
            this.userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
           
            if (userEmail != null)
            {
                // Lakukan sesuatu dengan email
                ViewBag.UserEmail = userEmail;
            }

            
          
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult LoginFailed()
        {
            ViewBag.failed = "Invalid username or password.";
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, viewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(viewModel.UserName);
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles.Count > 0)
                    {
                       // return Content("suceeed login!");
                        return RedirectToAction("index", "BlogAdmin");
                    }
                    else
                    {

                        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                        return View(viewModel);

                        return RedirectToAction("LoginFailed", "BlogAdmin");
                    }
                }
                
            }
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View(viewModel);
            // return RedirectToAction("LoginFailed", "BlogAdmin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel viewModel)
        {
           // var viewModel = new RegisterViewModel() { FullName = "Blog Admin", Email = "admin@mail2.com", FullAddress = "jambangan", Password = "Adm!n123456", ConfirmPassword = "Adm!n123456", isCreator = true, PhoneNumber = "123456" };

            var defaultRole = new IdentityRole() { Name = "Creator", };
            await _roleManager.CreateAsync(defaultRole);
            var user = new IdentityUser { UserName = viewModel.Email, Email = viewModel.Email, EmailConfirmed = true };
            string guId = user.Id.ToString();
            viewModel.Id = new Guid(guId);
            //var userDetailViewModel = new UserDetailViewModel() { Email = viewModel.Email, FullAddress = viewModel.FullAddress, FullName = viewModel.FullName, PhoneNumber = viewModel.PhoneNumber };

            var result = await userManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "BlogAdmin");
            }
            return Content("registered!");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login", "BlogAdmin");
        }
    }
}
