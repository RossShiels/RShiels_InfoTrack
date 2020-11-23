using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RShiels_InfoTrack.Models
{
    public class SearchResultViewModel
    {
        [Required]
        public string SearchTerms { get; set; }
        public int SearchResultAmount { get; set; }
        [Required]
        public string SearchURL { get; set; }

        public string SearchResult { get; set; }
    }
}