using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Definitions.Select.SelectFrom;
using StukInformationSystem.Data.Resources;
using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;

namespace StukInformationSystem.Data.Business.Data.Selects.SelectFrom {
    public class AsDataTable : IAsDataTable {
        public IResult<DataTable> SelectSqlQueryAsDataTable(string query) {
            var sqlcmd = new SqlCommand(query, StaticSettings.SqlConn);
            var result = new DataTable();
            try {
                StaticSettings.SqlConn.Open();
                result.Load(sqlcmd.ExecuteReader());
                return new SuccessResult<DataTable> {Value = result};
            } catch (SqlException sqlException) {
                switch (sqlException.ErrorCode)
                {
                    case -2:
                        return new FailureResult<DataTable>(ErrorType.DatabaseTimout).AddMessage("Timeout");
                    case -1:
                        return new FailureResult<DataTable>(ErrorType.DatabaseNoConnection).AddMessage("ConnectionError");
                    default:
                        return new FailureResult<DataTable>(ErrorType.Database).AddMessage(sqlException.Message);
                }
            } catch (InvalidOperationException e) {
                return new FailureResult<DataTable>(ErrorType.InvalidOperation).AddMessage(e.Message);
            //} catch (System.Configuration.ConfigurationErrorsException e) {
            //    return new FailureResult<DataTable>(ErrorType.InternalError).AddMessage(e.Message);
            } finally {
                StaticSettings.SqlConn.Close();
            }
        }

        public IResult<DataTable> SelectSqlQueryAsDataTable(string query, List<SqlParameter> parameters) {
            var sqlcmd = new SqlCommand(query, StaticSettings.SqlConn);
            var sqladapter = new SqlDataAdapter(sqlcmd);
            var result = new DataTable();

            foreach (var cmdSqlParameter in parameters) {
                sqlcmd.Parameters.Add(cmdSqlParameter);
            }

            try {
                StaticSettings.SqlConn.Open();
                sqladapter.Fill(result);
                return new SuccessResult<DataTable> { Value = result };
            } catch (SqlException sqlException) {
                switch (sqlException.ErrorCode) {
                    case -2:
                        return new FailureResult<DataTable>(ErrorType.DatabaseTimout).AddMessage("Timeout");
                    case -1:
                        return new FailureResult<DataTable>(ErrorType.DatabaseNoConnection).AddMessage("ConnectionError");
                    default:
                        return new FailureResult<DataTable>(ErrorType.Database).AddMessage(sqlException.Message);
                }
            } catch (InvalidOperationException e) {
                return new FailureResult<DataTable>(ErrorType.InvalidOperation).AddMessage(e.Message);
            //} catch (ConfigurationErrorsException e) {
            //    return new FailureResult<DataTable>(ErrorType.InternalError).AddMessage(e.Message);
            } finally {
                StaticSettings.SqlConn.Close();
            }
        }
    }
}