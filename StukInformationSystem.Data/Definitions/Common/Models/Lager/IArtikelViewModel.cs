using System;
using NKM.Base.Definition.Enums;

namespace StukInformationSystem.Data.Definitions.Common.Models.Lager {
    public interface IArtikelViewModel {
        int ID { get; set; }

        string Name { get; set; }

        int FirmenID { get; set; }

        string FirmenName { get; set; }

        double MengeVerkauf { get; set; }

        double Volumen { get; set; }

        double Ekp { get; set; }

        double Vkp { get; set; }

        double Cvkp { get; set; }

        double GsWert { get; set; }

        double Bestand { get; set; }

        double BestandMIN { get; set; }

        double BestandMAX { get; set; }

        int ArtikelArtID { get; set; }

        string ArtikelArt { get; set; }

        bool Inaktiv { get; set; }

        bool Deleted { get; set; }

        DateTime Stand { get; set; }

        int BearbeiterID { get; set; }

        string Bemerkung { get; set; }
        ItemRowState ItemState { get; set; }
    }
}