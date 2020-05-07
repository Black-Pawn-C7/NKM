using System.Collections.Generic;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Definitions.Common.Models;

namespace StukInformationSystem.Data.Definitions.Business.Worker {
    public interface INewCouponWorker {
        IResult WorkOnNewCoupon(IList<ICouponModel> couponModels);
    }
}