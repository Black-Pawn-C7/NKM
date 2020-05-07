using System.Collections.Generic;
using System.ComponentModel;
using NKM.Base.Definition.Common.Result;
using NKM.File.Common.Person;
using StukInformationSystem.Data.Common.Models;
using StukInformationSystem.Data.Common.Models.Admin;
using StukInformationSystem.Data.Common.Models.Auto;

namespace StukInformationSystem.Data.Definitions.Select {
    public interface IMitglieder {
        IResult<BaseMember> Member_Base(int memberId);

        IResult<List<MemberViewDAModel>> MemberDienstAE();

        IResult<List<MemberViewDAGModel>> MemberDienstAufgabeGutscheine();

        IResult<List<MemberFullModel>> MemberViewFull();

        IResult<BindingList<MemberGutscheineViewModel>> MemberGutscheine();
        IResult<BindingList<MemberGutscheineModel>> MemberGutscheine(int dienstId);
        IResult<List<AutoAnwaerter>> Auto_AnwaerterStatusMember();
        IResult<List<NotVerifiedAnwärter>> Manual_NotVerifiedMember_GotAnwärterStatus();
    }
}