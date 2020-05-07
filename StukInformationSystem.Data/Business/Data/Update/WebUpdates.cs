using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Resources;

namespace StukInformationSystem.Data.Business.Data.Update
{
    public class WebUpdates
    {
        public IResult UpdateOpenBereich(int dienstId, int bereichId)
        {
            const string query = @"UPDATE [Web.BereichStatus] Set Closed=0 WHERE DienstID=@did AND BereichID=@bereich";
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
                if (resultNonQuery == 0) { return new FailureResult(ErrorType.NullError); }
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
        public IResult UpdateCloseBereich(int dienstId, int bereichId)
        {
            const string query = @"UPDATE [Web.BereichStatus] Set Closed=1 WHERE DienstID=@did AND BereichID=@bereich";
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
                if (resultNonQuery == 0) { return new FailureResult(ErrorType.NullError); }
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
        public IResult UpdateIgnoreBereich(int dienstId, int bereichId)
        {
            const string query = @"UPDATE [Web.BereichStatus] Set Ignore=1 WHERE DienstID=@did AND BereichID=@bereich";
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
                if (resultNonQuery == 0) { return new FailureResult(ErrorType.NullError); }
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
        public IResult UpdateCheckBereichExist(int dienstId, int bereichId)
        {
            const string query = @"UPDATE [Web.BereichStatus] Set BereichID=@bereich WHERE DienstID=@did AND BereichID=@bereich";
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
                if (resultNonQuery == 0) { return new FailureResult(ErrorType.NullError); }
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
