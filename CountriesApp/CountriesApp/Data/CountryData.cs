using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CountriesApp.Data
{
    public class CountryData: IComparable<CountryData>
    {
        public string GEC { get; set; } = "";
        public string Name { get; set; } = "";
        public string ISO_3166_1_Alpha2 { get; set; } = "";
        public string Flagfile { get; set; } = "";
        public string AnthemFile { get; set; } = "";

        public string ContinentName { get; set; } = "";

        public string Introduction { get; set; } = "";
        public string Capital { get; set; } = "";
        public string Population { get; set; } = "";
        public string GeoCoordinates { get; set; } = "";

        //Also called as
        public Dictionary<string, string> AKA { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Area { get; set; } = new Dictionary<string, string>();

        public string LocatorMap { get; set; } = string.Empty;
        public string Map { get; set; } = string.Empty;
        public bool HasAnthem { get; set; } = true;
        public string ID { get; set; } = string.Empty;

        public override bool Equals(object obj)
        {
            return obj is CountryData && Name == (obj as CountryData).Name;
        }
        public int CompareTo(CountryData other)
        {
            return this.Name.CompareTo(other.Name);
        }

    }
}
