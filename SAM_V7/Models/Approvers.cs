using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAM_V7.Models
{
    public class Approvers
    {
        [Key]
        public string PSUPassport { get; set; }

        public string TitleName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please type your Organization.")]
        public string OrganName { get; set; }

        [Required(ErrorMessage = "Please type your Position.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Please type your E-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please type your Tel.")]
        public string Tel { get; set; }
    }
}