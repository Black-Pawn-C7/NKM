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
    public class WebIntoVoucher : IWebIntoVoucher {
        public IResult InsertVoucher(double menge,int mId, int dId, int bereichId) {
            const string query = @"INSERT INTO [Web.Voucher] VALUES(@menge,@mid,@did,@bereich,0)";
                var cmd = new SqlCommand(query, StaticSettings.SqlConn);
                {
                    var withBlock = cmd.Parameters;
                    withBlock.Add("@menge", SqlDbType.Decimal).Value = menge;
                    withBlock.Add("@mid", SqlDbType.Int).Value = mId;
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
