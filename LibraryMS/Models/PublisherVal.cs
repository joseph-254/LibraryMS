﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryMS.Models
{
    [MetadataType(typeof(PublisherMetadata))]
    public partial class publisher
    {
        public class PublisherMetadata
        {
            [Display(Name="Name")]
            public string name { get; set; }
            [Display(Name = "Address")]
            public string address { get; set; }
            [Display(Name = "Phone")]
            public string phone { get; set; }
        }
    }
}