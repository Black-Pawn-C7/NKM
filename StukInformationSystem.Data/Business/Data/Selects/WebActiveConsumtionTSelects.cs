using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using NKM.Base.Common.Extensions;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Models;
using StukInformationSystem.Data.Definitions.Business.Converter;
using StukInformationSystem.Data.Definitions.Business.Data.Selects;
using StukInformationSystem.Data.Resources;

namespace StukInformationSystem.Data.Business.Data.Selects
{
    public class WebActiveConsumptionTSelects: IWebActiveConsumptionTSelects
    {
        public IResult<List<ConsumptionType>> SelectTResult() {
            const string querySelect = @"SELECT ID AS Type FROM [Web.Consumption.Type]WHERE inactive=0 FOR JSON PATH";
            var cmdSelect = new SqlCommand(querySelect, StaticSettings.SqlConn);
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();

            var reader = cmdSelect.ExecuteReader();
            if (!reader.HasRows)
                jsonResult.Append("[]");
            else {
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));
            }

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<ConsumptionType>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<ConsumptionType>> {Value = result.Value};
        }
    }
}
