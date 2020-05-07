using System;
using NKM.File.Definitions.Enums;
using StukInformationSystem.Data.Definitions.Common.Models;

namespace StukInformationSystem.Data.Common.Models {
    public class CouponModel : ICouponModel {
        public int MemberID { get; set; }
        public DateTime Buchungstag { get; set; }
        public DateTime Wertstellung { get; set; }
        public int AufgabeID { get; set; }
        public GutscheinType BuchungsArt { get; set; }
        public int DienstID { get; set; }
        public int Betrag { get; set; }
        public DateTime Stand { get; set; }
        public int Bearbeiter { get; set; }
    }
}