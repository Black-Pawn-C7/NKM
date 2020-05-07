// MCDB Client Beta
// StukInformationSystem.Data
// IAuswählenView.cs
// 
// 07 04 2019
// 
// Katharina Bentsche

using System.Collections.Generic;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Data.RawTables.Views;

namespace StukInformationSystem.Data.Definitions.Business.Data.RawTables.View {
    public interface IAuswählenView {
        IResult<List<AVView>> AVView();
    }
}