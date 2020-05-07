using System;

namespace StukInformationSystem.Data.Definitions.Common.Models {
    public interface IMemberGutscheineViewModel {
        int ID { get; set; }
        int MID { get; set; }
        int? DienstID { get; set; }
        string Buchungstext { get; set; }
        DateTime Buchungstag { get; set; }
        double Betrag { get; set; }
        int? ListNummer { get; set; }
        string Bemerkung { get; set; }
        int Bearbeiter { get; set; }
        int Ersteller { get; set; }
        DateTime Stand { get; set; }
    }
}