// MCDB Client Beta
// StukInformationSystem.Data
// IAuswählenView.cs
// 
// 09 04 2019
// 
// Katharina Bentsche

using System.Collections.Generic;
using System.ComponentModel;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Models.EditDienst;

namespace StukInformationSystem.Data.Definitions.Business.Data.Selects.Admin {
    public interface IAuswählenAdmin {
        IResult<List<BarVerbrauchModel>> BarVerbrauchAdmin(int dienstId);

        IResult<BindingList<AbendAbrechnungModel>> AbendAbrechnungAdmin(int dienstId);
    }
}