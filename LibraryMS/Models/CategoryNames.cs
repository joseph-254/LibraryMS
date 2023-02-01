using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryMS.Models
{
    [MetadataType(typeof(CategoryMetadata))]
    public partial class category
    {
       
        public class CategoryMetadata
        {
            [DisplayName("Category")]
            public string catename { get; set; }
            [DisplayName("Status")]
            public string status { get; set; }
        }
       
    }
}