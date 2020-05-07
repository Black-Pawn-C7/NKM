
using Newtonsoft.Json;
using NKM.Base.Definition.Enums;

namespace StukInformationSystem.Data.Definitions.Common.Data {
    public interface IModelStatefull {

        [JsonIgnore]
        ItemRowState ItemState { get; set; }
    }
}