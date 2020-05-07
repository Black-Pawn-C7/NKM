using System;

namespace StukInformationSystem.Data.Definitions.Common.Models {
    public interface IMitgliedsbeitrag {
        int ID { get; set; }
        int MemberStatus { get; set; }
        double DienstSoll { get; set; }
        double AeSoll { get; set; }
        double SchulungSoll { get; set; }
        int AutoStatus { get; set; }
        string Bemerkung { get; set; }
        bool Inaktiv { get; set; }
        int Bearbeiter { get; set; }
        int Ersteller { get; set; }
        DateTime Stand { get; set; }
    }
}
