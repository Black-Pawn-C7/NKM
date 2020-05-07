using System;
using System.Data;
using System.Data.SqlClient;
using NKM.File.Common.Person;

namespace StukInformationSystem.Data.Insert {
    public static class Dienste {
        private static readonly SqlConnection sqlConn = new SqlConnection("Data Source=db.nkm.xn;Initial Catalog=StuK_DB;User ID=sa;Password=orFe#3<%Ut5?kjbj");

        public static bool WriteLog(string Message, int AVID = 0, string ErrorMsg = "") {
            var sqlCommand = "SET LANGUAGE german Insert Into [Admin.Log] (LogText, ErrorMessage, Zeit, UserID) Values (@txt, @ermsg, @tm, @usr)";
            var cmd = new SqlCommand(sqlCommand, sqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@txt", SqlDbType.NText).Value = Message;
                withBlock.Add("@ermsg", SqlDbType.NText).Value = ErrorMsg;
                withBlock.Add("@tm", SqlDbType.DateTime).Value = DateTime.Now.ToString("o");
                withBlock.Add("@usr", SqlDbType.Int).Value = AVID;
            }
            try {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
            } catch (Exception) {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Logging");
                return false;
            } finally {
                sqlConn.Close();
            }

            return true;
        }

        public static int Neu(DateTime date, User usr, BaseMember bv, DateTime start) {
            var RETURN = -1;
            var query = @"
                Insert INTO [Dienste.DienstTag] (Datum, AV, BV, Beginn, Abgeschlossen, Stand, Bearbeiter, Ersteller) 
                Values (@AD, @AV, @BV, @DatA,  @AbG, @Std, @Beb, @Erst) 
                Select Cast(scope_identity() AS int)";
            var cmd = new SqlCommand(query, sqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@AD", SqlDbType.Date).Value = date.ToString("o");
                withBlock.Add("@AV", SqlDbType.Int).Value = usr.LoginID;
                withBlock.Add("@BV", SqlDbType.Int).Value = bv.MemberID;
                withBlock.Add("@DatA", SqlDbType.DateTime).Value = start.ToString("o");
                withBlock.Add("@AbG", SqlDbType.Bit).Value = 0;
                withBlock.Add("@Std", SqlDbType.DateTime).Value = DateTime.UtcNow.ToString("o");
                withBlock.Add("@Beb", SqlDbType.Int).Value = usr.LoginID;
                withBlock.Add("@Erst", SqlDbType.Int).Value = usr.LoginID;
            }
            try {
                sqlConn.Open();
                RETURN = (int) cmd.ExecuteScalar();
            } finally {
                sqlConn.Close();
                WriteLog($"{usr.UserName} hat einen Neuen Dienst mit der ID {RETURN} erstellt");
            }

            return RETURN;
        }
    }
}