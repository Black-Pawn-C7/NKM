using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKM.Base.Common.Extensions;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Models;
using StukInformationSystem.Data.Definitions.Business.Converter;
using StukInformationSystem.Data.Definitions.Business.Data.Selects;
using StukInformationSystem.Data.Resources;

namespace StukInformationSystem.Data.Business.Data.Selects
{
    public class WebMemberSelects : IWebMemberSelects
    {
        public IResult<List<MemberBeitragOverview>> GetMitgliedOverview(int mId)
        {
            const string query = @" SELECT GsWert, Dienste, AE, Schulung FROM WebMemberOverviewSemester WHERE ID=@mId FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberBeitragOverview>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<MemberBeitragOverview>> { Value = result.Value };
        }
        public IResult<List<Tage>> GetDienstHistSem(int mId,DateTime datum)
        {
            const string query = @"SELECT DATENAME(DW, Datum) AS Tag, SUM(multiplikator) AS Anzahl FROM Web_View_Dienste WHERE MitgliederID = @mId AND Datum>@date
GROUP BY DATEPART(WEEKDAY, Datum), DATENAME(DW, Datum) ORDER BY SUM(multiplikator) DESC ,DATEPART(WEEKDAY, Datum) FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = datum;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<Tage>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<Tage>> { Value = result.Value };
        }
        public IResult<List<Tage>> GetDienstHistTotal(int mId)
        {
            const string query = @"SELECT DATENAME(DW, Datum) AS Tag, SUM(multiplikator) AS Anzahl FROM Web_View_Dienste WHERE MitgliederID = @mId
GROUP BY DATEPART(WEEKDAY, Datum), DATENAME(DW, Datum) ORDER BY SUM(multiplikator) DESC ,DATEPART(WEEKDAY, Datum) FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<Tage>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<Tage>> { Value = result.Value };
        }
        public IResult<List<MemberAmountCount>> GetMemberVoucherCount(int mId)
        {
            const string query = @"SELECT GsWert AS Amount FROM WebVoucherOverview WHERE ID=@mId FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberAmountCount>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<MemberAmountCount>> { Value = result.Value };
        }
        public IResult<List<MemberAmountCount>> GetMemberDienste(int mId, DateTime datum)
        {
            const string query = @"SELECT COUNT(multiplikator) AS Amount FROM Web_View_Dienste WHERE MitgliederID=@mId AND Datum>@date FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = datum;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberAmountCount>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<MemberAmountCount>> { Value = result.Value };
        }
        public IResult<List<MemberAmountCount>> GetMemberAe(int mId, DateTime datum)
        {
            const string query = @"SELECT COUNT([Mitglieder.AEs].ID) AS Amount FROM [Mitglieder.AEs] INNER JOIN [Dienste.AE] ON [Mitglieder.AEs].AEID = [Dienste.AE].ID WHERE DATEDIFF(HH,Beginn, Ende)>=4 AND MitgliederID=@mId AND CAST(Beginn AS DATE)>@date FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = datum;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberAmountCount>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<MemberAmountCount>> { Value = result.Value };
        }
        public IResult<List<MemberAmountCount>> GetMemberSchulung(int mId, DateTime datum)
        {
            const string query = @"SELECT Count(DISTINCT [Schulung.Arten].ID) AS Amount FROM [Schulung.Arten]
    INNER JOIN [Schulung.Leiter] ON SchArt = [Schulung.Arten].ID
    INNER JOIN [Schulung.Schulungen] ON SchTagID = [Schulung.Schulungen].ID
INNER JOIN [Schulung.Teilnahme] [S.T] on [Schulung.Leiter].ID = [S.T].Leiter
WHERE Pflicht=1 AND [S.T].MID=@mId AND TAG>@date FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = datum;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberAmountCount>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<MemberAmountCount>> { Value = result.Value };
        }
        public IResult<List<MemberAmountCount>> GetPflichtSchulungCount()
        {
            const string query = @"SELECT COUNT(ID) AS Amount FROM [Schulung.Arten] WHERE Pflicht=1 FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberAmountCount>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<MemberAmountCount>> { Value = result.Value };
        }
        public IResult<List<Dienste>> GetDienstStatsSem(int mId,DateTime datum)
        {
            const string query = @"SELECT COUNT(Name) AS Anzahl, Name AS Dienst FROM dbo.Web_View_Dienste WHERE MitgliederID = @mId AND Datum>=@date
                   GROUP BY MitgliederID, Name ORDER BY COUNT(Name) DESC FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = datum;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<Dienste>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<Dienste>> { Value = result.Value };
        }
        public IResult<List<Dienste>> GetDienstStatsTotal(int mId)
        {
            const string query = @"SELECT COUNT(Name) AS Anzahl, Name AS Dienst FROM dbo.Web_View_Dienste WHERE MitgliederID = @mId
                   GROUP BY MitgliederID, Name ORDER BY COUNT(Name) DESC FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<Dienste>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<Dienste>> { Value = result.Value };
        }
        public IResult<List<WebMemberVouches>> GetMemberVoucherList(int mId)
        {
            const string query = @"Select Wertstellung, Sum, Bekommen, Verbrauch From WebMemberVoucherOverview WHERE MitgliederID=@mId ORDER BY Wertstellung DESC FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<WebMemberVouches>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<WebMemberVouches>> { Value = result.Value };
        }
        public IResult<List<MemberVoucherDetails>> GetMemberVoucherDetails(int mId)
        {
            const string query = @"SELECT Wertstellung, Betrag, Buchungstext,Name AS AV FROM [Mitglieder.Gutscheine] W
LEFT JOIN [Dienste.DienstTag] ON DienstID=[Dienste.DienstTag].ID LEFT JOIN AVID_MID ON AV=AVID
WHERE W.MitgliederID= @mId ORDER BY Wertstellung DESC FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberVoucherDetails>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<MemberVoucherDetails>> { Value = result.Value };
        }
        public IResult<List<WebDateAmount>> GetMemberSchulungTage(int mId)
        {
            const string query = @"SELECT COUNT(DISTINCT [Schulung.Arten].ID) AS Amount,TAG AS Datum, MitgliederIDName.Name FROM [Schulung.Arten]
    INNER JOIN [Schulung.Leiter] ON SchArt = [Schulung.Arten].ID
    INNER JOIN [Schulung.Schulungen] ON SchTagID = [Schulung.Schulungen].ID
INNER JOIN [Schulung.Teilnahme] [S.T] on [Schulung.Leiter].ID = [S.T].Leiter
LEFT JOIN MitgliederIDName ON MitgliederIDName.ID=[Schulung.Schulungen].MID
WHERE [S.T].MID=@mId GROUP BY TAG,MitgliederIDName.Name FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<WebDateAmount>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<WebDateAmount>> { Value = result.Value };
        }
        public IResult<List<WebDateAmount>> GetMemberSchulungDetails(int mId)
        {
            const string query = @"SELECT TAG AS Datum,Anrede, { fn CONCAT( RTRIM(Vorname) + SPACE(1), RTRIM(Nachname)) }AS Name,Name AS Schulung FROM [Schulung.Arten]
    INNER JOIN [Schulung.Leiter] ON SchArt = [Schulung.Arten].ID
    INNER JOIN [Schulung.Schulungen] ON SchTagID = [Schulung.Schulungen].ID INNER JOIN [Schulung.Teilnahme] [S.T] on [Schulung.Leiter].ID = [S.T].Leiter
LEFT JOIN [Schulung.Referenten] ON [Schulung.Referenten].ID=RefID WHERE [S.T].MID=@mId FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<WebDateAmount>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<WebDateAmount>> { Value = result.Value };
        }
        public IResult<List<Arbeitseinsaetze>> GetMemberArbeitseinsaetze(int mId)
        {
            const string query = @"SELECT CAST(Beginn AS DATE )AS Datum, DATEDIFF(HH,Beginn, Ende) AS Time,SUBSTRING( convert(nvarchar, Beginn,108),1,5) AS Start,SUBSTRING( convert(nvarchar, Ende,108),1,5) AS Ende,Name AS Leiter, Tätigkeit,[Dienste.AE].Bemerkung FROM [Mitglieder.AEs] INNER JOIN [Dienste.AE] ON [Mitglieder.AEs].AEID = [Dienste.AE].ID
INNER JOIN MitgliederIDName ON Leiter=MitgliederIDName.ID
WHERE DATEDIFF(HH,Beginn, Ende)>=4 AND MitgliederID=@mId FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<Arbeitseinsaetze>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<Arbeitseinsaetze>> { Value = result.Value };
        }
        public IResult<List<MemberDienste>> GetMemberDienste(int mId)
        {
            const string query = @"SELECT        dbo.[Dienste.DienstTag].Datum,SUBSTRING( convert(nvarchar, Beginn,108),1,5) AS Start,SUBSTRING( convert(nvarchar, Ende,108),1,5) AS Ende, dbo.[Dienst.Aufgabe].Name, dbo.OnlyAVs.Name AS AV, dbo.[Mitglieder.Dienste].multiplikator,
                         dbo.[Mitglieder.Dienste].Bemerkung
FROM            dbo.[Dienste.DienstTag] INNER JOIN
                         dbo.[Mitglieder.Dienste] ON dbo.[Dienste.DienstTag].ID = dbo.[Mitglieder.Dienste].DienstID INNER JOIN
                         dbo.[Dienst.Aufgabe] ON dbo.[Mitglieder.Dienste].Aufgabe = dbo.[Dienst.Aufgabe].ID INNER JOIN
                         dbo.OnlyAVs ON dbo.[Dienste.DienstTag].AV = dbo.OnlyAVs.AVID
WHERE dbo.[Dienste.DienstTag].Abgeschlossen=1 AND MitgliederID=@mId AND multiplikator>0 ORDER BY Datum DESC FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mId", SqlDbType.Int).Value = mId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberDienste>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<MemberDienste>> { Value = result.Value };
        }
    }

}
