using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC1_BookWorld.Models;

namespace MVC1_BookWorld.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //Enumerable gives loosely coupled functionality
        public Customer Customer { get; set; } //can also write Customer fields In larger applications sometimes this may pollute the entity
    }
}