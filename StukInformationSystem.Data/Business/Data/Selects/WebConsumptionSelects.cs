using System;
using System.Collections.Generic;
using System.Data;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Resources;
using System.Data.SqlClient;
using System.Text;
using StukInformationSystem.Data.Definitions.Business.Converter;
using NKM.Base.Common.Extensions;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Common.Models;
using StukInformationSystem.Data.Definitions.Business.Data.Selects;

namespace StukInformationSystem.Data.Business.Data.Selects
{
    public class WebConsumptionSelects : IWebConsumptionSelects
    {
        public IResult<List<DienstIdModel>>SelectAV(int bereichId) 
        {
            const string query = @"SELECT [Dienste.DienstTag].ID, Name AS AVName FROM [Dienste.DienstTag] INNER JOIN dbo.AVID_MID ON AV = AVID LEFT OUTER JOIN [Web.BereichStatus] On DienstID=[Dienste.DienstTag].ID WHERE Datum=@date AND Abgeschlossen=0 AND Closed=0 AND Ignore=0 AND BereichID=@bereich FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Today;
            cmd.Parameters.Add("bereich", SqlDbType.Int).Value = bereichId;
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

            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<DienstIdModel>> { Value = result.Value };
        }
        public IResult<List<DienstIdModel>> SelectDId()
        {
            const string query = @"SELECT [Dienste.DienstTag].ID FROM [Dienste.DienstTag] INNER JOIN dbo.AVID_MID ON AV = AVID WHERE Datum=@date AND Abgeschlossen=0 FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Today;
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

            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<DienstIdModel>> { Value = result.Value };
        }
        public IResult<List<CouponMitgliederList>> SelectMitgliederFav(int dienstId)
        {
            const string query = @"SELECT [Mitglieder.Mitglieder].ID ,{ fn CONCAT(RTRIM(Vorname) + SPACE(1), RTRIM(Nachname)) } AS Name FROM [Mitglieder.Mitglieder] INNER JOIN [Web.Voucher] ON [Mitglieder.Mitglieder].ID = MemberID WHERE DID=@did FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("did", SqlDbType.Int).Value = dienstId;
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
            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<CouponMitgliederList>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<CouponMitgliederList>> { Value = result.Value };
        }
    }
}
