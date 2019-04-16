                             using MVC1_BookWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace MVC1_BookWorld.ViewModel
{
    public class RandomBookViewModel      //relation of one book many customers
    {
        public Book Book { get; set; }
        public List<Customer> Customers { get; set; }
    }
};