using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskUsingEFCore.Models
{
    public class PersonProperty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Name")]
        public string PersonName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string PersonEmail { get; set; }
        [Required]
        [Display(Name = "Plan")]
        public string PersonPlan { get; set; }
        [Required]
        [Display(Name = "Billing Intervel")]
        public string PersonBillingIntervel { get; set; }

        [Required]
        public string PersonStreetAddress { get; set; }

        [Required]
        [Display(Name = "City")]
        public string PersonCity { get; set; }
        [Display(Name = "Phone Number")]
        public string PersonPhoneNumber { get; set; }

        [Display(Name = "State")]
        public string PersonState { get; set; }

        [Display(Name = "Postal Code")]
        public string PersonPostalCode { get; set; }

        [Display(Name = "Country")]
        public string PersonCountry { get; set; }

        [Display(Name = "Old Password")]
        public string PersonOldPassword { get; set; }

        [Display(Name = "New Password")]
        public string PersonNewPassword { get; set; }

    }
}
