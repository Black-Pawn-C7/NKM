using NKM.Base.Definition.Common.Result;

namespace StukInformationSystem.Data.Definitions.Business.Converter {
    public interface IJsonSerializerDeserialize {
        IResult<TType> FromJson<TType>(string json);
        IResult<string> ToJson<TType>(TType self);
    }
}