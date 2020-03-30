using System;

namespace UnoCountries.Shared.Data
{
    public static class DataProvider
    {
        public static CountryDataContext CountryContext { get; set; } = null;
        static DataProvider()
        {
            CountryContext = new CountryDataContext();
            foreach (var country in CountryContext.Countries)
            {
                if (country.Flagfile.Trim() == string.Empty) country.Flagfile = "None_flag.gif";
                country.Flagfile = @"ms-appx:///Assets/flags/" + country.Flagfile.Replace("-", "_");
                country.LocatorMap = @"ms-appx:///Assets/locatormaps/" + $"{country.GEC.Replace("-", "_")}_locator_map.gif";
                country.Map = @"ms-appx:///Assets/maps/" + $"{country.GEC.Replace("-", "_")}_map.gif";
                country.HasAnthem = country.AnthemFile != string.Empty;
                country.ContinentName = country.ContinentName.Trim() == string.Empty ? "Unknown" : country.ContinentName.Trim();
                country.ID = Guid.NewGuid().ToString();
            }
        }


        //static DataProvider()
        //{
        //    CountryContext = new CountryDataContext();
        //    foreach (var country in CountryContext.Countries)
        //    {
        //        if (country.Flagfile.Trim() == string.Empty) country.Flagfile = "None_flag.gif";
        //        country.Flagfile = @"./" + country.Flagfile.Replace("-", "_");
        //        country.LocatorMap = @"./" + $"{country.GEC.Replace("-", "_")}_locator_map.gif";
        //        country.Map = @"./" + $"{country.GEC.Replace("-", "_")}_map.gif";
        //        country.HasAnthem = country.AnthemFile != string.Empty;
        //        country.ContinentName = country.ContinentName.Trim() == string.Empty ? "Unknown" : country.ContinentName.Trim();
        //        country.ID = Guid.NewGuid().ToString();
        //    }
        //}
    }
}
