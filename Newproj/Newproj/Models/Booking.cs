using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Newproj.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "Please Enter Username..")]
        [Display(Name = "UserName")]
        public string Username { get; set; }
     
     
        [Column(TypeName = "nvarchar(25)")]
        [Required(ErrorMessage = "Please Enter Email...")]
        [Display(Name = "Email")]
        public string Email { get; set; }
       
        [ForeignKey("City")]
        public int CityId { get; set; }
       
        [ForeignKey("Profession")]
        public int ProfId { get; set; }
     
        public string AssistantName { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Enter the address...")]
        [Display(Name = "Address")]

        public string Address { get; set; }
        [Display(Name = "Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Enter the Phone Number...")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name ="Status")]
        public string Status { get; set; }
        public virtual City City { get; set; }
        public virtual Profession Profession { get; set; }

        





    }
}
