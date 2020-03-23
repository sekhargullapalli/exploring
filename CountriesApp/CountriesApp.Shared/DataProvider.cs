using System;


namespace CountriesApp.Shared
{
    public static class DataProvider
    {
        public static CountryDataContext CountryContext { get; set; } = null;
        static DataProvider()
        {
            CountryContext = new CountryDataContext();
            foreach (var country in CountryContext.Countries)
            {
                if (country.Flagfile.Trim() == string.Empty) country.Flagfile = "No_flag.gif";
                country.Flagfile = @"ms-appx:///Assets/flags/" + country.Flagfile;
                country.LocatorMap = @"ms-appx:///Assets/locatormaps/" + $"{country.GEC}-locator-map.gif";
                country.Map = @"ms-appx:///Assets/maps/" + $"{country.GEC}-map.gif";
                country.HasAnthem = country.AnthemFile != string.Empty;
                country.ContinentName = country.ContinentName.Trim() == string.Empty ? "Unknown" : country.ContinentName.Trim();
                country.ID = Guid.NewGuid().ToString();
            }
        }
    }
}
