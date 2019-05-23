using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC1_BookWorld.Models
{
    public class Min18YearsIfMember: ValidationAttribute
    {             //validation context as argument to access props of model
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {                  //casting  //<--- validation prop containing model-->
            var customer = (Customer) validationContext.ObjectInstance; 

            if (customer.MembershipTypeId==MembershipType.unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            //var age = DateTime.Today.Year - customer.BirthDate.Year;
           // var age = 20;
           //suppose type 3 membership is criteria for birthdate

            return (customer.MembershipTypeId != 3) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be atleast 18 years");
        }
    }
}