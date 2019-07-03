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

        [Required(ErrorMessage = "Please enter the books name!")]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        //byte? --optional     byte--implicitly required
        [Display(Name="GeNre")]
        public byte GenreId { get; set; }

        [Display(Name="Release Date")]
        public string DateAdded { get; set; }

        [Display(Name="Number Available")]
        [NoOfBooksRange]
        [Range(1,20)]
        public int NumberInStock { get; set; }
        //movies/random

        
        public byte NumberAvailable { get; set; }
    }
}



//Data annotation  
//[Range(1,10)]
//[Compare("Other Property")]
//[Phone]
//[EmailAddress]
//[Url]
//[RegularExpression("...")]