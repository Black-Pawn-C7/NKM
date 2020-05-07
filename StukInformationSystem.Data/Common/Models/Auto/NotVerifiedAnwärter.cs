using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models.Auto
{
    public class NotVerifiedAnwärter
    {
        [JsonProperty("ID", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("Vorname", Required = Required.Always)]
        public string Vorname { get; set; }

        [JsonProperty("Nachname", Required = Required.Always)]
        public string Nachname { get; set; }

        [JsonProperty("Anzahl", Required = Required.Always)]
        public int Anzahl { get; set; }

        [JsonProperty("AE", Required = Required.Always)]
        public double Ae { get; set; }
    }
}
