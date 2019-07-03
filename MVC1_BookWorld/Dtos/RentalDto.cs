using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1_BookWorld.Dtos
{
    public class RentalDto
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public List<int> BooksIds { get; set; }
    }
}