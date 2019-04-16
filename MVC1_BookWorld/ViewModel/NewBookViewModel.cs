using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC1_BookWorld.Models;

namespace MVC1_BookWorld.ViewModel
{
    public class NewBookViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public Book Book { get; set; } //can write book fields also
    }
}