using System;
using NKM.Base.Definition.Enums;

namespace StukInformationSystem.Data.Definitions.Common.Models {
    public interface IMemberFullModel {
        int Id { get; set; }

        string Vorname { get; set; }

        string Nachname { get; set; }

        string Spitzname { get; set; }

        string Geschlecht { get; set; }

        string Straße { get; set; }

        string Nummer { get; set; }

        string Plz { get; set; }

        string Wohnort { get; set; }

        DateTime? Geburtstag { get; set; }

        string EMail { get; set; }

        string Mobil { get; set; }

        string Status { get; set; }

        DateTime Aufgenomen { get; set; }

        bool? Student { get; set; }

        string Studienrichtung { get; set; }

        string Hochschule { get; set; }

        int? StatusId { get; set; }

        int? SexId { get; set; }

        bool? Inaktiv { get; set; }

        string Ersteller { get; set; }
        int ErstellerID { get; set; }

        int BearbeiterID { get; set; }
        string Bearbeiter { get; set; }

        string Bemerkung { get; set; }
        DateTime Stand { get; set; }

        ItemRowState ItemState { get; set; }
    }
}