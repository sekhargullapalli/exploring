using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnoCountries.Shared;
using UnoCountries.Shared.Data;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace UnoCountries
{    
    public sealed partial class MainPage : Page
    {
        public List<CountryData> Countries = new List<CountryData>();
        public ObservableCollection<CountryData> FilteredCountries = new ObservableCollection<CountryData>();
        DispatcherTimer Timer = new DispatcherTimer();
        public MainPage()
        {
            Countries = DataProvider.CountryContext.Countries.OrderBy(c => c.Name).ToList();
            FilteredCountries = new ObservableCollection<CountryData>(Countries);
            this.InitializeComponent();

            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();

            cmb_Continents.ItemsSource = DataProvider.CountryContext.Countries.Select(x => x.ContinentName).Distinct().OrderBy(c => c).ToList();
            grd_Countries.ItemsSource = FilteredCountries;
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private void cmb_Continents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (txt_Search.Text.Trim() == string.Empty)
            //    UpdateVisibility();
            //else
            //    txt_Search.Text = string.Empty;
            UpdateVisibility();
        }

        private void BackRequested(object sender, EventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private void txt_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Timer.Interval = new TimeSpan(10);
            Timer.Start();
        }
        private void grd_Countries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowCountryDetails();
        }


        private void Timer_Tick(object sender, object e)
        {
            UpdateVisibility();
            Timer.Stop();
        }
        void UpdateVisibility()
        {
            List<CountryData> TemporaryList = Countries.Where(c => isCountryVisible(c)).ToList();
            for (int i = FilteredCountries.Count - 1; i >= 0; i--)
            {
                var item = FilteredCountries[i];
                if (!TemporaryList.Contains(item))
                {
                    FilteredCountries.Remove(item);
                }
            }
            foreach (var item in TemporaryList)
            {
                if (!FilteredCountries.Contains(item))
                {
                    var index = FilteredCountries.ToList().BinarySearch(item);
                    if (index < 0) index = ~index;
                    FilteredCountries.Insert(index, item);
                }
            }
        }
        bool isCountryVisible(CountryData country)
        {
            bool isvisible = cmb_Continents.SelectedIndex == -1 || country.ContinentName == cmb_Continents.SelectedValue.ToString();
            isvisible = isvisible &&
                (txt_Search.Text.Trim() == string.Empty || country.Name.ToLower().Contains(txt_Search.Text.Trim().ToLower()));
            return isvisible;
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
        private void SymbolIcon_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            cmb_Continents.SelectedIndex = -1;
            UpdateVisibility();
        }
        private void clrIcon_PointerPressed(object sender, PointerRoutedEventArgs e)
            => txt_Search.Text = string.Empty;
        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //ShowCountryDetails();
        }
        private void ShowCountryDetails()
        {
            if (grd_Countries.SelectedIndex != -1)
                this.Frame.Navigate(typeof(CountryDetailPage), (grd_Countries.SelectedItem as CountryData).ID);
        }
    }
}
