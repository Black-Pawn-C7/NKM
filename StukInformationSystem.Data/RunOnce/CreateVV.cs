using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;

namespace StukInformationSystem.Data.RunOnce
{
    public class CreateVV
    {
        private static readonly SqlConnection sqlConn = new SqlConnection("Data Source=db.nkm.xn;Initial Catalog=StuK_DB;User ID=sa;Password=orFe#3<%Ut5?kjbj");
        private int Wert = 9293;
        private int add = 101;

        public IResult Start()
        {
            var VVList = CalcVV().Value;
            DeleteExisting();

            foreach (var v in VVList)
            {
                ErstelleVV(v);
            }

            foreach (var c in CreateClubrat().Value) {
                ErstelleKlubrat(c);
            }

            foreach (var cr in CurrentKlubrat().Value) {
                ErstelleCurrentKlubrat(cr);
            }

            return new SuccessResult();
        }

        private IResult DeleteExisting()
        {
            const string sqlCommand = "Delete From [Mitglieder.Status.Aenderung]; Delete FROM [Mitglieder.Clubrat.Verlauf]; Delete From [Mitglieder.VV]; ";
            var cmd = new SqlCommand(sqlCommand, sqlConn);

            sqlConn.Open();
            cmd.ExecuteNonQuery();

            sqlConn.Close();

            return new SuccessResult();
        }

        private IResult ErstelleVV(NewVV vv)
        {
            const string sqlCommand = "Insert Into [Mitglieder.VV] (ID, Tag, Protokol, WS, Ersteller, Bearbeiter, Stand) " +
                                      "Values (@iid, @day, @proto, @wss, @erst, @bear, @std)";
            var cmd = new SqlCommand(sqlCommand, sqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@iid", SqlDbType.Int).Value = vv.VVID;
                withBlock.Add("@day", SqlDbType.DateTime).Value = vv.TagDate;
                withBlock.Add("@proto", SqlDbType.VarBinary).Value = vv.Protokoll;
                withBlock.Add("@wss", SqlDbType.Bit).Value = vv.WS;
                withBlock.Add("@erst", SqlDbType.Int).Value = 1;
                withBlock.Add("@bear", SqlDbType.Int).Value = 1;
                withBlock.Add("@std", SqlDbType.DateTime).Value = DateTime.UtcNow;
            }

            sqlConn.Open();
            cmd.ExecuteNonQuery();

            sqlConn.Close();

            return new SuccessResult();
        }

        private IResult ErstelleKlubrat(NewKlubrat cr) {
            const string sqlCommand = "Insert Into [Mitglieder.Clubrat.Verlauf] (MID, Posten, Beginn, Ende, VVID, DreierSpitze, Bearbeiter, Ersteller, Stand  ) " +
                                      "Values (@mid, @post, @beg, @ende, @vvid, @dreis, @erst, @bear, @std)";
            var cmd = new SqlCommand(sqlCommand, sqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@mid", SqlDbType.Int).Value = cr.mitgliederID;
                withBlock.Add("@post", SqlDbType.Int).Value = cr.postenID;
                withBlock.Add("@beg", SqlDbType.DateTime).Value = cr.beginn;
                withBlock.Add("@ende", SqlDbType.DateTime).Value = cr.ende;
                withBlock.Add("@vvid", SqlDbType.Int).Value = cr.vvid;
                withBlock.Add("@dreis", SqlDbType.Bit).Value = cr.dreier;
                withBlock.Add("@erst", SqlDbType.Int).Value = 1;
                withBlock.Add("@bear", SqlDbType.Int).Value = 1;
                withBlock.Add("@std", SqlDbType.DateTime).Value = DateTime.UtcNow;
            }

            sqlConn.Open();
            cmd.ExecuteNonQuery();

            sqlConn.Close();

            return new SuccessResult();
        }
        private IResult ErstelleCurrentKlubrat(NewKlubrat ccr)
        {
            const string sqlCommand = "Insert Into [Mitglieder.Clubrat.Verlauf] (MID, Posten, Beginn, VVID, DreierSpitze, Bearbeiter, Ersteller, Stand  ) " +
                                      "Values (@mid, @post, @beg, @vvid, @dreis, @erst, @bear, @std)";
            var cmd = new SqlCommand(sqlCommand, sqlConn);
            {
                var withBlock = cmd.Parameters;
                withBlock.Add("@mid", SqlDbType.Int).Value = ccr.mitgliederID;
                withBlock.Add("@post", SqlDbType.Int).Value = ccr.postenID;
                withBlock.Add("@beg", SqlDbType.DateTime).Value = ccr.beginn;
                withBlock.Add("@vvid", SqlDbType.Int).Value = ccr.vvid;
                withBlock.Add("@dreis", SqlDbType.Bit).Value = ccr.dreier;
                withBlock.Add("@erst", SqlDbType.Int).Value = 1;
                withBlock.Add("@bear", SqlDbType.Int).Value = 1;
                withBlock.Add("@std", SqlDbType.DateTime).Value = DateTime.UtcNow;
            }

            sqlConn.Open();
            cmd.ExecuteNonQuery();

            sqlConn.Close();

            return new SuccessResult();
        }
        private IResult<List<NewVV>> CalcVV()
        {
            var Result = new List<NewVV>();
            var random = new Random();
            var vvSS1997 = new NewVV(random) { VVID = Wert, TagDate = new DateTime(1997, 6, 2) };
            Result.Add(vvSS1997);
            Wert += add;
            var vvWS1997 = new NewVV(random) { WS = true, VVID = Wert, TagDate = new DateTime(1997, 10, 27) };
            Result.Add(vvWS1997);
            Wert += add;

            for (var i = 1998; i <= 2015; i++)
            {
                var vvSS = new NewVV(random) { VVID = Wert, TagDate = new DateTime(i, 4, 28) };
                Result.Add(vvSS);
                Wert += add;
                var vvWS = new NewVV(random) { WS = true, VVID = Wert, TagDate = new DateTime(i, 10, 27) };
                Result.Add(vvWS);
                Wert += add;
            }

            NewVV vvA2016;
            vvA2016 = new NewVV(random) { VVID = Wert, TagDate = new DateTime(2016, 4, 27) };
            Result.Add(vvA2016);
            Wert += add;
            vvA2016 = new NewVV(random) { VVID = Wert, TagDate = new DateTime(2016, 10, 26), WS = true };
            Result.Add(vvA2016);
            Wert += add;
            vvA2016 = new NewVV(random) { VVID = Wert, TagDate = new DateTime(2017, 4, 26) };
            Result.Add(vvA2016);
            Wert += add;
            vvA2016 = new NewVV(random) { VVID = Wert, TagDate = new DateTime(2017, 10, 28), WS = true };
            Result.Add(vvA2016);
            Wert += add;
            vvA2016 = new NewVV(random) { VVID = Wert, TagDate = new DateTime(2018, 4, 28) };
            Result.Add(vvA2016);
            Wert += add;
            vvA2016 = new NewVV(random) { VVID = Wert, TagDate = new DateTime(2018, 10, 27), WS = true };
            Result.Add(vvA2016);
            Wert += add;
            vvA2016 = new NewVV(random) { VVID = Wert, TagDate = new DateTime(2019, 4, 27) };
            Result.Add(vvA2016);
            Wert += add;

            return new SuccessResult<List<NewVV>>() { Value = Result };
        }

        private IResult<List<NewKlubrat>> CreateClubrat()
        {
            var result = new List<NewKlubrat>();
            NewKlubrat nc;
            // VV 10/2015
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16339, postenID = 02, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27,23,59,59), dreier = true };  result.Add(nc); //Buch
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16184, postenID = 03, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2015, 10, 27,23,59,59) };  result.Add(nc); //Kasse
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16446, postenID = 04, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27,23,59,59), dreier = true};  result.Add(nc); //EDV
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16388, postenID = 05, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27,23,59,59) };  result.Add(nc); //Einlass
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16417, postenID = 06, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27,23,59,59) };  result.Add(nc); //Form
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16448, postenID = 07, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27,23,59,59) };  result.Add(nc); //Gastro
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16275, postenID = 08, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27,23,59,59), dreier = true };  result.Add(nc); //Haus
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16316, postenID = 09, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27,23,59,59) };  result.Add(nc); //Lager
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16451, postenID = 10, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27,23,59,59) };  result.Add(nc); //Dienste
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16481, postenID = 11, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27,23,59,59) };  result.Add(nc); //Öffi
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16416, postenID = 12, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2015, 10, 27,23,59,59) };  result.Add(nc); //Ruti 1
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 15958, postenID = 13, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27,23,59,59) };  result.Add(nc); //Ruti 2
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16407, postenID = 14, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27,23,59,59) };  result.Add(nc); //Vereinsleben
            nc = new NewKlubrat { vvid = 12929, mitgliederID = 16341, postenID = 15, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27,23,59,59) };  result.Add(nc); //Vermietung

            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16339, postenID = 02, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27, 23, 59, 59), dreier = true };  result.Add(nc); //Buch
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16495, postenID = 03, beginn = new DateTime(2015, 10, 28), ende = new DateTime(2016, 4, 27, 23, 59, 59) };  result.Add(nc); //Kasse
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16446, postenID = 04, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27, 23, 59, 59), dreier = true };  result.Add(nc); //EDV
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16388, postenID = 05, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27, 23, 59, 59) };  result.Add(nc); //Einlass
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16417, postenID = 06, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27, 23, 59, 59) };  result.Add(nc); //Form
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16448, postenID = 07, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27, 23, 59, 59) };  result.Add(nc); //Gastro
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16275, postenID = 08, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27, 23, 59, 59), dreier = true };  result.Add(nc); //Haus
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16316, postenID = 09, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27, 23, 59, 59) };  result.Add(nc); //Lager
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16451, postenID = 10, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27, 23, 59, 59) };  result.Add(nc); //Dienste
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16481, postenID = 11, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27, 23, 59, 59) };  result.Add(nc); //Öffi
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16460, postenID = 12, beginn = new DateTime(2015, 10, 28), ende = new DateTime(2016, 4, 27, 23, 59, 59) };  result.Add(nc); //Ruti 1
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 15958, postenID = 13, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27, 23, 59, 59) };  result.Add(nc); //Ruti 2
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16407, postenID = 14, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27, 23, 59, 59) };  result.Add(nc); //Vereinsleben
            nc = new NewKlubrat { vvid = 13030, mitgliederID = 16341, postenID = 15, beginn = new DateTime(2015, 04, 29), ende = new DateTime(2016, 4, 27, 23, 59, 59) };  result.Add(nc); //Vermietung


            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16339, postenID = 02, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017,  4, 26, 23, 59, 59), dreier = true };  result.Add(nc); //Buch
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16495, postenID = 03, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017,  4, 26, 23, 59, 59), dreier = true };  result.Add(nc); //Kasse
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16446, postenID = 04, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2016, 10, 26, 23, 59, 59)};  result.Add(nc); //EDV
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16350, postenID = 05, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017,  4, 26, 23, 59, 59) };  result.Add(nc); //Einlass
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16461, postenID = 06, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017,  4, 26, 23, 59, 59), dreier = true };  result.Add(nc); //Form
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16489, postenID = 07, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017,  4, 26, 23, 59, 59) };  result.Add(nc); //Gastro
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16535, postenID = 08, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017,  4, 26, 23, 59, 59)};  result.Add(nc); //Haus
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16316, postenID = 09, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2016, 10, 26, 23, 59, 59) };  result.Add(nc); //Lager
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16505, postenID = 10, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2016, 10, 26, 23, 59, 59) };  result.Add(nc); //Dienste
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16140, postenID = 11, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017,  4, 26, 23, 59, 59) };  result.Add(nc); //Öffi
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16460, postenID = 12, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2016, 10, 26, 23, 59, 59) };  result.Add(nc); //Ruti 1
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 15958, postenID = 13, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017,  4, 26, 23, 59, 59) };  result.Add(nc); //Ruti 2
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16451, postenID = 14, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017,  4, 26, 23, 59, 59) };  result.Add(nc); //Vereinsleben
            nc = new NewKlubrat { vvid = 13131, mitgliederID = 16341, postenID = 15, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017,  4, 26, 23, 59, 59) };  result.Add(nc); //Vermietung

            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16339, postenID = 02, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017, 4, 27, 23, 59, 59), dreier = true };  result.Add(nc); //Buch
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16495, postenID = 03, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017, 4, 27, 23, 59, 59), dreier = true };  result.Add(nc); //Kasse
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16507, postenID = 04, beginn = new DateTime(2016, 10, 27), ende = new DateTime(2017, 4, 27, 23, 59, 59) };  result.Add(nc); //EDV
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16350, postenID = 05, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017, 4, 27, 23, 59, 59) };  result.Add(nc); //Einlass
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16461, postenID = 06, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017, 4, 27, 23, 59, 59), dreier = true };  result.Add(nc); //Form
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16489, postenID = 07, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017, 4, 27, 23, 59, 59) };  result.Add(nc); //Gastro
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16535, postenID = 08, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017, 4, 27, 23, 59, 59) };  result.Add(nc); //Haus
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16552, postenID = 09, beginn = new DateTime(2016, 10, 27), ende = new DateTime(2017, 4, 27, 23, 59, 59) };  result.Add(nc); //Lager
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16510, postenID = 10, beginn = new DateTime(2016, 10, 27), ende = new DateTime(2017, 4, 27, 23, 59, 59) };  result.Add(nc); //Dienste
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16140, postenID = 11, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017, 4, 27, 23, 59, 59) };  result.Add(nc); //Öffi
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 15958, postenID = 12, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017, 4, 27, 23, 59, 59) };  result.Add(nc); //Ruti 1
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16519, postenID = 13, beginn = new DateTime(2016, 10, 27), ende = new DateTime(2017, 4, 27, 23, 59, 59) };  result.Add(nc); //Ruti 2
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16451, postenID = 14, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017, 4, 27, 23, 59, 59) };  result.Add(nc); //Vereinsleben
            nc = new NewKlubrat { vvid = 13232, mitgliederID = 16341, postenID = 15, beginn = new DateTime(2016, 4, 28), ende = new DateTime(2017, 4, 27, 23, 59, 59) };  result.Add(nc); //Vermietung

            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16339, postenID = 02, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59), dreier = true };  result.Add(nc); //Buch
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16519, postenID = 03, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59)};  result.Add(nc); //Kasse
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16507, postenID = 04, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //EDV
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16522, postenID = 05, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Einlass
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16461, postenID = 06, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59), dreier = true };  result.Add(nc); //Form
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16489, postenID = 07, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59), dreier = true };  result.Add(nc); //Gastro
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16536, postenID = 08, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Haus
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16559, postenID = 09, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Lager
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16510, postenID = 10, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Dienste
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16140, postenID = 11, beginn = new DateTime(2017, 4,27), ende = new DateTime(2017, 10, 28, 23, 59, 59) };  result.Add(nc); //Öffi
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 15958, postenID = 12, beginn = new DateTime(2017, 4,27), ende = new DateTime(2017, 10, 28, 23, 59, 59) };  result.Add(nc); //Ruti 1
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16275, postenID = 13, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Ruti 2
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16482, postenID = 14, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Vereinsleben
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16341, postenID = 15, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Vermietung
            nc = new NewKlubrat { vvid = 13333, mitgliederID = 16450, postenID = 16, beginn = new DateTime(2017, 4,27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Mitgliederwerbung

            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16339, postenID = 02, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59), dreier = true };  result.Add(nc); //Buch
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16519, postenID = 03, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Kasse
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16507, postenID = 04, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //EDV
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16522, postenID = 05, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Einlass
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16461, postenID = 06, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59), dreier = true };  result.Add(nc); //Form
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16489, postenID = 07, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59), dreier = true };  result.Add(nc); //Gastro
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16536, postenID = 08, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Haus
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16559, postenID = 09, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Lager
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16510, postenID = 10, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Dienste
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16598, postenID = 11, beginn = new DateTime(2017, 10, 29), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Öffi
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16275, postenID = 12, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Ruti 1
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16575, postenID = 13, beginn = new DateTime(2017, 10, 29), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Ruti 2
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16482, postenID = 14, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Vereinsleben
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16341, postenID = 15, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Vermietung
            nc = new NewKlubrat { vvid = 13434, mitgliederID = 16450, postenID = 16, beginn = new DateTime(2017, 4, 27), ende = new DateTime(2018, 4, 28, 23, 59, 59) };  result.Add(nc); //Mitgliederwerbung

            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16339, postenID = 02, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59), dreier = true };  result.Add(nc); //Buch
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16461, postenID = 03, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59), dreier = true };  result.Add(nc); //Kasse
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16507, postenID = 04, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //EDV
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16522, postenID = 05, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Einlass
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16575, postenID = 06, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59)};  result.Add(nc); //Form
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16510, postenID = 07, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59), dreier = true };  result.Add(nc); //Gastro
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16536, postenID = 08, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Haus
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16559, postenID = 09, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Lager
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16588, postenID = 10, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Dienste
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16598, postenID = 11, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Öffi
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16275, postenID = 12, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Ruti 1
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16628, postenID = 13, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2018, 10, 27, 23, 59, 59) };  result.Add(nc); //Ruti 2
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16482, postenID = 14, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Vereinsleben
            nc = new NewKlubrat { vvid = 13535, mitgliederID = 16341, postenID = 15, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Vermietung

            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16339, postenID = 02, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59), dreier = true };  result.Add(nc); //Buch
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16461, postenID = 03, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59), dreier = true };  result.Add(nc); //Kasse
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16507, postenID = 04, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //EDV
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16522, postenID = 05, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Einlass
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16575, postenID = 06, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Form
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16510, postenID = 07, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59), dreier = true };  result.Add(nc); //Gastro
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16536, postenID = 08, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Haus
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16559, postenID = 09, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Lager
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16588, postenID = 10, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Dienste
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16598, postenID = 11, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Öffi
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16275, postenID = 12, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Ruti 1
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16644, postenID = 13, beginn = new DateTime(2018, 10, 28), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Ruti 2
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16482, postenID = 14, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Vereinsleben
            nc = new NewKlubrat { vvid = 13636, mitgliederID = 16341, postenID = 15, beginn = new DateTime(2018, 4, 27), ende = new DateTime(2019, 4, 27, 23, 59, 59) };  result.Add(nc); //Vermietung

            return new SuccessResult<List<NewKlubrat>> { Value = result};
        }

        private IResult<List<NewKlubrat>> CurrentKlubrat() {
            var result = new List<NewKlubrat>();
            NewKlubrat nc;
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16597, postenID = 02, beginn = new DateTime(2019, 4, 28), dreier = true }; result.Add(nc); //Buch
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16737, postenID = 03, beginn = new DateTime(2019, 4, 28), dreier = true }; result.Add(nc); //Kasse
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16543, postenID = 05, beginn = new DateTime(2019, 4, 28) }; result.Add(nc); //Einlass
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16575, postenID = 06, beginn = new DateTime(2019, 4, 28) }; result.Add(nc); //Form
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16510, postenID = 07, beginn = new DateTime(2019, 4, 28), dreier = true }; result.Add(nc); //Gastro
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16536, postenID = 08, beginn = new DateTime(2019, 4, 28) }; result.Add(nc); //Haus
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16733, postenID = 09, beginn = new DateTime(2019, 4, 28) }; result.Add(nc); //Lager
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16490, postenID = 10, beginn = new DateTime(2019, 4, 28) }; result.Add(nc); //Dienste
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16598, postenID = 11, beginn = new DateTime(2019, 4, 28) }; result.Add(nc); //Öffi
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16644, postenID = 12, beginn = new DateTime(2019, 4, 28) }; result.Add(nc); //Ruti 1
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16495, postenID = 13, beginn = new DateTime(2019, 4, 28) }; result.Add(nc); //Ruti 2
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16619, postenID = 14, beginn = new DateTime(2019, 4, 28) }; result.Add(nc); //Vereinsleben
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16489, postenID = 15, beginn = new DateTime(2019, 4, 28) }; result.Add(nc); //Vermietung
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16764, postenID = 17, beginn = new DateTime(2019, 4, 28) }; result.Add(nc); //IT Services
            nc = new NewKlubrat { vvid = 13737, mitgliederID = 16680, postenID = 18, beginn = new DateTime(2019, 4, 28) }; result.Add(nc); //Audio Technik
            return new SuccessResult<List<NewKlubrat>> { Value = result };
        }
    }
}