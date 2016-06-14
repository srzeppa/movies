using movies.Model;
using movies.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace movies.View
{
    public sealed partial class SearchPage : Page
    {
        Movie movie;
        public SearchPage()
        {
            InitializeComponent();
            DataContext = new MovieViewModel();
        }

        private async void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            String title = textBoxSearch.Text;
            if (title != null || title != "")
            {
                movie = await JsonParser.getMovieByTitle(title);
                if (movie.title != null)
                {
                    if (movie.poster != null)
                    {
                        posterImage.Source = new BitmapImage(new Uri(movie.poster));
                    }
                    movieTextBlock.Text = "Title: " + movie.title + "\r\nYear: " + movie.year + "\r\nDirector: " + movie.director + "Writer: " + movie.writer + "\r\nActors: " + movie.actors + "\r\nGenre: " + movie.genre + "\r\nCountry: " + movie.country + "\r\nLanguage: " + movie.language + "\r\nAwards: " + movie.awards;
                    posterTextBlock.Text = movie.plot;
                    Rating.Value = movie.imdbRating;
                    ToWatchButton.Visibility = Visibility.Visible;
                } else
                {
                    movieTextBlock.Text = "this movie is not in our database";
                }
            }

        }

        private void ToWatchButton_Click(object sender, RoutedEventArgs e)
        {
            userToWatchDatePicker.Visibility = Visibility.Visible;
        }

        private void userToWatchDatePicker_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            DateTime date = userToWatchDatePicker.Date.DateTime;
            ViewModel.DatabaseHandler insertToDatabase = new ViewModel.DatabaseHandler();
            if (date > DateTime.Now)
            {
                insertToDatabase.insert(movie.imdbId, 0, date);
            }
        }
    }
}
