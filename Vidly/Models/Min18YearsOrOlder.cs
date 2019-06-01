using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsOrOlder : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Customer = (Customer)validationContext.ObjectInstance;

            if (Customer.MembershiptypeId == MembershipType.Unknown || Customer.MembershiptypeId == MembershipType.Trial)
            {
                return ValidationResult.Success;
            }

            if (Customer.BirthDate == null)
            {
                return new ValidationResult("Birthday date not set");
            }

            var age = DateTime.Now.Year - Customer.BirthDate.Value.Year;

            return (age >= 18 ? ValidationResult.Success : new ValidationResult("Customer underage"));


        }
    }
}