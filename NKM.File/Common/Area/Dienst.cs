using System;
using System.Collections.Generic;
using System.Linq;
using NKM.File.Common.Person;
using NKM.File.Definitions.Common.Area;
using NKM.File.Definitions.Common.Dienst;
using NKM.File.Definitions.Common.Person;

namespace NKM.File.Common.Area {
    [Serializable]
    public class Dienst : IDienst {
        public Dienst() {
            DayOfAbend = DateTime.UtcNow;
        }
        public Guid ID { get; set; }
        public int DienstID { get; set; }
        public IMemberShort ProbeAV { get; set; }
        public DateTime DayOfAbend { get; set; }
        public string VeranstaltungName { get; set; }
        public AV AV { get; set; }
        public IList<ILocalDienste> Dienste { get; set; }
        public byte[] BarVerbrauch { get; set; }
        public byte[] GutscheinVerbrauch { get; set; }
        public string ProgramVersion { get; set; }
        public IList<IBereich> Bereiche { get; set; }
        public bool PrivatParty { get; set; }

        public bool IsDienstag() {
            return DayOfAbend.DayOfWeek == DayOfWeek.Tuesday;
        }

        public bool IsBereichSet(int bereichId) {
            return Bereiche.FirstOrDefault(x => x.BereichID == bereichId) != null;
        }

        public bool IsWechselGeldSet() {
            return Bereiche.All(x => x?.Abrechnung?.Wechselgeld != 0d);
        }

        public double GetGeldInWechselgeldKasse() {
            return Bereiche.First(x => x.Abrechnung.WechselgeldKasse != 0d)?.Abrechnung.WechselgeldKasse ?? 0d;
        }
    }
}