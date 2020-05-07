using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Definitions.Business;
using StukInformationSystem.Data.Definitions.Business.Data.Selects;
using StukInformationSystem.Data.Definitions.Common.Models;
using StukInformationSystem.Data.Definitions.Business.Converter;
using StukInformationSystem.Data.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using NKM.Base.Common.Extensions;
using StukInformationSystem.Data.Common.Models;

namespace StukInformationSystem.Data.Business.Data.Selects {
    public class GeneralSelects : IGeneralSelects {
        public IResult<DateTime> GetLastCouponBookingMonthForClubCouncil() {
            const string query = @"Select top(1) Zeit From[Admin.Log] Where LogText like 'Réservation automatique des bons du Club Council' Order by Zeit DESC";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            DateTime resultDate = new DateTime();
            try {
                StaticSettings.SqlConn.Open();
                var reader = cmd.ExecuteReader();
                
                while (reader.Read()) {
                    resultDate = DateTime.Parse((string)reader[0]);
                }
                reader.Close();
                return new SuccessResult<DateTime>() { Value = resultDate };
            } catch (Exception ex) {
                return new FailureResult<DateTime>(ErrorType.Database).AddMessage(ex.Message);
            } finally {
                StaticSettings.SqlConn.Close();
            }
        }
        public IResult<int> GetClubCouncilBookingCount() {
            const string query = @"Select Count(*) From [Admin.Log] Where LogText like 'Réservation automatique des bons du Club Council'";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            try {
                StaticSettings.SqlConn.Open();
                var count = (int)cmd.ExecuteScalar();
                return new SuccessResult<int>() { Value = count };
            } catch (Exception ex) {
                return new FailureResult<int>(ErrorType.Database).AddMessage(ex.Message);
            } finally {
                StaticSettings.SqlConn.Close();
            }
        }

        public IResult<List<ClubCouncilCouponModel>> GetClubCouncilForCouponBooking() {
            const string query = @"SELECT [Mitglieder.Clubrat.Verlauf].MID, MitgliederIDName.Name, [Mitglieder.Clubrat.Verlauf].Posten, [Mitglieder.Clubrat.Posten].Posten AS PostenName, [Mitglieder.Clubrat.Posten].GS
                                    FROM            [Mitglieder.Clubrat.Verlauf] INNER JOIN
                                                             [Mitglieder.Clubrat.Posten] ON [Mitglieder.Clubrat.Verlauf].Posten = [Mitglieder.Clubrat.Posten].ID INNER JOIN
                                                             MitgliederIDName ON [Mitglieder.Clubrat.Verlauf].MID = MitgliederIDName.ID
                                    WHERE        ([Mitglieder.Clubrat.Verlauf].Deleted = 0) AND ([Mitglieder.Clubrat.Verlauf].Komisionarisch = 0) AND ([Mitglieder.Clubrat.Verlauf].Ende IS NULL)
                                    ORDER BY PostenName
                                    For JSON Path";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);

            StaticSettings.SqlConn.Open();

            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows) {
                while (reader.Read()) {
                    jsonResult.Append(reader.GetValue(0));
                }
            } else {
                jsonResult.Append("[]");
            }

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<ClubCouncilCouponModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<ClubCouncilCouponModel>> { Value = result.Value };
        }
    }
}
