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
        public IActionResult PageEditor(int pageId, PageEnums.PageType pageType, int directoryId = 0)
        {
            PageEditModel editModel = null;
            switch (pageType)
            {
                case PageEnums.PageType.Directory:
                    editModel = pageId != 0 ? _servicesManager.Directorys.GetDirectoryEdetModel(pageId)
                        : _servicesManager.Directorys.CreateNewDirectoryEditModel();
                    break;
                case PageEnums.PageType.Material:
                    editModel = pageId != 0 ? _servicesManager.Materials.GetMaterialEditModel(pageId)
                        : _servicesManager.Materials.CreateNewMaterialEditModel(directoryId);
                    break;
            }
            ViewBag.PageType = pageType;
            return View(editModel);
        }

        [HttpPost]
        public IActionResult SaveDirectory(DirectoryEditModel model)
        {
            _servicesManager.Directorys.SaveDirectoryEditModelToDb(model);
            return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageEnums.PageType.Directory });
        }

        [HttpPost]
        public IActionResult SaveMaterial(MaterialEditModel model)
        {
            _servicesManager.Materials.SaveMaterialEditModelToDb(model);
            return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageEnums.PageType.Material });
        }

    }
}