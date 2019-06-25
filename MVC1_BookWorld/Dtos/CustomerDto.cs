using MVC1_BookWorld.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC1_BookWorld.Dtos
{
    public class CustomerDto
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        //implement validation for this
        [Display(Name = "Date of Birth")]     //changing the display name from model's name (Data annotation)
        public String BirthDate { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

      
        public byte MembershipTypeId { get; set; }




    }
}