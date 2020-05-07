using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;
using PUser = NKM.File.Common.Person.User;
using StukInformationSystem.Data.Definitions.Business.Data.Selects.User;
using StukInformationSystem.Data.Resources;

namespace StukInformationSystem.Data.Business.Data.Selects.User
{
    public class AVViewsAndModel : IAVViewsAndModel {

        public IResult<double> AVDiensteGesamt(PUser valUser) {
            const string query = @"SELECT Count(*) FROM [StuK_DB].[dbo].[Mitglieder.Dienste] 
                                   Where MitgliederID = @mid and ( Aufgabe = 10 or Aufgabe = 2 or Aufgabe = 15 or Aufgabe = 16)  ";

            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@mid", SqlDbType.Int).Value = valUser.MemberID;

            var result = 1;
            try {
                StaticSettings.SqlConn.Open();
                var r = cmd.ExecuteReader();
                while (r.Read()) {
                    result = (int)r[0];
                }

                r.Close();
            } catch (SqlException sqlException) {
                switch (sqlException.ErrorCode) {
                    case -2:
                        return new FailureResult<double>(ErrorType.DatabaseTimout).AddMessage("Timeout");
                    case -1:
                        return new FailureResult<double>(ErrorType.DatabaseNoConnection).AddMessage("ConnectionError");
                    default:
                        return new FailureResult<double>(ErrorType.Database).AddMessage(sqlException.Message);
                }
            } catch (InvalidOperationException e) {
                return new FailureResult<double>(ErrorType.InvalidOperation).AddMessage(e.Message);
            ////} catch (ConfigurationErrorsException e) {
            //    return new FailureResult<double>(ErrorType.InternalError).AddMessage(e.Message);
            } finally {
                StaticSettings.SqlConn.Close();
            }


            return new SuccessResult<double> { Value = result };
        }

        public IResult<DateTime> LastAVDienst(PUser valUser) {
            const string query = @"SELECT Top (1) Datum FROM [StuK_DB].[dbo].[Dienste.DienstTag] 
                                   WHERE AV = @avID order by Datum DESC";

            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@avID", SqlDbType.Int).Value = valUser.LoginID;

            var result = new DateTime(1090, 06, 20);


            try {
                StaticSettings.SqlConn.Open();
                var r = cmd.ExecuteReader();
                while (r.Read()) {
                    result = r.GetDateTime(0);
                }

                r.Close();
            } catch (SqlException sqlException) {
                switch (sqlException.ErrorCode) {
                    case -2:
                        return new FailureResult<DateTime>(ErrorType.DatabaseTimout).AddMessage("Timeout");
                    case -1:
                        return new FailureResult<DateTime>(ErrorType.DatabaseNoConnection).AddMessage("ConnectionError");
                    default:
                        return new FailureResult<DateTime>(ErrorType.Database).AddMessage(sqlException.Message);
                }
            } catch (InvalidOperationException e) {
                return new FailureResult<DateTime>(ErrorType.InvalidOperation).AddMessage(e.Message);
            //} catch (ConfigurationErrorsException e) {
            //    return new FailureResult<DateTime>(ErrorType.InternalError).AddMessage(e.Message);
            } finally {
                StaticSettings.SqlConn.Close();
            }
            return new SuccessResult<DateTime> { Value = result };
        }
        public IResult<DateTime> FirstAVDienst(PUser valUser) {
            const string query = @"SELECT Top (1) Datum FROM [StuK_DB].[dbo].[Dienste.DienstTag] 
                                   WHERE AV = @avID order by Datum ASC";

            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@avID", SqlDbType.Int).Value = valUser.LoginID;

            var result = new DateTime(1090, 06, 20);


            try {
                StaticSettings.SqlConn.Open();
                var r = cmd.ExecuteReader();
                while (r.Read()) {
                    result = r.GetDateTime(0);
                }

                r.Close();
            } catch (SqlException sqlException) {
                switch (sqlException.ErrorCode) {
                    case -2:
                        return new FailureResult<DateTime>(ErrorType.DatabaseTimout).AddMessage("Timeout");
                    case -1:
                        return new FailureResult<DateTime>(ErrorType.DatabaseNoConnection).AddMessage("ConnectionError");
                    default:
                        return new FailureResult<DateTime>(ErrorType.Database).AddMessage(sqlException.Message);
                }
            } catch (InvalidOperationException e) {
                return new FailureResult<DateTime>(ErrorType.InvalidOperation).AddMessage(e.Message);
            //} catch (ConfigurationErrorsException e) {
            //    return new FailureResult<DateTime>(ErrorType.InternalError).AddMessage(e.Message);
            } finally {
                StaticSettings.SqlConn.Close();
            }
            return new SuccessResult<DateTime> { Value = result };
        }
        public IResult<bool> GroßesAVRecht(PUser valUser) {
            var result = new[] { false, false, false };

            const string query = @"SELECT AV, AvDi, AvDoFr FROM[StuK_DB].[dbo].[Mitglieder.Optionen] 
                                   WHERE MID = @mid";

            var cmd = new SqlCommand(query, StaticSettings.SqlConn);

            cmd.Parameters.Add("@mid", SqlDbType.Int).Value = valUser.MemberID;

            try {
                StaticSettings.SqlConn.Open();
                var r = cmd.ExecuteReader();
                while (r.Read()) {
                    result[0] = (bool)r[0];
                    result[1] = (bool)r[1];
                    result[2] = (bool)r[2];
                }

                r.Close();
            } catch (SqlException sqlException) {
                switch (sqlException.ErrorCode) {
                    case -2:
                        return new FailureResult<bool>(ErrorType.DatabaseTimout).AddMessage("Timeout");
                    case -1:
                        return new FailureResult<bool>(ErrorType.DatabaseNoConnection).AddMessage("ConnectionError");
                    default:
                        return new FailureResult<bool>(ErrorType.Database).AddMessage(sqlException.Message);
                }
            } catch (InvalidOperationException e) {
                return new FailureResult<bool>(ErrorType.InvalidOperation).AddMessage(e.Message);
            //} catch (ConfigurationErrorsException e) {
            //    return new FailureResult<bool>(ErrorType.InternalError).AddMessage(e.Message);
            } finally {
                StaticSettings.SqlConn.Close();
            }

            if (!result[0])
                return new SuccessResult<bool> { Status = ResultStatus.Empty };

            if (result[0] && result[1])
                return new SuccessResult<bool> { Value = true };

            return new SuccessResult<bool> { Value = false };
        }

    }
}