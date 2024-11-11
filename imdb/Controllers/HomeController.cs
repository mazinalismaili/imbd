using imdb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace imdb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ImdbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityUser> _roleManager;
        public HomeController(ILogger<HomeController> logger, ImdbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityUser> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles ="Admin")]
        public IActionResult Privacy()
        {
            var user = _userManager.FindByNameAsync(User.Identity?.Name);
            string useremail = User.Identity?.Name;
            var employee = _context.Staff.Where(u => u.Email == useremail).FirstOrDefault();
            if (employee != null) { Console.WriteLine(employee.StaffId + " " + employee.FirstName); }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
