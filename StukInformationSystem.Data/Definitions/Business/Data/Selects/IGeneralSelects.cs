using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Models;
using StukInformationSystem.Data.Definitions.Common.Models;
using System;
using System.Collections.Generic;

namespace StukInformationSystem.Data.Definitions.Business.Data.Selects {
    public interface IGeneralSelects {
        IResult<DateTime> GetLastCouponBookingMonthForClubCouncil();
        IResult<int> GetClubCouncilBookingCount();
        IResult<List<ClubCouncilCouponModel>> GetClubCouncilForCouponBooking();
    }
}
