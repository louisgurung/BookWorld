
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC1_BookWorld.Models;

namespace MVC1_BookWorld.Models
{
    public class Genre
    {  
        public byte Id { get; set; }

        [Display(Name = "Genre Types")]
        public String Name { get; set; }
    }
}