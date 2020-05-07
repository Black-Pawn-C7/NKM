using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models
{
    public class DienstIdModel
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("AVName")]
        public string AvName { get; set; }
    }
    public class DienstFill
    {
        [JsonProperty("SUM")]
        public int Sum { get; set; }

        [JsonProperty("Soll")]
        public int Soll { get; set; }

        [JsonProperty("Ist")]
        public int Ist { get; set; }
    }

    public class ConsumptionType
    {
        [JsonProperty("Type")]
        public int Type { get; set; }
    }
}
