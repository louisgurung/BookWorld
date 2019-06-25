using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVC1_BookWorld.Models;

namespace MVC1_BookWorld.Dtos
{
    public class BookDto
    {
        public int ID { get; set; }

       
        [StringLength(255)]
        public string Name { get; set; }

        public GenreDto Genre { get; set; }

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