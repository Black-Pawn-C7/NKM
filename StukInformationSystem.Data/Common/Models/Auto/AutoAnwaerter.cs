using StukInformationSystem.Data.Definitions.Common.Models.Auto;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models.Auto
{
   public class AutoAnwaerter : IAutoAnwaerter
    {
        [JsonProperty("ID", Required = Required.Always)]
        public int ID { get; set; }

        [JsonProperty("MID", Required = Required.Always)]
        public int MID { get; set; }

        [JsonProperty("Anzahl", Required = Required.Always)]
        public double Anzahl { get; set; }
    }
}
