using System;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models
{
    public class MemberDienste
    {
        [JsonProperty("Datum")]
        public DateTime Datum { get; set; }

        [JsonProperty("Start")]
        public string Start { get; set; }

        [JsonProperty("Ende")]
        public string Ende { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("AV")]
        public string Av { get; set; }

        [JsonProperty("multiplikator")]
        public double Multiplikator { get; set; }

        [JsonProperty("Bemerkung")]
        public string Bemerkung { get; set; }
    }
}