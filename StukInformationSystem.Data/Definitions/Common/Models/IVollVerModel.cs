using System;

namespace StukInformationSystem.Data.Definitions.Common.Models {
    public interface IVollVerModel {
        int ID { get; set; }
        DateTime Datum { get; set; }
        bool WinterSemester { get; set; }
        int Bearbeiter { get; set; }
        DateTime Stand { get; set; }
    }
}