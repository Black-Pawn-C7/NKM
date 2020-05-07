using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models.Lager
{
    public class WebArtikelZaehlliste
    {
        [JsonProperty("ArtikelNr")]
        public int ArtikelNr { get; set; }

        [JsonProperty("Name")]
        public string ArtikelName { get; set; }

        [JsonProperty("Anreißer")]
        public bool Anreißer { get; set; }

        [JsonProperty("Voll")]
        public int Voll { get; set; }

        [JsonProperty("Offen")]
        public double Offen { get; set; }

        [JsonProperty("VollID")]
        public int VollId { get; set; }

        [JsonProperty("VollEinheit")]
        public string VollEinheit { get; set; }

        [JsonProperty("OffenID", NullValueHandling = NullValueHandling.Ignore)]
        public int? OffenId { get; set; }

        [JsonProperty("OffenEinheit", NullValueHandling = NullValueHandling.Ignore)]
        public string OffenEinheit { get; set; }
    }
}
