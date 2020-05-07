using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using NKM.Base.Common.Extensions;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Models.Admin;
using StukInformationSystem.Data.Definitions.Business.Converter;
using StukInformationSystem.Data.Definitions.Business.Data.Selects.Admin;
using StukInformationSystem.Data.Resources;

namespace StukInformationSystem.Data.Business.Data.Selects.Admin {
    public class DienstAdminViewEdit : IDienstAdminViewEdit {
        public IResult<List<DienstViewModel>> DiensteAdmin() {
            const string query = @"SELECT * FROM [DienstOverviewAdmin] For JSON Auto";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);

            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));
            else
                jsonResult.Append("[]");

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<DienstViewModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<DienstViewModel>> {Value = result.Value};
        }

        public IResult<BindingList<MemberDiensteAdminModel>> MemberSpecificDienstAdmin(int dienstId) {
            const string query = @"SELECT * FROM [DiensteOverviewAdmin] Where DienstID = @ID For JSON Auto";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = dienstId;

            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));
            else
                jsonResult.Append("[]");

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<BindingList<MemberDiensteAdminModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<BindingList<MemberDiensteAdminModel>> { Value = result.Value };
        }

        public IResult<BindingList<MemberDiensteAdminModel>> MemberDiensteAdmin() {
            const string query = @"SELECT * FROM [DiensteOverviewAdmin] For JSON Auto";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);

            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));
            else
                jsonResult.Append("[]");

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<BindingList<MemberDiensteAdminModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<BindingList<MemberDiensteAdminModel>> { Value = result.Value };
        }
    }
}