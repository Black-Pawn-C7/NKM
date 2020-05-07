using NKM.Base.Definition.Common.Result;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StukInformationSystem.Data.Common.Models;

namespace StukInformationSystem.Data.Definitions.Business.Data.Selects
{
    public interface IWebSelects
    {
        IResult<List<DienstFill>> GetValidityResult(int dienstId);
        IResult<List<WebVoucherOverview>> GetMitgliedIdByName(string mName);
        IResult<List<MemberTinyModel>> GetMitgliedNameById(int mId);
        IResult<List<WebVoucherOverview>> GetDoubleMitgliedByName(string mName);
    }
}