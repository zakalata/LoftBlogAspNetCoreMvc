using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementation
{
    public class EFMaterialsRepository : IMaterialsRepository
    {
        private EFDBContext context;
        public EFMaterialsRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Material> GetAllMaterials(bool includeDirectory = false)
        {
            return includeDirectory ? context.Set<Material>().Include(x => x.Directory).AsNoTracking().ToList() : context.Materials.ToList();
        }

        public Material GetMaterialById(int materialId, bool includeDirectory = false)
        {
            return includeDirectory ? context.Set<Material>().Include(x => x.Directory).AsNoTracking().FirstOrDefault(x => x.Id == materialId)
                : context.Materials.FirstOrDefault(x => x.Id == materialId);
        }

        public void SaveMaterial(Material material)
        {
            if (material.Id == 0)
                context.Materials.Add(material);
            else
                context.Entry(material).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteMaterial(Material material)
        {
            context.Materials.Remove(material);
            context.SaveChanges();
        }
    }
}
