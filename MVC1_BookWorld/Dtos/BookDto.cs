using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC1_BookWorld.Dtos
{
    public class BookDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the books name!")]
        [StringLength(255)]
        public string Name { get; set; }

        //public Genre Genre { get; set; }

        //byte? --optional     byte--implicitly required
        //[Display(Name = "GeNre")]
        public byte GenreId { get; set; }

       // [Display(Name = "Release Date")]
        public string DateAdded { get; set; }

       // [Display(Name = "Number Available")]
        //[NoOfBooksRange]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

    }
}