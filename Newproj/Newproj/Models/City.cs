using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newproj.Models
{
    public class City
    {
       
        [Key]
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }
        public virtual ICollection<Booking> Bookings
        {
            get;
            set;
        }
    }
}
