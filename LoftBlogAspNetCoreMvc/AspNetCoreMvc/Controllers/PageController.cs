using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;

namespace AspNetCoreMvc.Controllers
{
    public class PageController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public PageController(DataManager dm)
        {
            _dataManager = dm;
            _servicesManager = new ServicesManager(_dataManager);
        }


        public IActionResult Index(int pageId, PageEnums.PageType pageType)
        {
            PageViewModel _viewModel;
            switch (pageType)
            {
                case PageEnums.PageType.Directory: _viewModel = _servicesManager.Directorys.DirectoryDBToViewModelById(pageId); break;
                case PageEnums.PageType.Material: _viewModel = _servicesManager.Materials.MaterialDBModelToView(pageId); break;
                default: _viewModel = null; break;
            }
            ViewBag.PageType = pageType;
            return View(_viewModel);
        }
        [HttpGet]
        public IActionResult PageEditor(int pageId, PageEnums.PageType pType)
        {
            PageEditModel editModel = null;
            switch (pType)
            {
                case PageEnums.PageType.Directory:
                    editModel = _servicesManager.Directorys.GetDirectoryEdetModel(pageId);
                    break;
                case PageEnums.PageType.Material:
                    editModel = _servicesManager.Materials.GetMaterialEditModel(pageId);
                    break;
            }
            ViewBag.PageType = pType;
            return View(editModel);
        }

    }
}