// MCDB Client Beta
// StukInformationSystem.Data
// Gutscheine.cs
// 
// 06 04 2019
// 
// Katharina Bentsche

using Newtonsoft.Json;
using StukInformationSystem.Data.Definitions.Common.Data.RawTables.Mitglieder;
using System;

namespace StukInformationSystem.Data.Common.Data.RawTables.Mitglieder {
    public class Gutscheine : IGutscheine {
        [JsonProperty("ID", Required = Required.Always)]
        public int ID { get; set; }

        [JsonProperty("MitgliederID", Required = Required.Always)]
        public int MID { get; set; }

        [JsonProperty("Buchungstext", Required = Required.Always)]
        public string Buchungstext { get; set; }

        [JsonProperty("Buchungstag", Required = Required.Always)]
        public DateTime Buchungstag { get; set; }

        [JsonProperty("Wertstellung", Required = Required.Always)]
        public DateTime Wertstellung { get; set; }

        [JsonProperty("Betrag", Required = Required.Always)]
        public double Betrag { get; set; }

        [JsonProperty("Geprüft")]
        public bool Geprüft { get; set; }

        [JsonProperty("DienstID", Required = Required.Always)]
        public int DienstID { get; set; }

        [JsonProperty("Bearbeiter", Required = Required.Always)]
        public int Bearbeiter { get; set; }

        [JsonProperty("Ersteller", Required = Required.Always)]
        public int Ersteller { get; set; }

        [JsonProperty("Stand", Required = Required.Always)]
        public DateTime Stand { get; set; }
    }
}