// MCDB Client Beta
// StukInformationSystem.Data
// IAufgabe.cs
// 
// 11 04 2019
// 
// Katharina Bentsche

namespace StukInformationSystem.Data.Definitions.Common.Data.RawTables.Dienst {
    public interface IAufgabe {
        int ID { get; set; }
        string Name { get; set; }
        double AnzahlGS { get; set; }
    }
}