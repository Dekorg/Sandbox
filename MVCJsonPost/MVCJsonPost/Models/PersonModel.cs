using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MVCJsonPost.Models
{
    public class PersonModel
    {
        [DisplayName("First")]
        public string First { get; set; }

        [DisplayName("Last")]
        public string Last { get; set; }

        [DisplayName("Favorite Bands")]
        public List<string> FavoriteBands { get; set; }
    }
}