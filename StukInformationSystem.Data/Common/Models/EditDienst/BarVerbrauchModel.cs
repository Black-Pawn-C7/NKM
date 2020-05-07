// MCDB Client Beta
// StukInformationSystem.Data
// BarVerbrauchforDienstModel.cs
// 
// 08 04 2019
// 
// Katharina Bentsche

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Annotations;
using StukInformationSystem.Data.Definitions.Common.Data;

namespace StukInformationSystem.Data.Common.Models.EditDienst {
    public class BarVerbrauchModel : IModelStatefull, INotifyPropertyChanged {

        private int id, artikelid, barid, bearbeiterid, dienstid;
        private string artikelname, barname, bearbeiter;
        private DateTime stand;
        private double alt, vor, zugang, nach, frei;

        [JsonProperty("ID", Required = Required.Always)]
        public int Id {
            get => id;
            set {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("BarName", Required = Required.Always)]
        public string BarName {
            get => barname;
            set {
                if (barname == value) return;
                barname = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("BarID", Required = Required.Always)]
        public int BarId {
            get => barid;
            set {
                if (barid == value) return;
                barid = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("ArtikelID", Required = Required.Always)]
        public int ArtikelId {
            get => artikelid;
            set {
                if (artikelid == value) return;
                artikelid = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("ArtikelName", Required = Required.Always)]
        public string ArtikelName {
            get => artikelname;
            set {
                if (artikelname == value) return;
                artikelname = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Alt", Required = Required.Always)]
        public double Alt {
            get => alt;
            set {
                if (alt == value) return;
                alt = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("EKP", Required = Required.Always)]
        public double EKP { get; set; }

        [JsonProperty("VKP", Required = Required.Always)]
        public double VKP { get; set; }

        [JsonProperty("Vor", Required = Required.Always)]
        public double Vor {
            get => vor;
            set {
                if (vor == value) return;
                vor = value;
                SummeCalc();
                OnPropertyChanged();
            }
        }

        [JsonProperty("Zugang", Required = Required.Always)]
        public double Zugang {
            get => zugang;
            set {
                if (zugang == value) return;
                zugang = value;
                SummeCalc();
                OnPropertyChanged();
            }
        }

        [JsonProperty("Nach", Required = Required.Always)]
        public double Nach {
            get => nach;
            set {
                if (nach == value) return;
                nach = value;
                SummeCalc();
                OnPropertyChanged();
            }
        }

        [JsonProperty("Frei", Required = Required.Always)]
        public double Frei {
            get => frei;
            set {
                if (frei == value) return;
                frei = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("DienstID", Required = Required.Always)]
        public int DienstId {
            get => dienstid;
            set {
                if (dienstid == value) return;
                dienstid = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("BearbeiterID", Required = Required.Always)]
        public int BearbeiterId {
            get => bearbeiterid;
            set {
                if (bearbeiterid == value) return;
                bearbeiterid = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Bearbeiter", Required = Required.Always)]
        public string Bearbeiter {
            get => bearbeiter;
            set {
                if (bearbeiter == value) return;
                bearbeiter = value;
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
        public double Summe { get; private set; }

        [JsonIgnore]
        public double Umsatz { get; private set; }

        [JsonIgnore]
        public ItemRowState ItemState { get; set; }
        [JsonIgnore]
 
        public BarVerbrauchModel OrginalRowState { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SummeCalc() {
            Summe = (nach - (vor + zugang)) * -1;
            Umsatz = Summe * VKP;
        }        
    }
}