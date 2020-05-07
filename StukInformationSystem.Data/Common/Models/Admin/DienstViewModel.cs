using System;
using Newtonsoft.Json;
using NKM.Base.Definition.Enums;

namespace StukInformationSystem.Data.Common.Models.Admin {
    public class DienstViewModel {
        [JsonProperty("DienstID", Required = Required.Always)]
        public int DienstId { get; set; }

        [JsonProperty("Datum", Required = Required.Always)]
        public DateTime Datum { get; set; }

        [JsonProperty("AV", Required = Required.Always)]
        public string Av { get; set; }

        [JsonProperty("AVID", Required = Required.Always)]
        public int Avid { get; set; }

        [JsonProperty("BV")] public string Bv { get; set; }

        [JsonProperty("BVID", Required = Required.Always)]
        public int Bvid { get; set; }

        [JsonProperty("Dienst Beginn", Required = Required.Always)]
        public DateTime DienstBeginn { get; set; }

        [JsonProperty("Dienst Ende")] public DateTime DienstEnde { get; set; }

        [JsonProperty("Abgeschlossen", Required = Required.Always)]
        public bool Abgeschlossen { get; set; }

        [JsonProperty("Bearbeiter", Required = Required.Always)]
        public string Bearbeiter { get; set; }

        [JsonProperty("BearbeiterID", Required = Required.Always)]
        public int BearbeiterId { get; set; }

        [JsonProperty("Stand", Required = Required.Always)]
        public DateTime Stand { get; set; }

        [JsonIgnore]
        public ItemRowState ItemState { get; set; }

        [JsonIgnore]
        public DienstViewModel OrginalRowState { get; set; }
    }
}