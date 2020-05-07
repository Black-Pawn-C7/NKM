using Newtonsoft.Json;
using StukInformationSystem.Data.Definitions.Business.Data.Selects.Lager;

namespace StukInformationSystem.Data.Common.Models.Lager
{
    public class ArtikelGebindeMulti : IArtikelGebindeMulti
    {
        [JsonProperty("1")]
        public double The1 { get; set; }

        [JsonProperty("3")]
        public double The3 { get; set; }

        [JsonProperty("4")]
        public double The4 { get; set; }

        [JsonProperty("5")]
        public double The5 { get; set; }

        [JsonProperty("ArtikelNr")]
        public int ArtikelNr { get; set; }
    }
}