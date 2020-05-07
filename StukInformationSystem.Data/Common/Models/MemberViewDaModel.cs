
using Newtonsoft.Json;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Definitions.Common.Models;

namespace StukInformationSystem.Data.Common.Models {
    public class MemberViewDAModel : IMemberViewDAModel {
        public MemberViewDAModel() { }

        public MemberViewDAModel(int id) {
            Id = id;
            ItemState = ItemRowState.Added;
        }

        [JsonProperty("ID", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("Dienste", Required = Required.Always)]
        public decimal Dienste { get; set; }

        [JsonProperty("AEs", Required = Required.Always)]
        public decimal AEs { get; set; }

        [JsonIgnore]
        public ItemRowState ItemState { get; set; }
    }
}