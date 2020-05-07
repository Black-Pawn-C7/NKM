using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Definitions.Business.Data.Insert;
using StukInformationSystem.Data.Resources;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using StukInformationSystem.Data.Business.Extensions;
using NKM.Base.Common.Result;
using System;

namespace StukInformationSystem.Data.Business.Data.Insert {
    public class IntoSettings : IIntoSettings {
        public IResult InsertSettingsMemberContribution(Stream dataStream, int id, string name) {
            const string query = @"Insert Into Settings (ID, Name, Data) Values (@id, @name, @data)";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@id", SqlDbType.Int).Value = id;
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
    }
}
