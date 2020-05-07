using System;
using NKM.Base.Definition.Enums;

namespace StukInformationSystem.Data.Definitions.Common.Models {
    public interface IMemberViewDAGModel {
        int Id { get; set; }

        int MID { get; set; }

        int Aufgabe { get; set; }

        DateTime Datum { get; set; }

        decimal? Multi { get; set; }

        bool? Putzen { get; set; }

        string Bemerkung { get; set; }

        int LID { get; set; }

        decimal? Gutscheine { get; set; }

        int? DienstID { get; set; }

        int Bearbeiter { get; set; }
        int Ersteller { get; set; }

        DateTime Stand { get; set; }

        ItemRowState ItemState { get; set; }
    }
}