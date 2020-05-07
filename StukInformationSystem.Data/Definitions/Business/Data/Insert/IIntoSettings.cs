using NKM.Base.Definition.Common.Result;
using System.IO;

namespace StukInformationSystem.Data.Definitions.Business.Data.Insert {
    public interface IIntoSettings {
        IResult InsertSettingsMemberContribution(Stream dataStream, int id, string name);
    }
}
