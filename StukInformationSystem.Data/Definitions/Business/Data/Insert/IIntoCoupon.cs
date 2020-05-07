using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKM.Base.Definition.Common.Result;
using NKM.File.Common.Person;
using StukInformationSystem.Data.Common.Models;

namespace StukInformationSystem.Data.Definitions.Business.Data.Insert {
    public interface IIntoCoupon {
        IResult InsertCouponForMember(ClubCouncilCouponModel couponItem);
        IResult InsertCouponForMember(int memberID, string buchungstext, DateTime buchungsTag, double betrag);
        IResult InsertCouponForMember(int memberID, string buchungstext, DateTime buchungsTag, DateTime wertTag, double betrag, int userID);
        IResult InsertCouponForMember(int memberID, string buchungstext, DateTime buchungsTag, DateTime wertTag, double betrag, int userID, int dienstID);
        IResult InsertCouponForMember(int memberID, string buchungstext, DateTime buchungsTag, DateTime wertTag, double betrag, User user);
        IResult InsertCouponForMember(int memberID, string buchungstext, DateTime buchungsTag, DateTime wertTag, double betrag, User user, int dienstID);
    }
}
