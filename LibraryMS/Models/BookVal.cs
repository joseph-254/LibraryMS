using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryMS.Models
{
    [MetadataType(typeof(BookMetadata))]
    public partial class book
    {
        public class BookMetadata
        {
            [Display(Name ="Book")]
            public string bkName { get; set; }
            [Display(Name = "Category")]
            public Nullable<int> catg_id { get; set; }
            [Display(Name = "Author")]
            public Nullable<int> auth_id { get; set; }
            [Display(Name = "Publisher")]
            public Nullable<int> pub_id { get; set; }
            [Display(Name = "Content")]
            public string contents { get; set; }
            [Display(Name = "Pages")]
            public Nullable<int> pages { get; set; }
            [Display(Name = "Edition")]
            public string edition { get; set; }
        }
    }
}