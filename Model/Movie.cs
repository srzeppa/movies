using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies.Model
{
    class Movie
    {

        public string title { get; set; }
        public int year { get; set; }
        public string rated { get; set; }
        public string relased { get; set; }
        public string runtime { get; set; }
        public string genre { get; set; }
        public string director { get; set; }
        public string writer { get; set; }
        public string actors { get; set; }
        public string plot { get; set; }
        public string language { get; set; }
        public string country { get; set; }
        public string awards { get; set; }
        public string poster { get; set; }
        public int metascore { get; set; }
        public double imdbRating { get; set; }
        public double imdbVotes { get; set; }
        public string imdbId { get; set; }
        public string type { get; set; }
        public bool response { get; set; }

    }
}
