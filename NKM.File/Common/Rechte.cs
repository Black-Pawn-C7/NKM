using System.Diagnostics;

namespace NKM.File.Common {
    public class Rights {
        public Rights(string Rechte) {
            switch (Rechte.Length) {
                case 1 when Rechte == "1":
                    Admin = true;
                    AV = true;
                    Lager = true;
                    Kasse = true;
                    Buchfuehrung = true;
                    Mitglieder = true;
                    Formalia = true;
                    Gastro = true;
                    Benutzer = true;
                    break;
                case 1:
                    Debug.WriteLine("Keine Rechte");
                    break;
                case 8: {
                    var @out = Rechte.ToCharArray();
                    AV = @out[0].Equals('1');
                    Mitglieder = @out[1].Equals('1');
                    Kasse = @out[2].Equals('1');
                    Buchfuehrung = @out[3].Equals('1');
                    Lager = @out[4].Equals('1');
                    Formalia = @out[5].Equals('1');
                    Gastro = @out[6].Equals('1');
                    Benutzer = @out[7].Equals('1');
                    Hausmeister = false;
                    break;
                }
                case 9: {
                    var @out = Rechte.ToCharArray();
                    Benutzer = @out[0].Equals('1');
                    AV = @out[1].Equals('1');
                    Mitglieder = @out[2].Equals('1');
                    Kasse = @out[3].Equals('1');
                    Buchfuehrung = @out[4].Equals('1');
                    Lager = @out[5].Equals('1');
                    Formalia = @out[6].Equals('1');
                    Gastro = @out[7].Equals('1');
                    Hausmeister = @out[8].Equals('1');
                    break;
                }
                default:
                    Debug.WriteLine("Keine Rechte, oder inkompatible Version");
                    break;
            }
        }

        public bool Admin { get; set; }
        public bool AV { get; set; }
        public bool Lager { get; set; }
        public bool Kasse { get; set; }
        public bool Buchfuehrung { get; set; }
        public bool Mitglieder { get; set; }
        public bool Formalia { get; set; }
        public bool Gastro { get; set; }
        public bool Benutzer { get; set; }
        public bool Hausmeister { get; set; }

        public string GetRights {
            get {
                var b = "";
                if (Admin) return "1";

                if (Benutzer)
                    b += "1";
                else
                    b += "0";
                if (AV)
                    b += "1";
                else
                    b += "0";
                if (Mitglieder)
                    b += "1";
                else
                    b += "0";
                if (Kasse)
                    b += "1";
                else
                    b += "0";
                if (Buchfuehrung)
                    b += "1";
                else
                    b += "0";
                if (Lager)
                    b += "1";
                else
                    b += "0";
                if (Formalia)
                    b += "1";
                else
                    b += "0";
                if (Gastro)
                    b += "1";
                else
                    b += "0";
                if (Hausmeister)
                    b += "1";
                else
                    b += "0";
                return b;
            }
        }
    }
}