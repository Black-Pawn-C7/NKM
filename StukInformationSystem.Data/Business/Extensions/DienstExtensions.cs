using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;
using NKM.File.Common.Person;
using StukInformationSystem.Data.Resources;
using System;
using NKM.Base.Common.Extensions;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using NKM.File.Common.Area;

namespace StukInformationSystem.Data.Business.Extensions {
    public static class DienstExtensions {
        public static IResult<bool> IsFin(this Dienst dienst) {
            bool Return = false;
            var query = @"
SELECT      [Dienste.DienstTag].Abgeschlossen
FROM        [Dienste.DienstTag]
WHERE       [Dienste.DienstTag].ID = @DiD";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.AddWithValue("@DiD", dienst.DienstID);
            try {
                StaticSettings.SqlConn.Open();
                var r = cmd.ExecuteReader();                
                while (r.Read()) {
                    Return = r[0] != DBNull.Value ? (bool)r[0] : false;
                }
                r.Close();
            } catch (Exception ex) {
                return new FailureResult<bool>(ErrorType.Database).AddMessage($"Fehler in der Methode IsFin() mit der ID {dienst.DienstID}. Weitere Informationen:\n{ex.Message}");
            } finally {
                StaticSettings.SqlConn.Close();
            }
            return new SuccessResult<bool> { Value = Return };
        }
        public static IResult<bool> Exists(this Dienst dienst) {
            bool Return = false;
            var query = @"
SELECT      [Dienste.DienstTag].ID
FROM        [Dienste.DienstTag]
WHERE       [Dienste.DienstTag].ID = @DiD";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.AddWithValue("@DiD", dienst.DienstID);
            try {
                StaticSettings.SqlConn.Open();
                var r = cmd.ExecuteReader();
                Return = !r.HasRows;
                r.Close();
            } catch (Exception ex) {
                return new FailureResult<bool>(ErrorType.Database).AddMessage($"Fehler in der Methode Exists() mit der ID {dienst.DienstID}. Weitere Informationen:\n{ex.Message}");
            } finally {
                StaticSettings.SqlConn.Close();
            }
            return new SuccessResult<bool> { Value = Return };
        }
    }
}
