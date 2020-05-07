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
    public class WebUpdateConsumption : IWebUpdateConsumption
    {
        public IResult UpdateWareConsumption(int menge, int artikelId, int typeId, int dienstId, int bereichId)
        {
            const string query = @"update [Web.Consumption] SET Amount=Amount+@menge Where ArtikelID=@artikel AND Type=@type AND DID=@did AND BarID=@bereich AND Rollover=0";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@menge", SqlDbType.Int).Value = menge;
                withBlock.Add("@artikel", SqlDbType.Int).Value = artikelId;
                withBlock.Add("@type", SqlDbType.Int).Value = typeId;
                withBlock.Add("@did", SqlDbType.Int).Value = dienstId;
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
        public IResult UpdateConsumptionZwischenDienst(int dienstId, int bereichId)
        {
            const string query = @"UPDATE [Web.Consumption] SET DID=@did,Rollover=1 WHERE DID=0 AND BarID=@bereich";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@did", SqlDbType.Int).Value = dienstId;
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
