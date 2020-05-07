using System;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models
{
    public class WebMemberVouches
    {
        [JsonProperty("Wertstellung")]
        public DateTimeOffset Wertstellung { get; set; }

        [JsonProperty("Sum")]
        public double Sum { get; set; }

        [JsonProperty("Bekommen")]
        public double Bekommen { get; set; }

        [JsonProperty("Verbrauch")]
        public double Verbrauch { get; set; }
    }
}