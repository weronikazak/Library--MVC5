using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        public byte MembershiptypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsOrOlder]
        public DateTime? BirthDate { get; set; }
    }
}