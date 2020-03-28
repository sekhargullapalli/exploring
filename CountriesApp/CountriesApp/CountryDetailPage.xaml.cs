using CountriesApp.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace CountriesApp
{    
    public sealed partial class CountryDetailPage : Page
    {
        public CountryData Data { get; set; } = new CountryData();

        public CountryDetailPage()
        {
            if (DataProvider.CountryContext.Countries.Any())
                Data = DataProvider.CountryContext.Countries.First();
            this.InitializeComponent();
            this.DataContext = Data;
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                string id = e.Parameter as string;
                Data = DataProvider.CountryContext.Countries.Where(c => c.ID == id).First();
                this.DataContext = Data;
            }
            base.OnNavigatedTo(e);
        }


        private void AppBarForward_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoForward)
                this.Frame.GoForward();
        }
        private void AppBarBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }
        private void AppBarDisclaimer_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DisclaimerPage));
        }
        private void AppBarHome_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
