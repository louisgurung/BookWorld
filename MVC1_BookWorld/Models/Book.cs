using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1_BookWorld.Models
{
    public class Book
    {
        public byte ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string DateAdded { get; set; }
        public int NumberInStock { get; set; }
        //movies/random
    }
}