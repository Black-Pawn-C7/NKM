using System.Collections.Generic;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Models;

namespace StukInformationSystem.Data.Definitions.Business.Data.Selects {
    public interface IWebMemberSelects {
        IResult<List<MemberBeitragOverview>> GetMitgliedOverview(int mId);
    }
}