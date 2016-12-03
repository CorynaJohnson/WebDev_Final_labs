using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace lab_2_web_design.Models
{
    public class Yarn
    {
        [Key]
        public int YarnId { get; set; }

        [Required]
        [Display(Name = "Name of Color")]
        public string ColorName { get; set; }
        
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
        [Required]
        [Display(Name = "Skeins")]
        public double Skeins { get; set; }
        [Display(Name = "Type")]
        public string YarnType { get; set; }

        public List<User> Users { get; set; }
    }
}