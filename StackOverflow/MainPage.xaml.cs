using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Stackoverflow.Resources;
using System.Diagnostics;

namespace Stackoverflow
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
            this.OrientationChanged += MainPage_OrientationChanged;
        }

        void MainPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if ((e.Orientation & PageOrientation.Landscape) > 0)
            {
                this.ApplicationBar.IsVisible = false;
                SystemTray.IsVisible = false;
            }
            else
            {
                this.ApplicationBar.IsVisible = true;
                SystemTray.IsVisible = true;
            }
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.WebBrowser.Navigate(new Uri(Constants.StackOverflowBaseUrl));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if(this.WebBrowser.CanGoBack)
            {
                this.WebBrowser.GoBack();
                e.Cancel = true;
            }
            base.OnBackKeyPress(e);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            this.WebBrowser.Navigate(new Uri(this.WebBrowser.Source.AbsoluteUri));
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));
        }

        private void About_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }

        private void WebBrowser_Navigating(object sender, NavigatingEventArgs e)
        {
            SystemTray.ProgressIndicator.IsVisible = true;
        }

        private void WebBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            SystemTray.ProgressIndicator.IsVisible = false;
        }

        private void WebBrowser_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            SystemTray.ProgressIndicator.IsVisible = false;
        }
    }
}