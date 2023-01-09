namespace CountryExplorer.Adapters.Models
{
    public class Country
    {
        public Name Name { get; set; }

        public Dictionary<string, Currency> Currencies { get; set; }

        public IReadOnlyList<string> Capital { get; set; }

        public string Region { get; set; }

        public Dictionary<string, string> Languages { get; set; }

        public Dictionary<string, string> Flags { get; set; }

        public Dictionary<string, string> Maps { get; set; }
    }
}
