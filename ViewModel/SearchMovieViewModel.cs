using movies.Command;
using movies.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace movies.ViewModel
{
    class SearchMovieViewModel : MainViewModel
    {
        private Movie movie_ = null;
        private UserMovie userMovie_ = null;
        private String titleToSearch;
        private String content;
        private String plot;
        private String poster;
        private String imdbId;
        private Double rateValue;
        private int sliderValue;
        private DateTime dateTime;

        public String Title
        {
            get
            {
                return titleToSearch;
            }
            set
            {
                titleToSearch = value;
                OnPropertyChanged("Title");
            }
        }

        public String Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        public String DisplayedPosterPath
        {
            get
            {
                return poster;
            }
            set
            {
                poster = value;
                OnPropertyChanged("DisplayedPosterPath");
            }
        }

        public String Plot
        {
            get
            {
                return plot;
            }
            set
            {
                plot = value;
                OnPropertyChanged("Plot");
            }
        }

        public DateTime Date
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
                OnPropertyChanged("Date");
            }
        }

        public String ImdbId
        {
            get
            {
                return imdbId;
            }
            set
            {
                imdbId = value;
            }
        }

        public Double RateValue
        {
            get
            {
                return rateValue;
            }
            set
            {
                rateValue = value;
                OnPropertyChanged("RateValue");
            }
        }

        public int Slider
        {
            get
            {
                return sliderValue;
            }
            set
            {
                sliderValue = value;
                OnPropertyChanged("Slider");
            }
        }

        public ICommand GetMovieCommand
        {
            get
            {
                return new GetMovieCommand(getMovieByTitle);
            }
        }

        public ICommand ToWatchCommand
        {
            get
            {
                return new GetMovieCommand(insert);
            }
        }

        public async void getMovieByTitle()
        {
            var http = new HttpClient();
            string url = String.Format("http://www.omdbapi.com/?t=" + Title + "&y=&plot=short&r=json");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            Movie movie = JsonConvert.DeserializeObject<Movie>(result);
            Debug.WriteLine(movie);
            if(movie.imdbId == null)
            {
                RateValue = 0;
                ImdbId = "";
                Plot = "";
                DisplayedPosterPath = "";
                Title = "";
                Content = "This movie isnt in our database!";
            } else
            {
                BitmapImage src = new BitmapImage();
                src.UriSource = new Uri(movie.poster);

                RateValue = movie.imdbRating;
                ImdbId = movie.imdbId;
                Title = movie.title;
                Plot = movie.plot;
                DisplayedPosterPath = movie.poster;

                Content = "Title: " + movie.title + "\r\nYear: " + movie.year + "\r\nDirector: " + movie.director + "Writer: " + movie.writer + "\r\nActors: " + movie.actors + "\r\nGenre: " + movie.genre + "\r\nCountry: " + movie.country + "\r\nLanguage: " + movie.language + "\r\nAwards: " + movie.awards;
            }

            
        }

        string path;
        SQLite.Net.SQLiteConnection conn;
        public void insert()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "movies.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            Debug.WriteLine(Date);
            var s = conn.Insert(new Model.UserMovie()
            {
                imdbId = ImdbId,
                userVote = Slider,
                whereToWatch = Date
            });
        }

    }
}
