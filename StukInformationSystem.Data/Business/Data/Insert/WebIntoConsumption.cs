using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Definitions.Business.Data.Insert;
using StukInformationSystem.Data.Resources;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using StukInformationSystem.Data.Business.Extensions;
using NKM.Base.Common.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using NKM.Base.Common.Extensions;
using StukInformationSystem.Data.Common.Models;
using StukInformationSystem.Data.Definitions.Business.Converter;

namespace StukInformationSystem.Data.Business.Data.Insert {
    public class WebIntoConsumption : IWebIntoConsumption {
        public IResult InsertConsumption(int did,int bereichId,int artikelId, int type,double menge) {
            const string query = @"INSERT INTO [Web.Consumption] VALUES (@bereich, @type ,@artikel, @did,@menge,0)";
                var cmd = new SqlCommand(query, StaticSettings.SqlConn);
                {
                    var withBlock = cmd.Parameters;
                    withBlock.Add("@bereich", SqlDbType.Int).Value = bereichId;
                    withBlock.Add("@type", SqlDbType.Int).Value = type;
                    withBlock.Add("@did", SqlDbType.Int).Value = did;
                    withBlock.Add("@artikel", SqlDbType.Int).Value = artikelId;
                    withBlock.Add("@menge", SqlDbType.Decimal).Value = menge;
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
