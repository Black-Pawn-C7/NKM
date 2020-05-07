// MCDB Client Beta
// StukInformationSystem.Data
// Aufgabe.cs
// 
// 11 04 2019
// 
// Katharina Bentsche

using Newtonsoft.Json;
using StukInformationSystem.Data.Definitions.Common.Data.RawTables.Dienst;

namespace StukInformationSystem.Data.Common.Data.RawTables.Dienst {
    public class Aufgabe : IAufgabe{
        [JsonProperty("ID", Required = Required.Always)]
        public int ID { get; set; }
        [JsonProperty("Name", Required = Required.Always)]
        public string Name { get; set; }
        [JsonProperty("AnzahlGS", Required = Required.Always)]
        public double AnzahlGS { get; set; }
    }
}