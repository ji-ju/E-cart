using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newproj.Models
{
    public class ReviewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Username..")]
        [Display(Name = "UserName")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Username..")]
        [Display(Name = "Service")]
        public string Service { get; set; }
        [Required(ErrorMessage = "Please Enter Username..")]
        [Display(Name = "Your Review")]
        public string Description { get; set; }
    }
}
