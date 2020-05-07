using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StukInformationSystem.Data.Definitions.Common.Models {
    public interface IClubCouncilCouponModel {
        int MemberID { get; set; }
        string MemberName { get; set; }
        int CouncilID { get; set; }
        string CouncilName { get; set; }
        double CouponValue { get; set; }
        string BookingString { get; set; }
        DateTime Wertstellung { get; set; }
    }
}
