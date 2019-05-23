using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC1_BookWorld.Models
{
    public class NoOfBooksRange:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           // return base.IsValid(value, validationContext);

           var book = (Book) validationContext.ObjectInstance;

           for (int i = 1;i<=20;i++) {
               if (book.NumberInStock == i)
                   return ValidationResult.Success;
           }

           if (book.NumberInStock == 0)
               return new ValidationResult("The number should be between 1 to 20");
           return null;
        }
    }
}