using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Collections.ObjectModel;



namespace UnoCountries.Shared.Data
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
 #if __ANDROID__
            using (var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream($"UnoCountries.Droid.{resource}")))
            {
                return reader.ReadToEnd();
            }
 #elif __WASM__
            using (var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream($"UnoCountries.Wasm.{resource}")))
            {
                return reader.ReadToEnd();
            }
#else
            using (var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream($"UnoCountries.{resource}")))
            {
                return reader.ReadToEnd();
            }
#endif
        }
    }
}
