using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKM.Base.Definition.Common.Result;
using System.IO;

namespace StukInformationSystem.Data.Definitions.Business.Data.Update {
    public interface ISetSettings {
        IResult UpdateSettingsMemberContribution(Stream dataStream, string name);
        IResult UpdateSettingsMemberContribution(Stream dataStream, int id);
    }
}
