using System;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models
{
    public class Arbeitseinsaetze
    {
        [JsonProperty("Datum")]
        public DateTime Datum { get; set; }

        [JsonProperty("Time")]
        public int Time { get; set; }

        [JsonProperty("Start")]
        public string Start { get; set; }

        [JsonProperty("Ende")]
        public string Ende { get; set; }

        [JsonProperty("Leiter")]
        public string Leiter { get; set; }

        [JsonProperty("Tätigkeit")]
        public string Tätigkeit { get; set; }

        [JsonProperty("Bemerkung")]
        public string Bemerkung { get; set; }
    }
}