using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAM_V7.Models
{
    public class Organizations
    {
        [Key]
        public string OrganNo { get; set; }

        [Required(ErrorMessage = "Please type Organization Name.")]
        public string OrganName { get; set; }

        public string PSUPassport { get; set; }

        public string TitleAdviserName { get; set; }
        public string AdviserName { get; set; }
        public string AdviserLastName { get; set; }
        public string AdviserEmail { get; set; }
        public string AdviserTel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartPositionDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndPositionDate { get; set; }
    }
}