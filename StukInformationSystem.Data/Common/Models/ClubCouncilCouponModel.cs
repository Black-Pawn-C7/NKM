using Newtonsoft.Json;
using StukInformationSystem.Data.Definitions.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StukInformationSystem.Data.Common.Models {
    public class ClubCouncilCouponModel : IClubCouncilCouponModel {
        [JsonProperty("MID")]
        public int MemberID { get; set; }
        [JsonProperty("Name")]
        public string MemberName { get; set; }
        [JsonProperty("Posten")]
        public int CouncilID { get; set; }
        [JsonProperty("PostenName")]
        public string CouncilName { get; set; }
        [JsonProperty("GS")]
        public double CouponValue { get; set; }
        [JsonIgnore]
        public string BookingString { get; set; }
        [JsonIgnore]
        public DateTime Wertstellung { get; set; }
    }
}
