using System;
using Newtonsoft.Json;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Definitions.Common.Models;

namespace StukInformationSystem.Data.Common.Models {
    public class MemberViewDAGModel : IMemberViewDAGModel {
        [JsonProperty("ID", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("MID", Required = Required.Always)]
        public int MID { get; set; }

        [JsonProperty("Aufgabe", Required = Required.Always)]
        public int Aufgabe { get; set; }

        [JsonProperty("Datum", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Datum { get; set; }

        [JsonProperty("multi", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Multi { get; set; }

        [JsonProperty("Putzen", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Putzen { get; set; }

        [JsonProperty("Bemerkung", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public string Bemerkung { get; set; }

        [JsonProperty("LID", Required = Required.Always)]
        public int LID { get; set; }

        [JsonProperty("Gutscheine", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Gutscheine { get; set; }

        [JsonProperty("DienstID", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public int? DienstID { get; set; }

        [JsonProperty("Bearbeiter", Required = Required.Always)]
        public int Bearbeiter { get; set; }

        [JsonProperty("Ersteller", Required = Required.Always)]
        public int Ersteller { get; set; }

        [JsonProperty("Stand", Required = Required.Always)]
        public DateTime Stand { get; set; }

        [JsonIgnore]
        public ItemRowState ItemState { get; set; }

    }
}