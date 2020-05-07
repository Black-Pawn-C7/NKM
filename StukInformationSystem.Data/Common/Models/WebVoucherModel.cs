using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models
{
    public class VoucherWorth
    {
        [JsonProperty("ArtikelNR")]
        public int ArtikelNr { get; set; }

        [JsonProperty("MengeVerkauf")]
        public decimal MengeVerkauf { get; set; }

        [JsonProperty("Volumen")]
        public decimal Volumen { get; set; }

        [JsonProperty("GsWert")]
        public double GsWert { get; set; }
    }
    
}
