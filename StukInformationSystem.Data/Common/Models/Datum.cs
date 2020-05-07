using System;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models
{
    public class Datum
    {
        [JsonProperty("VVDatum")]
        public DateTime VvDatum { get; set; }
    }
}