using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NKM.Base.Definition.Enums;

namespace StukInformationSystem.Data.Common.Models.Admin {
    public class MemberDiensteAdminModel : INotifyPropertyChanged {

        private int id, mid, bearbeiter, ersteller, aufgabe, dienstid, gsid;
        private string bemerkung;
        private DateTime stand;
        private double multi, gutscheine;
        private bool putzen;

        [JsonProperty("ID", Required = Required.Always)]
        public int Id {
            get => id;
            set {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("MID", Required = Required.Always)]
        public int MID {
            get => mid;
            set {
                if (mid == value) return;
                mid = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Aufgabe", Required = Required.Always)]
        public int Aufgabe {
            get => aufgabe;
            set {
                if (aufgabe == value) return;
                aufgabe = value;
                OnPropertyChanged();
            }
        }
        [JsonProperty("multi", Required = Required.Always)]
        public double Multi {
            get => multi;
            set {
                if (multi == value) return;
                multi = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Putzen", Required = Required.Always)]
        public bool Putzen {
            get => putzen;
            set {
                if (putzen == value) return;
                putzen = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Gutscheine", Required = Required.Always)]
        public double Gutscheine {
            get => gutscheine;
            set {
                if (gutscheine == value) return;
                gutscheine = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("GSID", NullValueHandling = NullValueHandling.Ignore)]
        public int GsId { get=>gsid;
            set {
                if (gsid == value) return;
                gsid = value;
                OnPropertyChanged();
            } }

        [JsonProperty("DienstID", Required = Required.Always)]
        public int DienstId {
            get => dienstid;
            set {
                if(dienstid==value) return;
                dienstid = value;
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

        [JsonProperty("Bearbeiter", Required = Required.Always)]
        public int Bearbeiter {
            get => bearbeiter;
            set {
                if (bearbeiter == value) return;
                bearbeiter = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Ersteller", Required = Required.Always)]
        public int Ersteller {
            get => ersteller;
            set {
                if (ersteller == value) return;
                ersteller = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Stand", Required = Required.Always)]
        public DateTime Stand {
            get => stand;
            set {
                if (stand == value) return;
                stand = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public ItemRowState ItemState { get; set; }

        [JsonIgnore]
        public MemberDiensteAdminModel OrginalRowState { get; set; }

        public MemberDiensteAdminModel() { }
        public MemberDiensteAdminModel(int mid, int userid, int rid) {
            id = rid;
            MID = mid;
            Stand = DateTime.UtcNow;
            ItemState = ItemRowState.Added;
            Bearbeiter = userid;
            Ersteller = userid;
            Gutscheine = 0;
            Putzen = false;
            Multi = 1.0;
        }
        public static MemberDiensteAdminModel CreateNewMemberDienst() {
            return new MemberDiensteAdminModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}