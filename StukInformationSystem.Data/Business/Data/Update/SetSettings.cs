using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Business.Extensions;
using StukInformationSystem.Data.Definitions.Business.Data.Update;
using StukInformationSystem.Data.Resources;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace StukInformationSystem.Data.Business.Data.Update {
    public class SetSettings : ISetSettings {
        public IResult UpdateSettingsMemberContribution(Stream dataStream, string name) {
            const string query = @"Update Settings Set Data=@data Where Name = @name";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@name", SqlDbType.NVarChar).Value = name;
                withBlock.Add("@data", SqlDbType.VarBinary).Value = dataStream.ToByteArray();
            }
            try {
                StaticSettings.SqlConn.Open();
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                return new FailureResult().AddMessage(ex.Message);
            } finally {
                StaticSettings.SqlConn.Close();
            }
            return new SuccessResult();
        }

        public IResult UpdateSettingsMemberContribution(Stream dataStream, int id) {
            const string query = @"Update Settings Set Data=@data Where ID = @id";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@id", SqlDbType.Int).Value = id;
                withBlock.Add("@data", SqlDbType.VarBinary).Value = dataStream.ToByteArray();
            }
            try {
                StaticSettings.SqlConn.Open();
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                return new FailureResult().AddMessage(ex.Message);
            } finally {
                StaticSettings.SqlConn.Close();
            }
            return new SuccessResult();
        }
    }
}
