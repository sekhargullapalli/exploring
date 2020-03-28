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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CountriesApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DisclaimerPage : Page
    {
        public string Disclaimer { get; set; } = string.Empty;

        public DisclaimerPage()
        {
            Disclaimer = @"
                This application is intended to serve as a demo application for various cross platform development technologies such as Xamarin and Uno Platform. It is hence possible that the data related to the countries, the list of countries may not be accurate or misleading.

                The data of the countries used in this application is derived programmatically from The CIA Factbook Archive 2018. It is possible that some errors might be caused while parsing the data. The owner  and developers take no responsibility for the accuracy of the content and strictly state that this app is developed for demonstration purpose of various software development technologies.
                
                The continent data is taken from https://datahub.io/JohnSnowLabs/country-and-continent-codes-list#resource-country-and-continent-codes-list-csv. The users have not verified the accuracy of this content and there might be some mismatches for some countries. Again, the developer and owner of this application does not take any responsibility for the accuracy of the data.
                
                It is possible that this application might be updated with new Factbook archive  (2019) if it is published. The users must also be aware that, until then, the data shown, wherever accurate in relation with the reference, might still be valid at an older data and is no updated. 
            ";

            this.InitializeComponent();
            this.DataContext = this;
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
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
        private void AppBarHome_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

       
    }
}
