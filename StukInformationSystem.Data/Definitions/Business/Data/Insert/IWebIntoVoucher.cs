using NKM.Base.Definition.Common.Result;
using NKM.Base.Common.Result;

namespace StukInformationSystem.Data.Definitions.Business.Data.Insert {
    public interface IWebIntoVoucher {
        IResult InsertVoucher(double Menge,int MitgliederID, int DienstID, int BereichID);
    }
}
