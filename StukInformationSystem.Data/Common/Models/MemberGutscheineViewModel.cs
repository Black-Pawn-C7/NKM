using Newtonsoft.Json;
using StukInformationSystem.Data.Definitions.Common.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;


namespace StukInformationSystem.Data.Common.Models {
    public class MemberGutscheineViewModel : IMemberGutscheineViewModel, INotifyPropertyChanged {

        private int id, mid, bearbeiter, ersteller;
        private string bemerkung, buchungstext;
        private DateTime stand, buchungstag;
        private int? dienstid, listnummer;
        private double betrag;

        [JsonProperty("ID", Required = Required.DisallowNull)]
        public int ID {
            get => id;
            set {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("MID", Required = Required.DisallowNull)]
        public int MID {
            get => mid;
            set {
                if (mid == value) return;
                mid = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Buchungstext", Required = Required.DisallowNull)]
        public string Buchungstext {
            get => buchungstext;
            set {
                if (buchungstext == value) return;
                buchungstext = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Buchungstag", Required = Required.DisallowNull)]
        public DateTime Buchungstag {
            get => buchungstag;
            set {
                if (buchungstag == value) return;
                buchungstag = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Betrag", Required = Required.DisallowNull)]
        public double Betrag {
            get => betrag;
            set {
                if (betrag == value) return;
                betrag = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Bearbeiter", Required = Required.DisallowNull)]
        public int Bearbeiter {
            get => bearbeiter;
            set {
                if (bearbeiter == value) return;
                bearbeiter = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("DienstID")]
        public int? DienstID {
            get => dienstid;
            set {
                if (dienstid == value) return;
                dienstid = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("ListNummer")]
        public int? ListNummer {
            get => listnummer;
            set {
                if (listnummer == value) return;
                listnummer = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Bemerkung")]
        public string Bemerkung {
            get => bemerkung;
            set {
                if (bemerkung == value) return;
                bemerkung = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Ersteller", Required = Required.DisallowNull)]
        public int Ersteller {
            get => ersteller;
            set {
                if (ersteller == value) return;
                ersteller = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Stand", Required = Required.DisallowNull)]
        public DateTime Stand {
            get => stand;
            set {
                if (stand == value) return;
                stand = value;
                OnPropertyChanged();
            }
        }

        public static MemberGutscheineViewModel CreateNewMemberDienst() {
            return new MemberGutscheineViewModel();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}