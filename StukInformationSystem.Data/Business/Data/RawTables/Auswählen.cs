// MCDB Client Beta
// StukInformationSystem.Data
// Valita.cs
// 
// 06 04 2019
// 
// Katharina Bentsche

using NKM.Base.Common.Extensions;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Data.RawTables.Mitglieder;
using StukInformationSystem.Data.Definitions.Business.Converter;
using StukInformationSystem.Data.Definitions.Business.Data.RawTables;
using StukInformationSystem.Data.Resources;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using StukInformationSystem.Data.Common.Data.RawTables.Dienst;

namespace StukInformationSystem.Data.Business.Data.RawTables {
    public class Auswählen : IAuswählen {
        public IResult<List<Gutscheine>> MitgliederGutscheine() {
            const string query = @"SELECT * FROM [Mitglieder.Gutscheine] For JSON Auto";
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<Gutscheine>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<Gutscheine>> { Value = result.Value };
        }

        public IResult<List<Gutscheine>> MitgliederGutscheine(int memberID) {
            const string query = @"SELECT * FROM [Mitglieder.Gutscheine] Where MitgliederID=@MID For JSON Auto";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = memberID;

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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<Gutscheine>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<Gutscheine>> { Value = result.Value };
        }

        public IResult<List<Gutscheine>> MitgliederGutschein(int id) {
            const string query = @"SELECT * FROM [Mitglieder.Gutscheine] Where ID=@ID For JSON Auto";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);

            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<Gutscheine>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<Gutscheine>> { Value = result.Value };
        }

        public IResult<List<Aufgabe>> DienstAufgabe() {
            const string query = "Select * From [Dienst.Aufgabe] For JSON Auto";
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<Aufgabe>>(jsonResult.ToString());

            StaticSettings.SqlConn.Close();

            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<Aufgabe>> { Value = result.Value };
        }
    }
}