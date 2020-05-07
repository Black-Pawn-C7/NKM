using NKM.Base.Common.Extensions;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;
using StukInformationSystem.Data.Definitions.Business.Data.Delete;
using StukInformationSystem.Data.Resources;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace StukInformationSystem.Data.Business.Data.Delete {
    public class DeleteFromDienst : IDeleteFromDienst {

        public IResult DeleteAll(int id) {
            var results = new List<IResult> {
                DeleteGutscheine(id),
                DeleteVerbrauch(id),
                DeleteAbrechnung(id),
                DeleteDienste(id),
                DeleteDienst(id)
            };

            if (results.Where(x => !x.IsSuccess()).Count() != 0)
                return new FailureResult(ErrorType.Database).AddMessage($"Fehler beim löschen des Dienstes {id}. Weitere Informationen:\n{results.Where(x => !x.IsSuccess()).FirstOrDefault().FullMessage()}");
            return new SuccessResult();
        }

        public IResult DeleteDienst(int id) {
            return SQLDelete(id, @"Delete From [Dienste.DienstTag] Where ID = @DiD");
        }

        public IResult DeleteDienste(int id) {
            return SQLDelete(id, @"Delete From [Mitglieder.Dienste] Where ID = @DiD");
        }

        public IResult DeleteGutscheine(int id) {
            return SQLDelete(id, @"Delete From [Mitglieder.Gutscheine] Where DienstID = @DiD");
        }

        public IResult DeleteVerbrauch(int id) {
            return SQLDelete(id, @"Delete From [Lager.VerbrauchBar] Where DienstID = @DiD");
        }
        public IResult DeleteAbrechnung(int id) {
            return SQLDelete(id, @"Delete From [Kasse.Abrechnungen] Where DienstID = @DiD");
        }

        internal IResult SQLDelete(int id, string sql) {
            var cmd = new SqlCommand(sql, StaticSettings.SqlConn);
            cmd.Parameters.AddWithValue("@DiD", id);
            try {
                StaticSettings.SqlConn.Open();
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                return new FailureResult(ErrorType.Database).AddMessage($"Fehler beim löschen des Dienstes {id}. Weitere Informationen:\n{ex.Message}");
            } finally {
                StaticSettings.SqlConn.Close();
            }
            return new SuccessResult();
        }

    }
}
