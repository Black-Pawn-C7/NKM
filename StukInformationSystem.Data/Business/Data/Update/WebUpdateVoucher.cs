using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Definitions.Business.Data.Update;
using StukInformationSystem.Data.Resources;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using StukInformationSystem.Data.Business.Extensions;
using NKM.Base.Common.Result;
using System;
using System.Web;
using NKM.Base.Definition.Enums;

namespace StukInformationSystem.Data.Business.Data.Update
{
    public class WebUpdateVoucher : IWebUpdateVoucher
    {
        public IResult UpdateVoucher(double menge, int mId, int dienstID, int bereichId)
        {
            const string query = @"update [Web.Voucher] SET Amount=Amount+@menge WHERE MemberID=@mid AND DID=@did AND Bereich=@bereich AND Rollover=0";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@menge", SqlDbType.Decimal).Value = menge;
                withBlock.Add("@mid", SqlDbType.Int).Value = mId ;
                withBlock.Add("@did", SqlDbType.Int).Value = dienstID;
                withBlock.Add("@bereich", SqlDbType.Int).Value = bereichId;
            }
            try
            {
                StaticSettings.SqlConn.Open();
                var resultNonQuery = cmd.ExecuteNonQuery();
                if (resultNonQuery == 0) { return new FailureResult(ErrorType.NullError); }
                if (resultNonQuery > 1) { return new FailureResult(ErrorType.Duplicate); }
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
        public IResult UpdateZwischenDienst(int dienstID, int bereichId)
        {
            const string query = @"UPDATE [Web.Voucher] SET DID=@did,Rollover=1 WHERE DID=0 AND Bereich=@bereich";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@did", SqlDbType.Int).Value = dienstID;
                withBlock.Add("@bereich", SqlDbType.Int).Value = bereichId;
            }
            try
            {
                StaticSettings.SqlConn.Open();
                var resultNonQuery = cmd.ExecuteNonQuery();
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
