using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Collections.ObjectModel;

namespace CountriesApp.Shared
{
    public class CountryDataContext
    {
        public ObservableCollection<CountryData> Countries { get; set; } = new ObservableCollection<CountryData>();

        public CountryDataContext()
        {
            Countries = JsonConvert.DeserializeObject<ObservableCollection<CountryData>>(GetEmbeddedResource("countriesdb.json"));

        }

        static string GetEmbeddedResource(string resource)
        {
            using (var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream($"GlanceAtCountries.Data.{resource}")))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
