using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Definitions.Business.Converter;

namespace StukInformationSystem.Data.Business.Converter {
    public class JsonSerializerDeserialize : IJsonSerializerDeserialize {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            }
        };

        public IResult<TType> FromJson<TType>(string json) {
            try {
                return new SuccessResult<TType> {
                    Value = JsonConvert.DeserializeObject<TType>(json, Settings)
                };
            } catch (Exception e) {
#if DEBUG
                throw e;
#else
                return new FailureResult<TType>(ErrorType.BindOrValidateError).AddMessage(e.Message);
#endif        
            }
        }

        public IResult<string> ToJson<TType>(TType self) {
            try {
                return new SuccessResult<string> {
                    Value = JsonConvert.SerializeObject(self, Settings)
                };
            } catch (Exception e) {
#if DEBUG
                throw e;
#else
                return new FailureResult<string>(ErrorType.BindOrValidateError).AddMessage(e.Message);
#endif

            }
        }
    }
}