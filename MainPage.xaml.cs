using movies.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace movies
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            JsonParser.searchMovie("deadpool");
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 320, Height = 320 });
        }

        public Frame AppFrame { get { return Content; } }

        private void Option1Button_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Option2Button_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationPane.IsPaneOpen = !NavigationPane.IsPaneOpen;
        }
    }
}

//https://github.com/Windows-Readiness/AbsoluteBeginnersWin10/blob/master/UWP-021/UWP-021/HamburgerExample/HamburgerExample/MainPage.xaml.cs