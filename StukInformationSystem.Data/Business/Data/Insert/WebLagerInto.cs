using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Definitions.Business.Data.Insert;
using StukInformationSystem.Data.Resources;

namespace StukInformationSystem.Data.Business.Data.Insert
{
     public class WebLagerInto : IWebLagerInto
    {
        public IResult InsertFillBarlisten(int did, int BarID)
        {
            const string query = @"INSERT INTO [Web.Lager.VerbrauchBar] SELECT @barid, @did, ArtikelNr, '0', '0', '0' FROM [Lager.Ware] WHERE inaktiv=0 AND Deleted=0";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@barid", SqlDbType.Int).Value = BarID;
                withBlock.Add("@did", SqlDbType.Int).Value = did;
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
        public IResult InsertIntoBarlisten(int did, int bereichId,int artikelId, double vor,double trans,double nach,double frei,double rollover)
        {
            const string query = @"INSERT INTO [Web.Lager.VerbrauchBar] (BarID, DienstID, ArtikelID, Vor, Zugang, Nach,Frei,Rollover) VALUES (@bereich, @did, @artikel, @vor, @zugang, @nach,@frei,@rollover)";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@bereich", SqlDbType.Int).Value = bereichId;
                withBlock.Add("@did", SqlDbType.Int).Value = did;
                withBlock.Add("@artikel", SqlDbType.Int).Value = artikelId;
                withBlock.Add("@vor", SqlDbType.Decimal).Value = vor;
                withBlock.Add("@zugang", SqlDbType.Decimal).Value = trans;
                withBlock.Add("@nach", SqlDbType.Decimal).Value = nach;
                withBlock.Add("@frei", SqlDbType.Decimal).Value = frei;
                withBlock.Add("@rollover", SqlDbType.Decimal).Value = rollover;
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
        public IResult InsertFillZaehlListe(int did, int bereichId, int type)
        {
            const string query = @"INSERT INTO [Web.Lager.ZaehlListen] SELECT [LW].ArtikelNr ,@bereich, @did, '0', '0',@type FROM [Lager.ZaehlListe]JOIN WebLagerBereichIndex [WLBI1]ON [Lager.ZaehlListe].Bereich=WLBI1.Bereich JOIN WebLagerBereichIndex [WLBI2] ON WLBI1.BeinhaltetBereich=WLBI2.Bereich JOIN [Lager.Ware] [LW] on [Lager.ZaehlListe].ArtikelNr = [LW].ArtikelNr WHERE WLBI2.BeinhaltetBereich=@bereich AND [LW].inaktiv=0 AND [LW].Deleted=0";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@bereich", SqlDbType.Int).Value = bereichId;
                withBlock.Add("@did", SqlDbType.Int).Value = did;
                withBlock.Add("@type", SqlDbType.Int).Value = type;
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
        public IResult InsertTransfer(int artikelId, int bereichFrom, int bereichTo, int dId,int gebinde,double lose)
        {
            const string query = @"INSERT INTO [Web.Lager.Transfer] (ArtikelID, BereichFrom,BereichTo, DienstID, Gebinde, Lose) VALUES (@artikel,@bereichFrom,@bereichTo,@did,@gebinde,@lose)";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@artikel", SqlDbType.Int).Value = artikelId;
                withBlock.Add("@bereichFrom", SqlDbType.Int).Value = bereichFrom;
                withBlock.Add("@bereichTo", SqlDbType.Int).Value = bereichTo;
                withBlock.Add("@did", SqlDbType.Int).Value = dId;
                withBlock.Add("@gebinde", SqlDbType.Int).Value = gebinde;
                withBlock.Add("@lose", SqlDbType.Decimal).Value = lose;
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
