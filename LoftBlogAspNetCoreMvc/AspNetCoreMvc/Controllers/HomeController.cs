using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMvc.Models;
using BusinessLayer;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PresentationLayer;
using PresentationLayer.Models;

namespace AspNetCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        //private EFDBContext context;
        //private IDirectoriesRepository dirRep;
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;
        public HomeController(/*EFDBContext context, IDirectoriesRepository dirRep,*/ DataManager dm)
        {
            //this.context = context;
            //this.dirRep = dirRep;
            this._datamanager = dm;
            _servicesmanager = new ServicesManager(_datamanager);
        }

        public IActionResult Index()
        {
            //HelloModel m = new HelloModel() { HelloMessage = "Hello, Alex!" };
            //List<Directory> dirs = context.Directories.Include(x => x.Materials).ToList();
            //List<Directory> dirs = dirRep.GetAllDirectorys().ToList();
            //List<Directory> dirs = dataManager.Directorys.GetAllDirectorys(true).ToList();
            List<DirectoryViewModel> _dirs = _servicesmanager.Directorys.GetDirectoryesList();
            return View(_dirs);
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
