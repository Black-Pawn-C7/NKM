using System;
using Newtonsoft.Json;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Definitions.Common.Models;

namespace StukInformationSystem.Data.Common.Models {
    public class MemberFullModel : IMemberFullModel {
        public string Ersteller { get; set; } //Todo Implement this on sql query

        public string Bemerkung { get; set; }//Todo Implement this on sql query

        [JsonProperty("ID", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("Vorname", Required = Required.Always)]
        public string Vorname { get; set; }

        [JsonProperty("Nachname", Required = Required.Always)]
        public string Nachname { get; set; }

        [JsonProperty("Spitzname", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public string Spitzname { get; set; }

        [JsonProperty("Geschlecht", Required = Required.Always)]
        public string Geschlecht { get; set; }

        [JsonProperty("Straße", Required = Required.Always)]
        public string Straße { get; set; }

        [JsonProperty("Nummer", Required = Required.Always)]
        public string Nummer { get; set; }

        [JsonProperty("PLZ", Required = Required.Always)]
        public string Plz { get; set; }

        [JsonProperty("Wohnort", Required = Required.Always)]
        public string Wohnort { get; set; }

        [JsonProperty("Geburtstag", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Geburtstag { get; set; }

        [JsonProperty("E-Mail", Required = Required.Always)]
        public string EMail { get; set; }

        [JsonProperty("Mobil", Required = Required.Always)]
        public string Mobil { get; set; }

        [JsonProperty("Status", Required = Required.Always)]
        public string Status { get; set; }

        [JsonProperty("Aufgenomen", Required = Required.Always)]
        public DateTime Aufgenomen { get; set; }

        [JsonProperty("Student", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Student { get; set; }

        [JsonProperty("Studienrichtung", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public string Studienrichtung { get; set; }

        [JsonProperty("Hochschule", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public string Hochschule { get; set; }

        [JsonProperty("StatusID", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public int? StatusId { get; set; }

        [JsonProperty("SexID", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public int? SexId { get; set; }

        [JsonProperty("inaktiv", Required = Required.Always, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Inaktiv { get; set; }

        [JsonProperty("ErstellerID", Required = Required.Always)]
        public int ErstellerID { get; set; }

        [JsonProperty("BearbeiterID", Required = Required.Always)]
        public int BearbeiterID { get; set; }
        [JsonProperty("Bearbeiter", Required = Required.Always)]
        public string Bearbeiter { get; set; }

        [JsonProperty("Stand", Required = Required.Always)]
        public DateTime Stand { get; set; }

        [JsonIgnore] public ItemRowState ItemState { get; set; }
    }
}