// MCDB Client Beta
// StukInformationSystem.Data
// AbendAbrechnungModel.cs
// 
// 08 04 2019
// 
// Katharina Bentsche

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NKM.Base.Definition.Enums;

using StukInformationSystem.Data.Definitions.Common.Data;

namespace StukInformationSystem.Data.Common.Models.EditDienst {
    public class AbendAbrechnungModel : IModelStatefull, INotifyPropertyChanged {

        private int id, bereich, ersteller, bearbeiter, dienstId;
        private DateTime datum, stand;
        private decimal bargeld, wechselgeld, belege;
        private bool abgeschlossen, geprueft;


        [JsonProperty("ID", Required = Required.Always)]
        public int ID {
            get => id; set {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Datum", Required = Required.Always)]
        public DateTime Datum {
            get => datum;
            set {
                if (datum == value) return;
                datum = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Bereich", Required = Required.Always)]
        public int Bereich {
            get => bereich;
            set {
                if (bereich == value) return;
                bereich = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Bargeld", Required = Required.Always)]
        public decimal Bargeld {
            get => bargeld;
            set {
                if (bargeld == value) return;
                bargeld = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Wechselgeld", Required = Required.Always)]
        public decimal Wechselgeld {
            get => wechselgeld;
            set {
                if (wechselgeld == value) return;
                wechselgeld = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Belege", Required = Required.Always)]
        public decimal Belege {
            get => belege;
            set {
                if (belege == value) return;
                belege = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("Abgeschlossen", Required = Required.Always)]
        public bool Abgeschlossen {
            get => abgeschlossen;
            set {
                if (abgeschlossen == value) return;
                abgeschlossen = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("geprueft", Required = Required.Always)]
        public bool Geprueft {
            get => geprueft;
            set {
                if (geprueft == value) return;
                geprueft = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("DienstID", Required = Required.Always)]
        public int DienstId {
            get => dienstId;
            set {
                if (dienstId == value) return;
                dienstId = value;
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
        public AbendAbrechnungModel OrginalRowState { get; set; }

        [JsonIgnore]
        public ItemRowState ItemState { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}