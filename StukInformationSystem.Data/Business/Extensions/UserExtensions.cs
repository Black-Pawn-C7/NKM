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

namespace StukInformationSystem.Data.Business.Extensions {
    public static class UserExtensions {
        public static IResult<Image> GetPicture(this User user)
        {

            byte[] Return = null;
            var query = @"
SELECT      [Mitglieder.Logins].Foto
FROM        [Mitglieder.Logins] 
WHERE       [Mitglieder.Logins].ID = @xID";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@xID", SqlDbType.Int).Value = user.LoginID;
            try
            {
                StaticSettings.SqlConn.Open();
                var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    Return = r[0] != DBNull.Value ? (byte[]) r[0] : null;
                }

                r.Close();
            }
            catch (Exception ex)
            {
                return new FailureResult<Image>(ErrorType.Database).AddMessage(
                    $"Fehler bei abruf der Benutzer Einstellungen. Weitere Informationen:\n{ex.Message}");
            }
            finally
            {
                StaticSettings.SqlConn.Close();
            }

            if (Return != null)
            {
                MemoryStream mem = new MemoryStream(Return);
                return new SuccessResult<Image> {Value = Image.FromStream(mem)};

            }
            else
            {
                return new SuccessResult<Image> { Value = Properties.Resources.defaultUser };
            }
        }
        

        public static IResult SetPicture(this User user, Image image) {
            var query = @"
UPDATE [Mitglieder.Logins] Set [Mitglieder.Logins].Foto=@Image
WHERE       [Mitglieder.Logins].ID = @xID";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.AddWithValue("@Image", image.ToArray());
            cmd.Parameters.AddWithValue("@xID", user.LoginID);
            try {
                StaticSettings.SqlConn.Open();
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                return new FailureResult(ErrorType.Database).AddMessage($"Fehler beim einfügen von Benutzer Einstellungen. Weitere Informationen:\n{ex.Message}");
            } finally {
                StaticSettings.SqlConn.Close();
            }

            return new SuccessResult();
        }
    }
}
