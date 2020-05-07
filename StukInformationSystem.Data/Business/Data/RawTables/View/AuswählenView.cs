// MCDB Client Beta
// StukInformationSystem.Data
// AuswählenView.cs
// 
// 07 04 2019
// 
// Katharina Bentsche

using NKM.Base.Common.Extensions;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Data.RawTables.Views;
using StukInformationSystem.Data.Definitions.Business.Converter;
using StukInformationSystem.Data.Resources;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using StukInformationSystem.Data.Definitions.Business.Data.RawTables.View;

namespace StukInformationSystem.Data.Business.Data.RawTables.View {
    public class AuswählenView : IAuswählenView{
        public IResult<List<AVView>> AVView() {
            const string query = @"SELECT * FROM [AV_View] For JSON Path";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);

            StaticSettings.SqlConn.Open();

            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows) {
                while (reader.Read()) {
                    jsonResult.Append(reader.GetValue(0));
                }
            } else {
                jsonResult.Append("[]");
            }

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<AVView>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<AVView>> { Value = result.Value };
        }

    }
}