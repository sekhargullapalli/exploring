using CountriesApp.Data;
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



namespace CountriesApp
{
 
    public sealed partial class MainPage : Page
    {

        public List<CountryData> Countries = new List<CountryData>();

        public MainPage()
        {
            this.InitializeComponent();


            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values["launchedWithPrefSize"] == null)
            {
                ApplicationView.PreferredLaunchViewSize = new Size(360, 800);
                ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
                localSettings.Values["launchedWithPrefSize"] = true;
            }
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.Auto;
        }

        private void AppBarBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AppBarDisclaimer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AppBarForward_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmb_Continents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SymbolIcon_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

        }

        private void txt_Search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void clrIcon_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

        }
    }
}
