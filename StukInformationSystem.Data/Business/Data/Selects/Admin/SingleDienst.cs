using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;
using NKM.File.Common.Person;
using StukInformationSystem.Data.Common.Models.EditDienst;
using StukInformationSystem.Data.Definitions.Select;
using StukInformationSystem.Data.Resources;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StukInformationSystem.Data.Business.Data.Selects.Admin {
    internal static class SingleDienst {
        internal static IResult<MasterDienst> DienstByID(int dienstId) {
            const string query = @"SELECT ID,Datum,AV,BV,Beginn,Ende,Abgeschlossen,Gaeste From [Dienste.DienstTag] Where ID = @id";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = dienstId;
            var result = new MasterDienst();
            var bvid = 0;
            try {
                StaticSettings.SqlConn.Open();
                var r = cmd.ExecuteReader();

                while (r.Read()) {
                    result.DienstID = (int)r[0];
                    result.AV = (int)r[2];
                    bvid = (int)r[3];
                    result.Beginn = r.GetDateTime(4);
                    result.Ende = r[5] == DBNull.Value ? new DateTime() : r.GetDateTime(5);
                    result.Abgeschlossen = r.GetBoolean(6);
                    result.Gaeste = (int)r[7];
                    result.ItemState = ItemRowState.Unchanged;
                }

                r.Close();
            } catch (SqlException sqlException) {
                switch (sqlException.ErrorCode) {
                    case -2:
                        return new FailureResult<MasterDienst>(ErrorType.DatabaseTimout).AddMessage("Timeout");
                    case -1:
                        return new FailureResult<MasterDienst>(ErrorType.DatabaseNoConnection).AddMessage("ConnectionError");
                    default:
                        return new FailureResult<MasterDienst>(ErrorType.Database).AddMessage(sqlException.Message);
                }
            } catch (InvalidOperationException e) {
                return new FailureResult<MasterDienst>(ErrorType.InvalidOperation).AddMessage(e.Message);
            //} catch (ConfigurationErrorsException e) {
            //    return new FailureResult<MasterDienst>(ErrorType.InternalError).AddMessage(e.Message);
            } finally {
                StaticSettings.SqlConn.Close();
            }

            result.BV = bvid == 0 ?
                new Member { MemberID = int.MaxValue, Vorname = "", Nachname = "" } :
                DataIoc.Ioc.GetInstance<IMitglieder>().Member_Base(bvid).Value;

            return new SuccessResult<MasterDienst> { Value = result };
        }
    }
}