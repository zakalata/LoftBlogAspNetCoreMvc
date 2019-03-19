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
    public class EFDirectoriesRepository : IDirectoriesRepository
    {
        private EFDBContext context;
        public EFDirectoriesRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Directory> GetAllDirectorys(bool includeMaterials = false)
        {
            return includeMaterials ? context.Set<Directory>().Include(x => x.Materials).AsNoTracking().ToList() : context.Directories.ToList();
        }

        public Directory GetDirectoryById(int directoryId, bool includeMaterials = false)
        {
            return includeMaterials ? context.Set<Directory>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directoryId) : context.Directories.FirstOrDefault(x => x.Id == directoryId);
        }

        public void SaveDirectory(Directory directory)
        {
            if (directory.Id == 0)
                context.Directories.Add(directory);
            else
                context.Entry(directory).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteDirectory(Directory directory)
        {
            context.Directories.Remove(directory);
            context.SaveChanges();
        }
    }
}
