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
            InitializeComponent();
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 320, Height = 320 });
            InitializeHamburgerMenu();
            trnslttrnsfrmMenuTop.X = -stckpnlMenuWidth;
            trnslttrnsfrmMenuBottom.X = -stckpnlMenuWidth;
            pgMainPage.ManipulationMode = ManipulationModes.TranslateX;
        }

        #region "Hamburger menu"

        double stckpnlMenuWidth = 210;
        double InitialManipulationPointX;
        bool HamburgerMenuOpen = false;
        bool HamburgerMenuOpeningClosing = false;

        private void InitializeHamburgerMenu()
        {
            shMenu1.From = -stckpnlMenuWidth;
            shMenu2.From = -stckpnlMenuWidth;
            hdMenu1.To = -stckpnlMenuWidth;
            hdMenu2.To = -stckpnlMenuWidth;
            stckpnlMenuTop.Width = stckpnlMenuWidth;
            stckpnlMenuBottom.Width = stckpnlMenuWidth;
        }

        private void bttnHamburgerMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (HamburgerMenuOpen)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }

        private void MenuSearch_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HideMenu();
        }

        private void MenuFavourites_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HideMenu();
        }

        private void MenuPrivacy_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HideMenu();
        }

        private void MenuTerms_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HideMenu();
        }

        private void MenuAbout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HideMenu();
        }

        private void grdPageOverlay_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HideMenu();
        }

        private async void ShowMenu()
        {
            grdPageOverlay.Visibility = Visibility.Visible;
            await strbrdShowMenu.BeginAsync();
            HamburgerMenuOpen = true;
        }

        private async void HideMenu()
        {
            HamburgerMenuOpen = false;
            grdPageOverlay.Visibility = Visibility.Collapsed;
            await strbrdHideMenu.BeginAsync();
        }

        private void pgMainPage_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            InitialManipulationPointX = e.Position.X;
            HamburgerMenuOpeningClosing = HamburgerMenuOpen ? false : InitialManipulationPointX < 30 ? true : false;
        }

        private void pgMainPage_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {

            if (HamburgerMenuOpeningClosing || (HamburgerMenuOpen && InitialManipulationPointX > e.Position.X))
            {
                HamburgerMenuOpeningClosing = true;
                if (e.Position.X < stckpnlMenuWidth + 1)
                {
                    Point currentpoint = e.Position;
                    trnslttrnsfrmMenuTop.X = e.Position.X < stckpnlMenuWidth ? -stckpnlMenuWidth + e.Position.X : 0;
                    trnslttrnsfrmMenuBottom.X = e.Position.X < stckpnlMenuWidth ? -stckpnlMenuWidth + e.Position.X : 0;
                }
            }
        }

        private async void pgMainPage_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (HamburgerMenuOpeningClosing || (HamburgerMenuOpen && InitialManipulationPointX > e.Position.X))
            {
                double X = e.Position.X > stckpnlMenuWidth ? stckpnlMenuWidth : e.Position.X;
                if (X > stckpnlMenuWidth / 2)
                {
                    shMenu1.From = -stckpnlMenuWidth + X;
                    shMenu2.From = -stckpnlMenuWidth + X;
                    await strbrdShowMenu.BeginAsync();
                    shMenu1.From = -stckpnlMenuWidth;
                    shMenu2.From = -stckpnlMenuWidth;
                    grdPageOverlay.Visibility = Visibility.Visible;
                    HamburgerMenuOpen = true;
                }
                else
                {
                    grdPageOverlay.Visibility = Visibility.Collapsed;
                    hdMenu1.From = X - stckpnlMenuWidth;
                    hdMenu2.From = X - stckpnlMenuWidth;
                    await strbrdHideMenu.BeginAsync();
                    hdMenu1.From = 0;
                    hdMenu2.From = 0;
                    HamburgerMenuOpen = false;
                }
            }
            HamburgerMenuOpeningClosing = false;
        }

        #endregion
    }

    public static class StoryboardExtensions
    {
        public static Task BeginAsync(this Storyboard storyboard)
        {
            try
            {
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                if (storyboard == null)
                    tcs.SetException(new ArgumentNullException());
                else
                {
                    EventHandler<object> onComplete = null;
                    onComplete = (s, e) => {
                        storyboard.Completed -= onComplete;
                        tcs.SetResult(true);
                    };
                    storyboard.Completed += onComplete;
                    storyboard.Begin();
                }
                return tcs.Task;
            }
            catch
            {
                return null;
            }
        }

    }
}