using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_Res.Entity
{
    public class Trainee
    {
        [Display(Name = "Serial Number")]
        public long SerialNumber { get; set; }
        public string Prefix { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Of Joining")]
        public DateTime JoiningDate { get; set; }

        [Display(Name = "Current Company")]
        public string CurrentCompany {  get; set; }
        [Display(Name = "Current Address")]
        public string CurrentAddress { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Education")]
        public byte EducationId { get; set; }
        [ForeignKey("EducationId")]
        [ValidateNever]
        public Qualification Education { get; set; }
    }
}
