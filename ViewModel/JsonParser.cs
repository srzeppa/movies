using movies.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace movies.ViewModel
{
    class JsonParser
    {
        public async static Task<Movie> getMovieByTitle(string title)
        {
            var http = new HttpClient();
            string url = String.Format("http://www.omdbapi.com/?t=" + title +"&y=&plot=short&r=json");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            Movie movie = JsonConvert.DeserializeObject<Movie>(result);

            return movie;
        }

        public async static Task<Movie> getMovieById(string id)
        {
            var http = new HttpClient();
            string url = String.Format("http://www.omdbapi.com/?i=" + id + "&y=&plot=short&r=json");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            Movie movie = JsonConvert.DeserializeObject<Movie>(result);

            return movie;
        }
    }
}
