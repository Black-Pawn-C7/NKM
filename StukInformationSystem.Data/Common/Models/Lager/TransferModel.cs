using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace StukInformationSystem.Data.Common.Models.Lager {
    public class TransferItem {
        public TransferProduct Product { get; set; }
        public Bereiche From { get; set; }
        public Bereiche To { get; set; }
        public TransferProductMeta Meta { get; set; }

        public int Gebinde { get; set; }
        public double Lose { get; set; }

    }

    public class TransferProduct {
        [JsonProperty("ArtikelNr")]
        public int ArtikelNr { get; set; }
        [JsonProperty("Name")]
        public string ArtikelName { get; set; }

    }
    public class TransferProductMeta
    {
        [JsonProperty("Anreißer")]
        public bool Anreißer { get; set; }
        [JsonProperty("GebindeEinheit")]
        public string GebindeEinheit { get; set; }
        [JsonProperty("LoseEinheit")]
        public string LoseEinheit { get; set; }

    }
}

