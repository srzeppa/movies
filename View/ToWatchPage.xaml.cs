using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace movies.View
{
    public sealed partial class ToWatchPage : Page
    {
        Model.UserMovie userMovie = new Model.UserMovie();

        public ToWatchPage()
        {
            InitializeComponent();

            List<Model.UserMovie> listUserMovie = new List<Model.UserMovie>();
            ViewModel.DatabaseHandler moviesFromDatabase = new ViewModel.DatabaseHandler();
            listUserMovie = moviesFromDatabase.getMoviesFromDatabase();
        }
    }
}
