using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Newproj.Models
{
    public class Assistant
    {
        [Key]
        public int AssistId { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "Please Enter Username..")]
        [Display(Name = "UserName")]
        public string Username { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "Please Enter Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Pwd { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "Please Enter the Confirm Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Pwd")]
        public string Confirmpassword { get; set; }


        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "Please Enter Email...")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [ForeignKey("City")]
        [DisplayName("City")]
        public int CityId { get; set; }

        [ForeignKey("Profession")]
        public int ProfId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Enter the address...")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Enter the Phone Number...")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]        
        public IFormFile ImageFile { get; set; }
        public virtual City City { get; set; }
        public virtual Profession Profession { get; set; }


    }
}
