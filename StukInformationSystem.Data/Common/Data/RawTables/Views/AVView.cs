// MCDB Client Beta
// StukInformationSystem.Data
// AV_View.cs
// 
// 07 04 2019
// 
// Katharina Bentsche

using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Data.RawTables.Views {
    public class AVView {
        [JsonProperty("Name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("Geschlecht", Required = Required.Always)]
        public string Geschlecht { get; set; }

        [JsonProperty("Spitzname")]
        public string Spitzname { get; set; }

        [JsonProperty("Studienrichtung")]
        public string Studienrichtung { get; set; }

        [JsonProperty("Vereins Status", Required = Required.Always)]
        public string VereinsStatus { get; set; }

        [JsonProperty("Archiv", Required = Required.Always)]
        public bool Archiv { get; set; }

        [JsonProperty("ID", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("SexID", Required = Required.Always)]
        public int SexId { get; set; }

        [JsonProperty("Student")]
        public bool Student { get; set; }

        [JsonProperty("StatusID", Required = Required.Always)]
        public int StatusId { get; set; }
    }
}