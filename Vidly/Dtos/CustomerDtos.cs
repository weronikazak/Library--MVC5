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

        [Required]
        public byte MembershiptypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18YearsOrOlder]
        public DateTime? BirthDate { get; set; }
    }
}