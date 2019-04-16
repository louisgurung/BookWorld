using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC1_BookWorld.Models;

namespace MVC1_BookWorld.Models
{
    public class Book
    {   [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name="GeNre")]
        public byte GenreId { get; set; }

        [Display(Name="Release Date")]
        public string DateAdded { get; set; }

        [Display(Name="Number Available")]
        public int NumberInStock { get; set; }
        //movies/random
    }
}