using System.Collections.Generic;
using Newtonsoft.Json;

namespace StukInformationSystem.Data.Common.Models
{
    public class MemberBeitragOverview
    {
        [JsonProperty("GsWert")]
        public double GsWert { get; set; }

        [JsonProperty("Semester")]
        public Gesamt Semester { get; set; }

        [JsonProperty("Gesamt")]
        public Gesamt Gesamt { get; set; }

    }

    public class Gesamt
    {
        [JsonProperty("Zusammenfassung")]
        public List<Zusammenfassung> Zusammenfassung { get; set; }

        [JsonProperty("Tage")]
        public List<Tage> Tage { get; set; }

        [JsonProperty("Dienste")]
        public List<Dienste> Dienste { get; set; }
    }

    public class Dienste
    {
        [JsonProperty("Anzahl")]
        public double Anzahl { get; set; }

        [JsonProperty("Dienst")]
        public string Dienst { get; set; }
    }

    public class Tage
    {
        [JsonProperty("Tag")]
        public string Tag { get; set; }

        [JsonProperty("Anzahl")]
        public double Anzahl { get; set; }
    }

    public class Zusammenfassung
    {
       [JsonProperty("Dienste")]
        public double Dienste { get; set; }

        [JsonProperty("AE")]
        public int Ae { get; set; }

        [JsonProperty("Schulung")]
        public int Schulung { get; set; }
    }

    public class MemberAmountCount
    {
        [JsonProperty("Amount")]
        public double Amount { get; set; }
    }
}