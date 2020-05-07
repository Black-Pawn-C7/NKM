using System;
using Newtonsoft.Json;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Definitions.Common.Models.Lager;

namespace StukInformationSystem.Data.Common.Models.Lager {
    public class ArtikelViewModel : IArtikelViewModel {
        [JsonProperty("ArtikelNr", Required = Required.Always)]
        public int ID { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("FirmenID", Required = Required.Always)]
        public int FirmenID { get; set; }

        [JsonProperty("FirmaName", Required = Required.Always)]
        public string FirmenName { get; set; }

        [JsonProperty("MengeVerkauf", Required = Required.Always)]
        public double MengeVerkauf { get; set; }

        [JsonProperty("Volumen", Required = Required.Always)]
        public double Volumen { get; set; }

        [JsonProperty("EKP", Required = Required.Always)]
        public double Ekp { get; set; }

        [JsonProperty("VKP", Required = Required.Always)]
        public double Vkp { get; set; }

        [JsonProperty("CVKP", Required = Required.Always)]
        public double Cvkp { get; set; }

        [JsonProperty("GSWert", Required = Required.Always)]
        public double GsWert { get; set; }

        [JsonProperty("Bestand", Required = Required.Always)]
        public double Bestand { get; set; }

        [JsonProperty("MinBestand", Required = Required.Always)]
        public double BestandMIN { get; set; }

        [JsonProperty("MaxBestand", Required = Required.Always)]
        public double BestandMAX { get; set; }

        [JsonProperty("ArtikelArtID", Required = Required.Always)]
        public int ArtikelArtID { get; set; }

        [JsonProperty("ArtikelArt", Required = Required.Always)]
        public string ArtikelArt { get; set; }

        [JsonProperty("inaktiv", Required = Required.Always)]
        public bool Inaktiv { get; set; }

        [JsonProperty("Deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("Stand", Required = Required.Always)]
        public DateTime Stand { get; set; }

        [JsonProperty("Bearbeiter", Required = Required.Always)]
        public string Bearbeiter { get; set; }

        [JsonProperty("BearbeiterID", Required = Required.Always)]
        public int BearbeiterID { get; set; }

        [JsonProperty("Bemerkung")]
        public string Bemerkung { get; set; }

        [JsonIgnore]
        public string Ersteller { get; set; } //Todo Implement this on sql query

        [JsonIgnore]
        public ItemRowState ItemState { get; set; }
    }
}