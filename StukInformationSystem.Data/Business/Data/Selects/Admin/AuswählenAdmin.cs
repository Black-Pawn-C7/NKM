// MCDB Client Beta
// StukInformationSystem.Data
// AuswählenView.cs
// 
// 08 04 2019
// 
// Katharina Bentsche

using NKM.Base.Common.Extensions;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Definitions.Business.Converter;
using StukInformationSystem.Data.Resources;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using StukInformationSystem.Data.Common.Models.EditDienst;
using StukInformationSystem.Data.Definitions.Business.Data.Selects.Admin;
using System.ComponentModel;

namespace StukInformationSystem.Data.Business.Data.Selects.Admin {
    public class AuswählenAdmin : IAuswählenAdmin {
        public IResult<List<BarVerbrauchModel>> BarVerbrauchAdmin(int dienstId) {
            const string query = @"SELECT * FROM [StuK_DB].[dbo].[LagerVerbrauchDienst]
                                        Where DienstID = @id
                                        For JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = dienstId;

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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<BarVerbrauchModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<BarVerbrauchModel>> { Value = result.Value };
        }

        public IResult<BindingList<AbendAbrechnungModel>> AbendAbrechnungAdmin(int dienstId) {
            const string query = @"SELECT * FROM [StuK_DB].[dbo].[AbendAbrechnungDienst]
                                        Where DienstID = @id
                                        For JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = dienstId;

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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<BindingList<AbendAbrechnungModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<BindingList<AbendAbrechnungModel>> { Value = result.Value };
        }
    }
}