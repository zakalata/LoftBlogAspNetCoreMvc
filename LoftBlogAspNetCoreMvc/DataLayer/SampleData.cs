using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Entities;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Directories.Any())
            {
                context.Directories.Add(new Directory { Title = "First Directory", Html = "<b>Directory Content</b>" });
                context.Directories.Add(new Directory { Title = "Second Directory", Html = "<b>Directory Content</b>" });
                context.Directories.Add(new Directory { Title = "Third Directory", Html = "<b>Directory Content</b>" });
                context.SaveChanges();
            }
            if (!context.Materials.Any())
            {
                context.Materials.Add(new Material { Title = "First Material", Html = "<b>Material Content</b>", DirectoryId = context.Directories.First().Id });
                context.Materials.Add(new Material { Title = "Second Material", Html = "<b>Material Content</b>", DirectoryId = context.Directories.Last().Id });
                context.SaveChanges();
            }

        }

    }
}
