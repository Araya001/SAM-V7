using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAM_V7.Models
{
    public class Proposal
    {
        [Required(ErrorMessage = "Please type Organization Name.")]
        public string OrganName { get; set; }

        [Key]
        public string DocNo { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please type Date.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please type Subject.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please type Activity Name.")]
        public string ActName { get; set; }

        [Display(Name = "StartDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please type Start Date.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please type End Date.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please type Place.")]
        public string Place { get; set; }


        public double StdBudget { get; set; }
        public string OthName { get; set; }
        public double OthBudget { get; set; }



        [Required(ErrorMessage = "Please type Total.")]
        public double Total { get; set; }

        public int Act1 { get; set; }
        public int Act2 { get; set; }
        public int Act3 { get; set; }
        public int Act4 { get; set; }
        public int Act5 { get; set; }
        public int Act6 { get; set; }


        public string Result1 { get; set; }
        public string Comment1 { get; set; }
        public string Result1Date { get; set; }

        public string Result2 { get; set; }
        public string Comment2 { get; set; }
        public string Result2Date { get; set; }

        public string Result3 { get; set; }
        public string Comment3 { get; set; }
        public string Result3Date { get; set; }

        public string Result4 { get; set; }
        public string Comment4 { get; set; }
        public string Result4Date { get; set; }

        public string Result5 { get; set; }
        public string Comment5 { get; set; }
        public string Result5Date { get; set; }

        public string Result6 { get; set; }
        public string Comment6 { get; set; }
        public string Result6Date { get; set; }

        public string Result7 { get; set; }
        public string Comment7 { get; set; }
        public string Result7Date { get; set; }

        public string Remark { get; set; }

        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<FilePath> FilePaths { get; set; }
    }
}