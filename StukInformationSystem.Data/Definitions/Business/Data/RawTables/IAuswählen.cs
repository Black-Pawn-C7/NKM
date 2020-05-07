// MCDB Client Beta
// StukInformationSystem.Data
// IValita.cs
// 
// 06 04 2019
// 
// Katharina Bentsche

using System.Collections.Generic;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Data.RawTables.Dienst;
using StukInformationSystem.Data.Common.Data.RawTables.Mitglieder;

namespace StukInformationSystem.Data.Definitions.Business.Data.RawTables {
    public interface IAuswählen {
        IResult<List<Gutscheine>> MitgliederGutscheine();
        IResult<List<Gutscheine>> MitgliederGutschein(int id);

        IResult<List<Aufgabe>> DienstAufgabe();
    }
}