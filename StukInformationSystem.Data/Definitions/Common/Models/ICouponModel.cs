using System;
using NKM.File.Definitions.Enums;

namespace StukInformationSystem.Data.Definitions.Common.Models {
    public interface ICouponModel {
        int MemberID { get; set; }
        DateTime Buchungstag { get; set; }
        DateTime Wertstellung { get; set; }
        int AufgabeID { get; set; }
        GutscheinType BuchungsArt { get; set; }
        int DienstID { get; set; }
        int Betrag { get; set; }
        DateTime Stand { get; set; }
        int Bearbeiter { get; set; }
    }
}