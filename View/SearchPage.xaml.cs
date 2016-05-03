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
        public SearchPage()
        {
            InitializeComponent();
        }

        private async void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            String title = textBoxSearch.Text;
            Movie movie;
            if (title != null || title != "")
            {
                movie = await JsonParser.searchMovie(title);
                if(movie.poster != null)
                {
                    posterImage.Source = new BitmapImage(new Uri(movie.poster));
                }
                movieTextBlock.Text = "Title: " + movie.title + "\r\nYear: " + movie.year + "\r\nDirector: " + movie.director + "Writer: " + movie.writer +  "\r\nActors: " + movie.actors + "\r\nGenre: " + movie.genre + "\r\nCountry: " + movie.country + "\r\nLanguage: " + movie.language + "\r\nAwards: " + movie.awards;

                AddToFavouritesButton.Visibility = Visibility.Visible;
            }

        }

        private void AddToFavouritesButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
