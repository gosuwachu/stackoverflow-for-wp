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
using Microsoft.Phone.Tasks;
using System.IO;

namespace Stackoverflow
{
    public partial class MainPage : PhoneApplicationPage
    {
        public StackOverflowBrowser CurrentBrowser
        {
            get
            {
                StackOverflowBrowser browser = (this.HomeScreen.SelectedItem as PivotItem).Content as StackOverflowBrowser;
                return browser;
            }
        }
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
            this.OrientationChanged += MainPage_OrientationChanged;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            
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

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if(this.CurrentBrowser.WebBrowser.CanGoBack)
            {
                this.CurrentBrowser.WebBrowser.GoBack();
                e.Cancel = true;
            }
            base.OnBackKeyPress(e);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            this.CurrentBrowser.WebBrowser.Navigate(new Uri(this.CurrentBrowser.WebBrowser.Source.AbsoluteUri));
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));
        }

        private void About_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }

        private void SignIn_Clicked(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/StackOverflowAuthenticationPage.xaml", UriKind.Relative));
        }
    }
}