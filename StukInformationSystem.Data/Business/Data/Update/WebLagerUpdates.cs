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
    public class WebLagerUpdates
    {
        public IResult UpdateSubmitVorZaehlListe(double menge, int artikelId, int dienstId, int bereichId)
        {
            const string query = @"UPDATE [Web.Lager.VerbrauchBar] SET Vor=@menge WHERE BarID=@bereich AND DienstID=@did AND ArtikelID=@artikel";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@menge", SqlDbType.Decimal).Value = menge;
                withBlock.Add("@artikel", SqlDbType.Int).Value = artikelId;
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
        public IResult UpdateSubmitTransZaehlListe(double menge, int artikelId, int dienstId, int bereichId)
        {
            const string query = @"UPDATE [Web.Lager.VerbrauchBar] SET Zugang=@menge WHERE BarID=@bereich AND DienstID=@did AND ArtikelID=@artikel";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@menge", SqlDbType.Decimal).Value = menge;
                withBlock.Add("@artikel", SqlDbType.Int).Value = artikelId;
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
        public IResult UpdateSubmitNachZaehlListe(double menge, int artikelId, int dienstId, int bereichId)
        {
            const string query = @"UPDATE [Web.Lager.VerbrauchBar] SET Nach=@menge WHERE BarID=@bereich AND DienstID=@did AND ArtikelID=@artikel";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@menge", SqlDbType.Decimal).Value = menge;
                withBlock.Add("@artikel", SqlDbType.Int).Value = artikelId;
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
        public IResult UpdateSubmitFreiZaehlListe(double menge, int artikelId, int dienstId, int bereichId)
        {
            const string query = @"UPDATE [Web.Lager.VerbrauchBar] SET Frei=@menge WHERE BarID=@bereich AND DienstID=@did AND ArtikelID=@artikel";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@menge", SqlDbType.Decimal).Value = menge;
                withBlock.Add("@artikel", SqlDbType.Int).Value = artikelId;
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
        public IResult UpdateSubmitRolloverZaehlListe(double menge, int artikelId, int dienstId, int bereichId)
        {
            const string query = @"UPDATE [Web.Lager.VerbrauchBar] SET Rollover=@menge WHERE BarID=@bereich AND DienstID=@did AND ArtikelID=@artikel";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@menge", SqlDbType.Decimal).Value = menge;
                withBlock.Add("@artikel", SqlDbType.Int).Value = artikelId;
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
        public IResult UpdateUpdateZaehlListe(int voll,double offen, int artikelId, int dienstId, int bereichId,int type)
        {
            const string query = @"UPDATE [Web.Lager.ZaehlListen] SET Offen=@offen,Voll=@voll WHERE BereichID=@bereich AND DienstID=@did AND ArtikelID=@artikel AND Type=@type";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@voll", SqlDbType.Int).Value = voll;
                withBlock.Add(new SqlParameter("@offen", SqlDbType.Decimal)
                {
                    Precision = 5,
                    Scale = 2
                }).Value = offen;
                withBlock.Add("@artikel", SqlDbType.Int).Value = artikelId;
                withBlock.Add("@did", SqlDbType.Int).Value = dienstId;
                withBlock.Add("@bereich", SqlDbType.Int).Value = bereichId;
                withBlock.Add("@type", SqlDbType.Int).Value = type;
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
