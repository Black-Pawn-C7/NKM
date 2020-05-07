using NKM.Base.Definition.Common.Result;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StukInformationSystem.Data.Definitions.Business {
    public interface IFromSettings {
        IResult<Stream> SettingsMemberContribution(int dataID);
    }
}
