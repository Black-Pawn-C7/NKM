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
using StukInformationSystem.Data.Common.Models.Lager;
using StukInformationSystem.Data.Definitions.Business.Data.Selects.Lager;

namespace StukInformationSystem.Data.Business.Data.Selects.Lager {
    public class WebLagerSelects : IWebLagerSelects {
        public IResult<List<WebArtikelZaehlliste>> GetZaehlliste(int did,int bereichId,int type)
        {
            const string query = @"SELECT [Lager.ZaehlListe].ArtikelNr,Name,[Web.Lager.ZaehlListen].Voll,[Web.Lager.ZaehlListen].Offen,[Web.ArtikelEigenschaftenOverview].Voll AS VollId, [Web.ArtikelEigenschaftenOverview].Offen AS OffenId,Anreißer,VollEinheit,OffenEinheit FROM [Lager.ZaehlListe] inner join WebLagerBereichIndex WLBI on [Lager.ZaehlListe].Bereich = WLBI.Bereich inner join [Web.Lager.ZaehlListen] on ArtikelNr=ArtikelID inner join [Lager.Ware] on [Lager.ZaehlListe].ArtikelNr = [Lager.Ware].ArtikelNr left outer join [Web.ArtikelEigenschaftenOverview] on [Lager.ZaehlListe].ArtikelNr=[Web.ArtikelEigenschaftenOverview].ArtikelNr WHERE [Lager.Ware].inaktiv=0 AND [Lager.Ware].Deleted=0 AND BeinhaltetBereich=@bereich AND BereichID=@bereich AND Type=@type AND DienstID=@did ORDER BY Standort ,SortA FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
            cmd.Parameters.Add("@bereich", SqlDbType.Int).Value = bereichId;
            cmd.Parameters.Add("@type", SqlDbType.Int).Value = type;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<WebArtikelZaehlliste>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<WebArtikelZaehlliste>> { Value = result.Value };
        }
        public IResult<List<WebArtikelZaehlliste>> GeTransferArtikel(int bereichId)
        {
            const string query = @"SELECT [Lager.ZaehlListe].ArtikelNr,Name FROM [Lager.ZaehlListe]JOIN WebLagerBereichIndex [WLBI1]ON [Lager.ZaehlListe].Bereich=WLBI1.Bereich JOIN WebLagerBereichIndex [WLBI2] ON WLBI1.BeinhaltetBereich=WLBI2.Bereich JOIN [Lager.Ware] [LW] on [Lager.ZaehlListe].ArtikelNr = [LW].ArtikelNr WHERE WLBI2.BeinhaltetBereich=@bereich AND [LW].inaktiv=0 AND [LW].Deleted=0 FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@bereich", SqlDbType.Int).Value = bereichId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<WebArtikelZaehlliste>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<WebArtikelZaehlliste>> { Value = result.Value };
        }
        public IResult<List<ArtikelCount>> GetArtikelCountVerbrauch(int did, int bereichId)
        {
            var query = @"SELECT count(*) AS Artikel FROM [Web.Lager.VerbrauchBar] WHERE DienstID=@did AND BarID=@bereich FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
            cmd.Parameters.Add("@bereich", SqlDbType.Int).Value = bereichId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<ArtikelCount>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<ArtikelCount>> { Value = result.Value };
        }
        public IResult<List<ArtikelGebindeMulti>> GetArtikelMultiplicator()
        {
            var query = @"SELECT ArtikelNr,1 As '1',[Inneres-Gebinde] As '3',Lose AS '4' ,([Inneres-Gebinde]*Lose) AS '5' FROM [Web.Lager.ArtikelEigenschaften] FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<ArtikelGebindeMulti>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<ArtikelGebindeMulti>> { Value = result.Value };
        }
        public IResult<List<ArtikelCount>> GetArtikelCountZaehlListe(int did, int bereichId, int type)
        {
            var query = @"SELECT count(*) AS Artikel FROM [Web.Lager.ZaehlListen] WHERE DienstID=@did AND BereichID=@bereich AND Type=@type FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
            cmd.Parameters.Add("@bereich", SqlDbType.Int).Value = bereichId;
            cmd.Parameters.Add("@type", SqlDbType.Int).Value = type;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<ArtikelCount>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<ArtikelCount>> { Value = result.Value };
        }
        public IResult<List<ArtikelCount>> GetArtikelCount(int bereichId)
        {
            var query = @"SELECT COUNT([LW].ArtikelNr) AS Artikel FROM [Lager.ZaehlListe]JOIN WebLagerBereichIndex [WLBI1]ON [Lager.ZaehlListe].Bereich=WLBI1.Bereich JOIN WebLagerBereichIndex [WLBI2] ON WLBI1.BeinhaltetBereich=WLBI2.Bereich JOIN [Lager.Ware] [LW] on [Lager.ZaehlListe].ArtikelNr = [LW].ArtikelNr WHERE WLBI2.BeinhaltetBereich=@bereich AND [LW].inaktiv=0 AND [LW].Deleted=0 FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@bereich", SqlDbType.Int).Value = bereichId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<ArtikelCount>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<ArtikelCount>> { Value = result.Value };
        }
        public IResult<List<Bereiche>> GetBereiche()
        {
            var query = @"Select Bereich, BereichName FROM WebLagerBereichIndex inner join [Lager.Bereiche] on Bereich=[Lager.Bereiche].ID WHERE Bereich=BeinhaltetBereich FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<Bereiche>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<Bereiche>> { Value = result.Value };
        }
        public IResult<List<TransferProduct>> GetArtikelByName(string artikelName)
        {
            var query = @"SELECT ArtikelNr, Name FROM [Lager.Short] WHERE Name=@artikelName AND inaktiv=0 FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@artikelName", SqlDbType.NVarChar).Value = artikelName;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<TransferProduct>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<TransferProduct>> { Value = result.Value };
        }
        public IResult<List<TransferTotal>> GetTransferTotalFrom(int did, int bereichId)
        {
            const string query = @"SELECT [Web.Lager.Transfer].ArtikelID,SUM([Web.Lager.Transfer].Gebinde)AS GebindeTotal,Sum([Web.Lager.Transfer].Lose)AS LoseTotal,[W.TEO].Gebinde AS GebindeID,[W.TEO].Lose AS LoseID,Anreißer,GebindeEinheit,LoseEinheit  FROM [Web.Lager.Transfer]inner join [Web.TransferEigenschaftenOverview] [W.TEO] on [Web.Lager.Transfer].ArtikelID = [W.TEO].ArtikelNr WHERE DienstID=@did AND BereichFrom=@bereich GROUP BY ArtikelID,[W.TEO].Gebinde,[W.TEO].Lose,Anreißer,GebindeEinheit,LoseEinheit FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
            cmd.Parameters.Add("@bereich", SqlDbType.Int).Value = bereichId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<TransferTotal>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<TransferTotal>> { Value = result.Value };
        }
        public IResult<List<TransferTotal>> GetTransferTotalTo(int did, int bereichId)
        {
            const string query = @"SELECT [Web.Lager.Transfer].ArtikelID,SUM([Web.Lager.Transfer].Gebinde)AS GebindeTotal,Sum([Web.Lager.Transfer].Lose)AS LoseTotal,[W.TEO].Gebinde AS GebindeID,[W.TEO].Lose AS LoseID,Anreißer,GebindeEinheit,LoseEinheit  FROM [Web.Lager.Transfer]inner join [Web.TransferEigenschaftenOverview] [W.TEO] on [Web.Lager.Transfer].ArtikelID = [W.TEO].ArtikelNr WHERE DienstID=@did AND BereichTo=@bereich GROUP BY ArtikelID,[W.TEO].Gebinde,[W.TEO].Lose,Anreißer,GebindeEinheit,LoseEinheit FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
            cmd.Parameters.Add("@bereich", SqlDbType.Int).Value = bereichId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<TransferTotal>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<TransferTotal>> { Value = result.Value };
        }
        public IResult<List<Artikel>> GetTransferArtikel(int did, int bereichId)
        {
            const string query = @"SELECT DISTINCT [Web.Lager.Transfer].ArtikelID AS ArtikelNr FROM [Web.Lager.Transfer]inner join [Web.TransferEigenschaftenOverview] [W.TEO] on [Web.Lager.Transfer].ArtikelID = [W.TEO].ArtikelNr WHERE DienstID=@did AND (BereichTo=@bereich OR BereichFrom=@bereich) FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@did", SqlDbType.Int).Value = did;
            cmd.Parameters.Add("@bereich", SqlDbType.Int).Value = bereichId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<Artikel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<Artikel>> { Value = result.Value };
        }
        public IResult<List<TransferProductMeta>> GetArtikelMeta(int artikelId)
        {
            var query = @"SELECT Anreißer,GebindeEinheit,LoseEinheit FROM [Web.TransferEigenschaftenOverview] WHERE ArtikelNr=@artikel FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@artikel", SqlDbType.Int).Value = artikelId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<TransferProductMeta>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<TransferProductMeta>> { Value = result.Value };
        }
        public IResult<List<ArtikelMenge>> GetConsumptionTotal(int dId,int bereichId)
        {
            const string query = @"SELECT ArtikelID,CAST(Sum(Amount)*MengeVerkauf*Lose AS decimal(6,2))AS Menge FROM [Web.Consumption] inner join [Lager.Ware] on ArtikelID=ArtikelNr inner join [Web.Lager.ArtikelEigenschaften] [W.L.AE] on [Lager.Ware].ArtikelNr = [W.L.AE].ArtikelNr WHERE DID=@did AND BarID=@bereich GROUP BY ArtikelID, MengeVerkauf,Lose FOR JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@did", SqlDbType.Int).Value = dId;
            cmd.Parameters.Add("@bereich", SqlDbType.Int).Value = bereichId;
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

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<ArtikelMenge>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess() ? result : new SuccessResult<List<ArtikelMenge>> { Value = result.Value };
        }
    }
}
