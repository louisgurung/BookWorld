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

        [Required] //makes name non nullable..using dataannotations...override
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }


        //[Min18YearsIfMember] 
        public String BirthDate { get; set; }


    }
}