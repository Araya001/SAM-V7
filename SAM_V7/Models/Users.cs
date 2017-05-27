using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAM_V7.Models
{
    public class Users
    {
        [Key]
        public string PSUPassport { get; set; }

        public string TitleName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public string Major { get; set; }

        [Required(ErrorMessage = "Please type your Organization.")]
        public string OrganName { get; set; }

        [Required(ErrorMessage = "Please type your Position.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Please type your E-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please type your Tel.")]
        public string Tel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartPositionDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndPositionDate { get; set; }
    }
}