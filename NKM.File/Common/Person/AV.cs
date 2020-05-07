using System;

namespace NKM.File.Common.Person {
    [Serializable]
    public class AV : BaseMember {
        public int LoginID { get; set; }
        public string UserName { get; set; }
    }
}