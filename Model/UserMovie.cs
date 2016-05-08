using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies.Model
{
    class UserMovie
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string imdbId { get; set; }
        public int userVote { get; set; }
        public DateTime whereToWatch { get; set; }
    }
}
