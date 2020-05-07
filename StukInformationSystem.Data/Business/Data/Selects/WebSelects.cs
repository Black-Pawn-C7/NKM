using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Resources;
using System.Text;
using StukInformationSystem.Data.Definitions.Business.Converter;
using NKM.Base.Common.Extensions;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Business.Converter;
using StukInformationSystem.Data.Common.Models;
using StukInformationSystem.Data.Common.Models.Lager;
using StukInformationSystem.Data.Definitions.Business.Data.Selects;

namespace StukInformationSystem.Data.Business.Data.Selects {
    public class WebSelects : IWebSelects {
        public IResult<List<DienstFill>> GetValidityResult(int did) {
            var query = @"SELECT COUNT(ArtikelNr)-COUNT(ArtikelID) AS SUM, COUNT(ArtikelNr) AS Soll, COUNT(ArtikelID) AS Ist FROM [Lager.Ware] LEFT OUTER JOIN (SELECT * FROM [Web.Consumption] WHERE DID=@did) AS Consumption ON ArtikelNr = ArtikelID WHERE inaktiv=0 AND Deleted=0 FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
                jsonResult.Append("[]");
            else {
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));
            }

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<DienstFill>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<DienstFill>> {Value = result.Value};
        }
        public IResult<List<ArtikelCount>> GetArtikelCountConsumption(int did, int bereichId, int type)
        {
            const string query = @"SELECT Count(*) AS Artikel FROM [Web.Consumption] WHERE BarID=@bereich AND DID=@did AND Type=@type FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
            cmd.Parameters.Add("@bereich", SqlDbType.Int).Value = bereichId;
            cmd.Parameters.Add("@type", SqlDbType.Int).Value = type;
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
            {
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));
            }

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<ArtikelCount>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<ArtikelCount>> { Value = result.Value };
        }
        public IResult<List<WebVoucherOverview>> GetMitgliedIdByName(string mName) {
            var query = @"SELECT ID ,Name FROM MitgliederIDName WHERE Name= @name FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = mName;
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
                jsonResult.Append("[]");
            else {
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));
            }
            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<WebVoucherOverview>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            if (result.Value.Count > 1) {
                return new FailureResult<List<WebVoucherOverview>> {Value = result.Value};
            }
            return !result.IsSuccess() ? result : new SuccessResult<List<WebVoucherOverview>> {Value = result.Value};
        }
        public IResult<List<MemberTinyModel>> GetMitgliedNameById(int mId) {
            var query = @"SELECT ID ,Name FROM MitgliederIDName WHERE ID = @mId FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
                jsonResult.Append("[]");
            else {
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));
            }

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberTinyModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<MemberTinyModel>> {Value = result.Value};
        }
        public IResult<List<WebVoucherOverview>> GetDoubleMitgliedByName(string mName)
        {
            var query = @"SELECT * FROM WebVoucherOverview WHERE Name=@name FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = mName;
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
            {
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));
            }

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<WebVoucherOverview>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<WebVoucherOverview>> { Value = result.Value };
        }
        public IResult<List<WebArtikelZaehlliste>> GetZaehlliste(int bereichId)
        {
            var query = @"SELECT [Lager.ZaehlListe].ArtikelNr,ArtikelName,Voll=0,Offen=0,VollName.Name AS VollEinheit, OffenName.Name AS OffenEinheit FROM [Lager.ZaehlListe]inner join WebLagerBereichIndex WLBI on [Lager.ZaehlListe].Bereich = WLBI.Bereich left outer join ((Select ArtikelNr,Name From [Web.Lager.Zaehleinheit]inner join [Web.Lager.ZaehleinheitType]on VollEinheit=ID) AS VollName left join(Select ArtikelNr,Name From [Web.Lager.Zaehleinheit]inner join [Web.Lager.ZaehleinheitType]on OffenEinheit=ID) AS OffenName on VollName.ArtikelNr=OffenName.ArtikelNr) on [Lager.ZaehlListe].ArtikelNr=VollName.ArtikelNr WHERE inaktiv=0 AND BeinhaltetBereich=2 ORDER BY Standort ,SortA FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@bereich", SqlDbType.Int).Value = bereichId;
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
            {
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));
            }

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<WebArtikelZaehlliste>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<WebArtikelZaehlliste>> { Value = result.Value };
        }
        public IResult<List<DienstIdModel>> GetOpenBereich(int bereichId)
        {
            const string query = @"SELECT [Dienste.DienstTag].ID,Name AS AvName FROM [Dienste.DienstTag] INNER JOIN [Web.BereichStatus] On DienstID=[Dienste.DienstTag].ID JOIN OnlyAVs ON AV=AVID WHERE (Datum=@date OR Datum=@date) AND Abgeschlossen=0 AND Closed=0 AND Ignore=0 AND BereichID=@bereich FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@bereich", SqlDbType.Int).Value = bereichId;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now;
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
            {
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));
            }

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<DienstIdModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<DienstIdModel>> { Value = result.Value };
        }
        public IResult<List<Datum>> GetSemesterDate(int semesterAnzahl)
        {
            if (semesterAnzahl<1)return new FailureResult<List<Datum>>(ErrorType.InvalidOperation).AddMessage("semasterAnzahl < 1");
            const string query = @"SELECT CAST(Tag AS Date) VVDatum FROM [Mitglieder.VV] WHERE SVV=0 ORDER BY Tag DESC OFFSET (@sem) ROWS FETCH NEXT (1) ROWS ONLY FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@sem", SqlDbType.Int).Value = semesterAnzahl-1;
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
            {
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));
            }

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<Datum>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<Datum>>{Value = result.Value};
        }
    }
}
