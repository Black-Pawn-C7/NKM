using Newtonsoft.Json;
using NKM.Base.Definition.Enums;
using NKM.File.Common.Person;
using NKM.File.Definitions.Common.Dienst;
using NKM.File.Definitions.Common.Person;
using StukInformationSystem.Data.Definitions.Common.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace StukInformationSystem.Data.Common.Models.Admin {
    public class MemberGutscheineModel : IMemberGutscheineViewModel, INotifyPropertyChanged {

        private int id, mid, bearbeiter, ersteller;
        private string bemerkung, buchungstext;
        private DateTime stand, buchungstag;
        private int? dienstid, listnummer;
        private double betrag;
        private bool isDeserializing = false;

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

        [OnDeserializing]
        internal void OnDeserializingMethod(StreamingContext context) {
            isDeserializing = true;
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context) {
            isDeserializing = false;
        }

        [JsonIgnore]
        public ItemRowState ItemState { get; set; }

        [JsonIgnore]
        public MemberGutscheineModel OrginalRowState { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            if (isDeserializing) return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            ItemState = ItemState != ItemRowState.Added ? ItemRowState.Modified : ItemRowState.Added;
        }


        public MemberGutscheineModel() {
            ItemState = ItemRowState.Unchanged;
        }
        public MemberGutscheineModel(int nid, IMemberShort member, int did, User user) {
            id = nid;
            mid = member.MemberID;
            betrag = 0;
            buchungstext = "";
            dienstid = did;
            bearbeiter = user.LoginID;
            ersteller = user.LoginID;
            listnummer = 0;
            bemerkung = "";
            buchungstag = DateTime.Today;
            stand = DateTime.UtcNow;
            ItemState = ItemRowState.Added;
        }
        public MemberGutscheineModel(int nid, int member, double gs, string butext, int did, User user) {
            id = nid;
            mid = member;
            betrag = gs;
            buchungstext = butext;
            dienstid = did;
            bearbeiter = user.LoginID;
            ersteller = user.LoginID;
            listnummer = 0;
            bemerkung = "";
            buchungstag = DateTime.Today;
            stand = DateTime.UtcNow;
            ItemState = ItemRowState.Added;
        }
        public MemberGutscheineModel(int nid, int member, double gs, string butext, IMasterDienst dienst, User user) {
            id = nid;
            mid = member;
            betrag = gs;
            buchungstext = butext;
            dienstid = dienst.DienstID;
            bearbeiter = user.LoginID;
            ersteller = user.LoginID;
            listnummer = 0;
            bemerkung = "";
            buchungstag = dienst.Beginn;
            stand = DateTime.UtcNow;
            ItemState = ItemRowState.Added;
        }

    }
}