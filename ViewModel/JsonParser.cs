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
        public async static Task<Movie> searchMovie(string title)
        {
            var http = new HttpClient();
            string riotURL = String.Format("http://www.omdbapi.com/?t=" + title +"&y=&plot=short&r=json");
            var response = await http.GetAsync(riotURL);

            var result = await response.Content.ReadAsStringAsync();

            Movie movie = new Movie();
            movie = JsonConvert.DeserializeObject<Movie>(result);
            System.Diagnostics.Debug.WriteLine(movie.title);
            return movie;
        }
    }
}
