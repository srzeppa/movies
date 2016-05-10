using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace movies.View
{
    public sealed partial class ToWatchPage : Page
    {
        Model.UserMovie userMovie = new Model.UserMovie();
        ViewModel.JsonParser jsonParser = new ViewModel.JsonParser();
        List<Model.UserMovie> listUserMovie = new List<Model.UserMovie>();
        ViewModel.DatabaseHandler moviesFromDatabase = new ViewModel.DatabaseHandler();

        public ToWatchPage()
        {
            InitializeComponent();
            feelUsersMovies();
        }

        public async void feelUsersMovies()
        {
            ListViewItem listViewItem = new ListViewItem();
            listUserMovie = moviesFromDatabase.getMoviesFromDatabase();

            foreach (Model.UserMovie movie in listUserMovie)
            {
                Model.Movie movieModel = await ViewModel.JsonParser.getMovieById(movie.imdbId);
                listViewUserMovies.Items.Add(new BitmapImage(new Uri(movieModel.poster)));
            }
        }
    }
}
