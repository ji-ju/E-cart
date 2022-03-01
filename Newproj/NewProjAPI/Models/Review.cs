using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewProjAPI.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "Please Enter Username..")]
        [Display(Name = "UserName")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "Please Enter Username..")]
        [Display(Name = "Service")]
        public string Service { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please Enter Username..")]
        [Display(Name = "Your Review")]
        public string Description { get; set; }
    }
}
