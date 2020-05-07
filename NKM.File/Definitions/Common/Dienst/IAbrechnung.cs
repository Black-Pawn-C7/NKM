using NKM.File.Common.Person;

namespace NKM.File.Definitions.Common.Dienst {
    public interface IAbrechnung {
        int Id { get; set; }
        BaseMember Member { get; set; }

        double Wechselgeld { get; set; }
        double BargeldInKasse { get; set; }
        double BargeldNachDienst { get; set; }
        double EinnahmeBargeld { get; set; }
        double Belege { get; set; }

        double WechselgeldKasse { get; set; }

        double Gesamt { get; set; }

        bool Gedruckt { get; set; }
    }
}