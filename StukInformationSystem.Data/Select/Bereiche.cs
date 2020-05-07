using System.Data;
using System.Data.SqlClient;
using StukInformationSystem.Data.Resources;

namespace StukInformationSystem.Data.Select {
    public static class Bereiche {
        public static string GetBereichName(int id) {
            var rt = "";
            const string query = "SET LANGUAGE german Select BereichName From [Lager.Bereiche] Where ID = @xID";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            cmd.Parameters.Add("@xID", SqlDbType.Int).Value = id;
            try {
                StaticSettings.SqlConn.Open();
                var r = cmd.ExecuteReader();
                while (r.Read()) rt = (string) r[0];
                r.Close();
            } finally {
                StaticSettings.SqlConn.Close();
            }

            return rt;
        }
    }
}