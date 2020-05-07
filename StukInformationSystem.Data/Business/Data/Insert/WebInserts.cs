using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Resources;

namespace StukInformationSystem.Data.Business.Data.Insert
{
    public class WebInserts
    {
        public IResult InsertBereich(int dId, int bereichId,bool closed,bool ignored)
        {
            const string query = @"INSERT INTO [Web.BereichStatus] VALUES (@did,@bereich,@closed,@igno)";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@closed", SqlDbType.Bit).Value = closed;
                withBlock.Add("@igno", SqlDbType.Bit).Value = ignored;
                withBlock.Add("@did", SqlDbType.Int).Value = dId;
                withBlock.Add("@bereich", SqlDbType.Int).Value = bereichId;
            }
            try
            {
                StaticSettings.SqlConn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return new FailureResult().AddMessage(ex.Message);
            }
            finally
            {
                StaticSettings.SqlConn.Close();
            }
            return new SuccessResult();
        }
    }
}
