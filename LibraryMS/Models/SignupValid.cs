using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMS.Models
{
    [MetadataType(typeof(SignupMetadata))]
    public partial class Usertable
    {
        public class SignupMetadata
        {
            public int id { get; set; }
            [Required(ErrorMessage = "This field is required")]
            [Display(Name = "Username")]
            public string userName { get; set; }
            [Required(ErrorMessage = "This field is required")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string passWord { get; set; }
            [Required(ErrorMessage = "This field is required")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [NotMapped]
            [Compare("passWord", ErrorMessage = "Confirm password doesn't match, try again!")]
            public string RepassWord { get; set; }
        }
    }
}