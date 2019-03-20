using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using DataLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class MaterialService
    {
        private DataManager dataManager;
        public MaterialService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public MaterialViewModel MaterialDBModelToView(int materialId)
        {
            var _model = new MaterialViewModel
            {
                Material = dataManager.Materials.GetMaterialById(materialId),
            };
            var _dir = dataManager.Directorys.GetDirectoryById(_model.Material.DirectoryId, true);

            if (_dir.Materials.IndexOf(_dir.Materials.FirstOrDefault(x => x.Id == _model.Material.Id)) != _dir.Materials.Count - 1)
                _model.NextMaterial = _dir.Materials.ElementAt(_dir.Materials.IndexOf(_dir.Materials.FirstOrDefault(x => x.Id == _model.Material.Id)) + 1);

            return _model;
        }

        public MaterialEditModel GetMaterialEditModel(int materialId)
        {
            var _dbModel = dataManager.Materials.GetMaterialById(materialId);
            var _editModel = new MaterialEditModel()
            {
                Id = _dbModel.Id = _dbModel.Id,
                DirectoryId = _dbModel.DirectoryId,
                Title = _dbModel.Title,
                Html = _dbModel.Html
            };
            return _editModel;
        }
        public MaterialViewModel SaveMaterialEditModelToDb(MaterialEditModel editModel)
        {
            Material material;
            material = editModel.Id != 0 ? dataManager.Materials.GetMaterialById(editModel.Id) : new Material();
            material.Title = editModel.Title;
            material.Html = editModel.Html;
            material.DirectoryId = editModel.DirectoryId;
            dataManager.Materials.SaveMaterial(material);
            return MaterialDBModelToView(material.Id);
        }
        public MaterialEditModel CreateNewMaterialEditModel(int directoryId)
        {
            return new MaterialEditModel { DirectoryId = directoryId };
        }
    }
}
