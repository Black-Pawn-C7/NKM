using System.Collections.Generic;
using System.ComponentModel;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Models.Admin;

namespace StukInformationSystem.Data.Definitions.Business.Data.Selects.Admin {
    public interface IDienstAdminViewEdit {
        IResult<List<DienstViewModel>> DiensteAdmin();

        IResult<BindingList<MemberDiensteAdminModel>> MemberSpecificDienstAdmin(int dienstId);

        IResult<BindingList<MemberDiensteAdminModel>> MemberDiensteAdmin();
    }
}