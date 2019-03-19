using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interfaces;

namespace BusinessLayer
{
    public class DataManager
    {
        public DataManager(IDirectoriesRepository directorysRepository, IMaterialsRepository materialsRepository)
        {
            Directorys = directorysRepository;
            Materials = materialsRepository;
        }
        public IDirectoriesRepository Directorys { get; }
        public IMaterialsRepository Materials { get; }
    }
}
