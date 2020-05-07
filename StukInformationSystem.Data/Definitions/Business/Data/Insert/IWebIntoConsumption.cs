using NKM.Base.Definition.Common.Result;
using NKM.Base.Common.Result;

namespace StukInformationSystem.Data.Definitions.Business.Data.Insert {
    public interface IWebIntoConsumption {
        IResult InsertConsumption(int did,int bereichId,int artikelId, int types,double amount);
    }
}
