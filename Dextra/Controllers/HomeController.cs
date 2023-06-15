using Dextra.Data;
using Dextra.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Dextra.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context) 
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Get all companies
            var companies = _context.Companies.ToList();
            // List of all locations based on what company is selected

            var locations = new List<Location>();

            // Pass the list to the view (in a dropdown)
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");
            ViewBag.Locations = new SelectList(locations, "Id", "Name", "Map");

            Location location = new Location
            {
                Id = 1,
                Name = "SP8 4TD",
                Map = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d40164.26416753962!2d-2.2885281225675977!3d51.01122508277614!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x487235299774c363%3A0xe1624a31bb5d9d67!2sDextra%20Group!5e0!3m2!1sen!2suk!4v1686817313468!5m2!1sen!2suk"
            };

            ViewBag.Location = location;
            
            return View();
        }

        // Map
      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Populate Location list base on company selected <script>
        public JsonResult GetLocationByCompanyId(int companyId)
        {
            return Json(_context.Locations.Where(u => u.CompanyId == companyId).ToList());
        }

        // Map

    }
}