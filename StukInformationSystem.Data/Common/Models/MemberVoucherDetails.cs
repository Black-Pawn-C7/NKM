using System;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models
{
    public class MemberVoucherDetails
    {
        [JsonProperty("Wertstellung")]
        public DateTimeOffset Wertstellung { get; set; }

        [JsonProperty("Betrag")]
        public double Betrag { get; set; }

        [JsonProperty("Buchungstext")]
        public string Buchungstext { get; set; }

        [JsonProperty("AV")]
        public string Av { get; set; }
    }
}