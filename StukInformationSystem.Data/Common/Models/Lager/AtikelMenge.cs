using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models.Lager
{
    public class ArtikelMenge
    {
        [JsonProperty("ArtikelID")]
        public int ArtikelId { get; set; }

        [JsonProperty("Menge")]
        public double Menge { get; set; }
    }
}
