using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataLayer.Entities;

namespace PresentationLayer.Models
{
    public class MaterialViewModel : PageViewModel
    {
        public Material Material { get; set; }
        //unnecessery
        public Material NextMaterial { get; set; }
    }
    public class MaterialEditModel : PageEditModel
    {
        [Required]
        public int DirectoryId { get; set; }
    }
}
