using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMvc.Models;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private EFDBContext context;

        public HomeController(EFDBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            HelloModel m = new HelloModel() { HelloMessage = "Hello, Alex!" };
            List<Directory> dirs = context.Directories.Include(x => x.Materials).ToList();
            return View(dirs);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
