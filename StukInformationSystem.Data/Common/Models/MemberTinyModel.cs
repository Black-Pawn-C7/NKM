using System;

using Newtonsoft.Json;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Definitions.Common.Models;

namespace StukInformationSystem.Data.Common.Models {
    public class MemberTinyModel : IMemberTinyModel {
       
        [JsonProperty("ID", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("Name", Required = Required.Always)]
        public string Name { get; set; }

    }
}