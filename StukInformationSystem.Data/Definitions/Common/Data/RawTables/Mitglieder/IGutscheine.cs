// MCDB Client Beta
// StukInformationSystem.Data
// IGutscheine.cs
// 
// 06 04 2019
// 
// Katharina Bentsche

using System;

namespace StukInformationSystem.Data.Definitions.Common.Data.RawTables.Mitglieder {
    public interface IGutscheine  {
        int ID { get; set; }

        int MID { get; set; }

        string Buchungstext { get; set; }

        DateTime Buchungstag { get; set; }

        DateTime Wertstellung { get; set; }

        double Betrag { get; set; }

        bool Geprüft { get; set; }

        int DienstID { get; set; }

        int Bearbeiter { get; set; }
        int Ersteller { get; set; }

        DateTime Stand { get; set; }
    }
}