using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models.Lager
{
    public class TransferTotal
    {
        [JsonProperty("ArtikelID")]
        public int ArtikelId { get; set; }

        [JsonProperty("BereichFrom")]
        public int BereichFrom { get; set; }

        [JsonProperty("BereichTo")]
        public int BereichTo { get; set; }

        [JsonProperty("GebindeTotal")]
        public int GebindeTotal { get; set; }

        [JsonProperty("LoseTotal")]
        public double LoseTotal { get; set; }

        [JsonProperty("GebindeID")]
        public int GebindeId { get; set; }

        [JsonProperty("LoseID")]
        public int LoseId { get; set; }

        [JsonProperty("Anreißer")]
        public bool Anreißer { get; set; }

        [JsonProperty("GebindeEinheit")]
        public string GebindeEinheit { get; set; }

        [JsonProperty("LoseEinheit")]
        public string LoseEinheit { get; set; }
    }
}
