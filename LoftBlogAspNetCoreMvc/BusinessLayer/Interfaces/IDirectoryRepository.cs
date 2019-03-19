using System.Collections.Generic;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IDirectoriesRepository
    {
        IEnumerable<Directory> GetAllDirectorys(bool includeMaterials = false);
        Directory GetDirectoryById(int directoryId, bool includeMaterials = false);
        void SaveDirectory(Directory achieve);
        void DeleteDirectory(Directory achieve);
    }
}