using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Definitions.Common.Models.Lager;

namespace StukInformationSystem.Data.Common.Models.Lager {
    public class ArtikelViewModelWeb : IArtikelViewModel {
        [JsonProperty("ArtikelNr", Required = Required.Always)]
        public int ID { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("FirmenID", Required = Required.DisallowNull)]
        public int FirmenID { get; set; }

        [JsonProperty("FirmaName",  Required = Required.DisallowNull)]
        public string FirmenName { get; set; }

        [JsonProperty("MengeVerkauf", Required = Required.Always)]
        public double MengeVerkauf { get; set; }

        [JsonProperty("Volumen",  Required = Required.DisallowNull)]
        public double Volumen { get; set; }

        [JsonProperty("EKP",  Required = Required.DisallowNull)]
        public double Ekp { get; set; }

        [JsonProperty("VKP",  Required = Required.DisallowNull)]
        public double Vkp { get; set; }

        [JsonProperty("CVKP",  Required = Required.DisallowNull)]
        public double Cvkp { get; set; }

        [JsonProperty("GSWert", Required = Required.Always)]
        public double GsWert { get; set; }

        [JsonProperty("Bestand",  Required = Required.DisallowNull)]
        public double Bestand { get; set; }

        [JsonProperty("MinBestand",  Required = Required.DisallowNull)]
        public double BestandMIN { get; set; }

        [JsonProperty("MaxBestand",  Required = Required.DisallowNull)]
        public double BestandMAX { get; set; }

        [JsonProperty("ArtikelArtID", Required = Required.DisallowNull)]
        public int ArtikelArtID { get; set; }

        [JsonProperty("ArtikelArt",  Required = Required.DisallowNull)]
        public string ArtikelArt { get; set; }

        [JsonProperty("inaktiv", Required = Required.DisallowNull)]
        public bool Inaktiv { get; set; }

        [JsonProperty("Deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("Stand",  Required = Required.DisallowNull)]
        public DateTime Stand { get; set; }

        [JsonProperty("Bearbeiter",  Required = Required.DisallowNull)]
        public string Bearbeiter { get; set; }

        [JsonProperty("BearbeiterID",  Required = Required.DisallowNull)]
        public int BearbeiterID { get; set; }

        [JsonIgnore]
        public string Bemerkung { get; set; }

        [JsonIgnore]
        public string Ersteller { get; set; } //Todo Implement this on sql query

        [JsonIgnore]
        public ItemRowState ItemState { get; set; }
    }
}