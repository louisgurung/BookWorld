using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC1_BookWorld.Models
{
    public class Rental
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Date rented")]
        public DateTime DateRented { get; set; }

        [Display(Name="Date returned")]
        public DateTime? DateReturned { get; set; }

        public Customer Customer { get; set; }
        public byte CustomerID { get; set; }

        public Book Book { get; set; }
        public byte BookID { get; set; }
    }
}