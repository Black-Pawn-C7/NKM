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
    interface IWebActiveConsumptionTSelects
    {
        IResult<List<ConsumptionType>> SelectTResult();
    }
}