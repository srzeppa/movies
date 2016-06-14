using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
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
                listViewUserMovies.Items.Add(movieModel.title);
            }
        }

        private void listItemClick(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("dsdasdasdasdasdasdasdasdas");

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("edit");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("delete");
        }
    }
}
