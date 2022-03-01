using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newproj.Models
{
    public class Profession
    {
        [Key]
        public int ProfId { get; set; }
        [Required]
        public string ProfessionName { get; set; }
        public virtual ICollection<Booking> Bookings
        {
            get;
            set;
        }
    }
}
