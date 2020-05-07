using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using NKM.Base.Common.Extensions;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;
using NKM.File.Common.Person;
using StukInformationSystem.Data.Common.Models;
using StukInformationSystem.Data.Common.Models.Admin;
using StukInformationSystem.Data.Common.Models.Auto;
using StukInformationSystem.Data.Definitions.Business.Converter;
using StukInformationSystem.Data.Definitions.Select;
using StukInformationSystem.Data.Resources;

namespace StukInformationSystem.Data.Select {
    public class Mitglieder : IMitglieder {
        public IResult<BaseMember> Member_Base(int memberId) {
            BaseMember Return = new Member();
            var query = "SET LANGUAGE german Select [Mitglieder.Mitglieder].Vorname," + "[Mitglieder.Mitglieder].Nachname, [Mitglieder.Mitglieder].Spitzname From [Mitglieder.Mitglieder] Where ID = @xID";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@xID", SqlDbType.Int).Value = memberId;
            try {
                StaticSettings.SqlConn.Open();
                var r = cmd.ExecuteReader();
                while (r.Read()) {
                    Return.Vorname = ((string) r[0]).Trim();
                    Return.Nachname = ((string) r[1]).Trim();
                    Return.Spitzname = r[2] != DBNull.Value
                        ? ((string) r[2]).Trim()
                        : string.Empty;
                    Return.MemberID = (int) memberId;
                }

                r.Close();
            } catch (Exception ex) {
                return new FailureResult<BaseMember>(ErrorType.Database).AddMessage($"Fehler bei abruf des Mitgliedes.\n{ex.Message}");
            } finally {
                StaticSettings.SqlConn.Close();
            }

            return new SuccessResult<BaseMember> {Value = Return};
        }

        public IResult<List<MemberViewDAModel>> MemberDienstAE() {
            var query = @"SELECT 
                    Member.ID, { fn CONCAT(RTRIM(Member.Vorname) + SPACE(1), RTRIM(Member.Nachname)) } AS Name,
                    ISNULL(SUM(dbo.[Mitglieder.Dienste].multiplikator), 0) AS Dienste, ISNULL(SUM(DISTINCT CAE.C), 0) AS AEs
                FROM dbo.[Mitglieder.Mitglieder] Member LEFT OUTER JOIN
                    dbo.[Mitglieder.Dienste] ON Member.ID = dbo.[Mitglieder.Dienste].MitgliederID LEFT OUTER JOIN
                    (SELECT COUNT(dbo.[Mitglieder.AEs].MitgliederID) AS C, dbo.[Mitglieder.AEs].MitgliederID
                    FROM dbo.[Mitglieder.AEs] INNER JOIN
                        dbo.[Dienste.AE] ON dbo.[Mitglieder.AEs].AEID = dbo.[Dienste.AE].ID
                    WHERE        (dbo.[Dienste.AE].Beginn BETWEEN '20170101' AND '20200101')
                    GROUP BY dbo.[Mitglieder.AEs].MitgliederID) AS CAE ON Member.ID = CAE.MitgliederID LEFT OUTER JOIN
                    dbo.[Dienste.DienstTag] ON dbo.[Mitglieder.Dienste].DienstID = dbo.[Dienste.DienstTag].ID
                WHERE        (dbo.[Dienste.DienstTag].Datum BETWEEN '20170101' AND '20200101')
                GROUP BY Member.ID,Member.Vorname, Member.Nachname
                ORDER BY Name
                FOR JSON AUTO";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);

            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberViewDAModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<MemberViewDAModel>> {Value = result.Value};
        }

        public IResult<List<MemberViewDAGModel>> MemberDienstAufgabeGutscheine() {
            var query = @"SELECT Dienste.ID, Member.ID MID, AufgabeTyp.ID Aufgabe, Dienst.Datum Datum, Dienste.multiplikator multi,
                            Dienste.Putzen, Dienste.Bemerkung, Logins.ID LID, IsNull(GS.Betrag,0) As Gutscheine, Dienste.DienstID, 
	                        IsNull(Dienste.Bearbeiter, 0) Bearbeiter, IsNull(Dienste.Ersteller, 0) Ersteller, Dienste.Stand
                        FROM [Mitglieder.Mitglieder] Member INNER JOIN
                            [Mitglieder.Dienste] Dienste ON Member.ID = Dienste.MitgliederID INNER JOIN
                            [Dienste.DienstTag] Dienst ON Dienste.DienstID = Dienst.ID INNER JOIN
                            [Dienst.Aufgabe] AufgabeTyp ON Dienste.Aufgabe = AufgabeTyp.ID INNER JOIN
                            [Mitglieder.Logins] Logins ON Dienst.AV = Logins.ID LEFT OUTER JOIN
                            (SELECT MitgliederID, Betrag, DienstID
                            FROM [Mitglieder.Gutscheine]
                            WHERE        (Buchungstext LIKE '%Gutscheine für%')) AS GS ON Dienste.DienstID = GS.DienstID AND Dienste.MitgliederID = GS.MitgliederID
                        WHERE        (Dienst.Datum BETWEEN '20170101' AND '20200101')
                        ORDER BY Dienste.MitgliederID
                        For JSON PATH";

            var cmd = new SqlCommand(query, StaticSettings.SqlConn);

            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberViewDAGModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<MemberViewDAGModel>> {Value = result.Value};
        }
        public IResult<List<MemberViewDAGModel>> MemberDienstAufgabeGutscheine(string date_from, string date_to)
        {
            if (date_from.Length != 8 || date_to.Length != 8)
                return new FailureResult<List<MemberViewDAGModel>>(ErrorType.InconsistentData).AddMessage("format of \"date\" is invalid.");

            var query = $@"SELECT Dienste.ID, Member.ID MID, AufgabeTyp.ID Aufgabe, Dienst.Datum Datum, Dienste.multiplikator multi,
                            Dienste.Putzen, Dienste.Bemerkung, Logins.ID LID, IsNull(GS.Betrag,0) As Gutscheine, Dienste.DienstID, 
	                        IsNull(Dienste.Bearbeiter, 0) Bearbeiter, IsNull(Dienste.Ersteller, 0) Ersteller, Dienste.Stand
                        FROM [Mitglieder.Mitglieder] Member INNER JOIN
                            [Mitglieder.Dienste] Dienste ON Member.ID = Dienste.MitgliederID INNER JOIN
                            [Dienste.DienstTag] Dienst ON Dienste.DienstID = Dienst.ID INNER JOIN
                            [Dienst.Aufgabe] AufgabeTyp ON Dienste.Aufgabe = AufgabeTyp.ID INNER JOIN
                            [Mitglieder.Logins] Logins ON Dienst.AV = Logins.ID LEFT OUTER JOIN
                            (SELECT MitgliederID, Betrag, DienstID
                            FROM [Mitglieder.Gutscheine]
                            WHERE        (Buchungstext LIKE '%Gutscheine für%')) AS GS ON Dienste.DienstID = GS.DienstID AND Dienste.MitgliederID = GS.MitgliederID
                        WHERE        (Dienst.Datum BETWEEN '{date_from}' AND '{date_to}')
                        ORDER BY Dienste.MitgliederID
                        For JSON PATH";

            var cmd = new SqlCommand(query, StaticSettings.SqlConn);

            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberViewDAGModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<MemberViewDAGModel>> { Value = result.Value };
        }
        public IResult<List<MemberFullModel>> MemberViewFull() {
            var query = @"SELECT Member.ID, Member.Vorname, Member.Nachname, Member.Spitzname, [Mitglieder.Sex].SexType AS Geschlecht,
                            Member.Straße, Member.Nummer, Member.Zusatz, Member.PLZ, Member.Wohnort,
                            Member.Geburtstag, Member.[E-Mail], Member.Telefon, Member.Mobil, [Mitglieder.Status].Status,
                            Member.Aufgenomen, Member.Austritt, Member.Student, Member.Studienrichtung, Member.Hochschule,
                            Member.Bemerkung, Member.Status AS StatusID, Member.Sex AS SexID, Member.inaktiv, Member.Ersteller As ErstellerID,
                            Member.Bearbeiter As BearbeiterID, Member.Bearbeiter, Member.Stand
                        FROM [Mitglieder.Mitglieder] Member INNER JOIN
                            [Mitglieder.Sex] ON Member.Sex = [Mitglieder.Sex].ID INNER JOIN
                            [Mitglieder.Status] ON Member.Status = [Mitglieder.Status].ID
                        WHERE        (Member.ID > 999)
                FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);

            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<MemberFullModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<MemberFullModel>> {Value = result.Value};
        }

        public IResult<BindingList<MemberGutscheineViewModel>> MemberGutscheine() {
            var query = @"
                            SELECT  Gutscheine.ID, Member.ID MID, Gutscheine.DienstID,
                                    Gutscheine.Buchungstext, Gutscheine.Buchungstag, Gutscheine.Betrag, Gutscheine.ListNummer, Gutscheine.Bemerkung,
                                    Logins.ID As Bearbeiter, CreatorLogins.ID As Ersteller, Gutscheine.Stand

                            FROM    [Mitglieder.Gutscheine] Gutscheine INNER JOIN
                                    [Mitglieder.Mitglieder] Member ON Gutscheine.MitgliederID = Member.ID INNER JOIN
                                    [Mitglieder.Logins] Logins ON Gutscheine.Bearbeiter = Logins.ID  LEFT OUTER JOIN
                                    [Mitglieder.Logins] CreatorLogins ON Gutscheine.Ersteller = CreatorLogins.ID
                            
                            WHERE   (Gutscheine.Buchungstext LIKE '%Verbrauch%' or Gutscheine.Buchungstext LIKE '%Gutscheine für%')
                                    AND 
                                    (Gutscheine.Wertstellung BETWEEN '20170101' AND '20200101')
                    FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);

            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<BindingList<MemberGutscheineViewModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<BindingList<MemberGutscheineViewModel>> {Value = result.Value};
        }
        public IResult<BindingList<MemberGutscheineModel>> MemberGutscheine(int dienstId) {
            var query = @"
                    SELECT  ID, MitgliederID AS MID,
                            Buchungstext, Buchungstag, Betrag, ListNummer, Bemerkung,
							DienstID,
                            Bearbeiter, Ersteller, Stand
                    FROM    [Mitglieder.Gutscheine]
                    WHERE   DienstID = @ID
                    FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = dienstId;
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<BindingList<MemberGutscheineModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<BindingList<MemberGutscheineModel>> { Value = result.Value };
        }

        public IResult<List<AutoAnwaerter>> Auto_AnwaerterStatusMember()
        {
            var query = @"
                        SELECT        TB.ID , TB.Vorname, TB.Nachname, COUNT(dbo.[Mitglieder.Dienste].DienstID) AS Anzahl
                        FROM            dbo.[Mitglieder.Dienste] RIGHT OUTER JOIN
                                                     (SELECT        ID, Vorname, Nachname
                                                       FROM            dbo.[Mitglieder.Mitglieder]
                                                       WHERE        (Status = 11) AND (Straße IS NOT NULL) AND (Nummer IS NOT NULL) AND (PLZ IS NOT NULL) AND (Wohnort IS NOT NULL) AND (Mobil IS NOT NULL) AND ([E-Mail] IS NOT NULL) OR
                                                                                 (Status = 11) AND (Straße IS NOT NULL) AND (Nummer IS NOT NULL) AND (PLZ IS NOT NULL) AND (Wohnort IS NOT NULL) AND ([E-Mail] IS NOT NULL) AND (Mobil2 IS NOT NULL)) AS TB ON 
                                                 dbo.[Mitglieder.Dienste].MitgliederID = TB.ID
                        GROUP BY TB.Vorname, TB.Nachname, TB.ID
                        HAVING        (COUNT(dbo.[Mitglieder.Dienste].DienstID) >= 3)
                        ORDER BY Anzahl DESC
                        FOR JSON AUTO";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<AutoAnwaerter>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<AutoAnwaerter>> { Value = result.Value };

        }

        public IResult<List<NotVerifiedAnwärter>> Manual_NotVerifiedMember_GotAnwärterStatus()
        {
            var query = @"
                    SELECT        TOP (100) PERCENT TB.ID, TB.Vorname, TB.Nachname, COUNT(dbo.[Mitglieder.Dienste].DienstID) AS Anzahl, COUNT(dbo.[Mitglieder.AEs].MitgliederID) AS AE
                    FROM            dbo.[Mitglieder.Dienste] LEFT OUTER JOIN
                                             dbo.[Mitglieder.AEs] ON dbo.[Mitglieder.Dienste].ID = dbo.[Mitglieder.AEs].ID RIGHT OUTER JOIN
                                                 (SELECT        ID, Vorname, Nachname
                                                   FROM            dbo.[Mitglieder.Mitglieder]
                                                   WHERE        (Status = 14)) AS TB ON dbo.[Mitglieder.Dienste].MitgliederID = TB.ID
                    GROUP BY TB.Vorname, TB.Nachname, TB.ID
                    ORDER BY Anzahl DESC
                    FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
                jsonResult.Append("[]");
            else
                while (reader.Read())
                    jsonResult.Append(reader.GetValue(0));

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<NotVerifiedAnwärter>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<NotVerifiedAnwärter>> { Value = result.Value };

        }
    }
}