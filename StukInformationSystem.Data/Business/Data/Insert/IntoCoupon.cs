using NKM.Base.Definition.Common.Result;
using NKM.File.Common.Person;
using StukInformationSystem.Data.Common.Models;
using StukInformationSystem.Data.Definitions.Business.Data.Insert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StukInformationSystem.Data.Business.Data.Insert {
    public class IntoCoupon : IIntoCoupon {
        public IResult InsertCouponForMember(int memberID, string buchungstext, DateTime buchungsTag, double betrag) {
            throw new NotImplementedException();
        }

        public IResult InsertCouponForMember(int memberID, string buchungstext, DateTime buchungsTag, DateTime wertTag, double betrag, int userID) {
            throw new NotImplementedException();
        }

        public IResult InsertCouponForMember(int memberID, string buchungstext, DateTime buchungsTag, DateTime wertTag, double betrag, int userID, int dienstID) {
            throw new NotImplementedException();
        }

        public IResult InsertCouponForMember(int memberID, string buchungstext, DateTime buchungsTag, DateTime wertTag, double betrag, User user) {
            throw new NotImplementedException();
        }

        public IResult InsertCouponForMember(int memberID, string buchungstext, DateTime buchungsTag, DateTime wertTag, double betrag, User user, int dienstID) {
            throw new NotImplementedException();
        }

        public IResult InsertCouponForMember(ClubCouncilCouponModel couponItem) {
            throw new NotImplementedException();
        }
    }
}
