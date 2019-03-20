using MVC1_BookWorld.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

    public class Customer
    {
        public int ID { get; set; }

        [Required]             //makes name non nullable..using dataannotations...override
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name ="Date of Birth")]     //changing the display name from model's name (Data annotation)
        public string BirthDate { get; set; }

        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
