using System;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models
{
    public class WebDateAmount
    {
        [JsonProperty("Amount")]
        public double Amount { get; set; }

        [JsonProperty("Datum")]
        public DateTime Datum { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Schulung")]
        public string Schulung { get; set; }
    }
}