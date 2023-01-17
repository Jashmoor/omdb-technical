using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Core.Models
{

    public class SearchResponse
    {
        public Search[] Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }

    public class Search
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

}
