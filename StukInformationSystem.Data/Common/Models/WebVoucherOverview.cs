using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StukInformationSystem.Data.Definitions.Common.Models;

namespace StukInformationSystem.Data.Common.Models
{
    public class WebVoucherOverview : IWebVoucherOverview
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("GSWert")]
        public double GSWert { get; set; }

        [JsonProperty("Aufgenomen", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Aufgenomen { get; set; }
    }
}
