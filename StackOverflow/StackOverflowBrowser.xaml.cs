using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Stackoverflow
{
    public partial class StackOverflowBrowser : UserControl
    {
        public string InitialUri
        {
            get { return (string)GetValue(InitialUriProperty); }
            set { SetValue(InitialUriProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InitialUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InitialUriProperty =
            DependencyProperty.Register("InitialUri", typeof(string), typeof(StackOverflowBrowser), new PropertyMetadata(""));

        public StackOverflowBrowser()
        {
            InitializeComponent();
            this.Loaded += StackOverflowBrowser_Loaded;
        }

        void StackOverflowBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            this.WebBrowser.Navigate(new Uri(this.InitialUri));
        }

        private void WebBrowser_Navigating(object sender, NavigatingEventArgs e)
        {
            //if (!e.Uri.Host.Contains("stackoverflow.com") && !e.Uri.ToString().Contains("javascript"))
            //{
            //    WebBrowserTask task = new WebBrowserTask();
            //    task.Uri = e.Uri;
            //    task.Show();

            //    e.Cancel = true;
            //}
            //else
            {
                SystemTrayProgressIndicator.Show();
            }
        }

        private void WebBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            SystemTrayProgressIndicator.Hide();
        }

        private void WebBrowser_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            SystemTray.ProgressIndicator.IsVisible = false;
        }
    }
}
