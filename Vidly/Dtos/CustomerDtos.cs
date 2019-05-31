using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDtos
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