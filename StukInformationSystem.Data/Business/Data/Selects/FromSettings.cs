using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Definitions.Business;
using StukInformationSystem.Data.Resources;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace StukInformationSystem.Data.Business.Data.Selects {
    public class FromSettings : IFromSettings {
        public IResult<Stream> SettingsMemberContribution(int dataID) {
            const string query = @"SELECT Data FROM Settings
                                        Where ID = @id";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = dataID;
            try {
                StaticSettings.SqlConn.Open();
                byte[] buffer = (byte[])cmd.ExecuteScalar();
                return new SuccessResult<Stream>() { Value = new MemoryStream(buffer) };
            } catch (Exception ex) {
                return new FailureResult<Stream>(ErrorType.Database).AddMessage(ex.Message);
            } finally {
                StaticSettings.SqlConn.Close();
            }
        }
    }
}
