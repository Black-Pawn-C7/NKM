using NKM.Base.Common.Extensions;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Models.Lager;
using StukInformationSystem.Data.Definitions.Business.Converter;
using StukInformationSystem.Data.Definitions.Business.Data.Selects.Lager;
using StukInformationSystem.Data.Resources;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StukInformationSystem.Data.Business.Data.Selects.Lager
{
    public class ArtikelArtGet : IArtikelArtGet
    {

        public IResult<List<ArtikelArtViewModel>> ArtikelArtViewModelFull()
        {

            var query = @"Select ID, ArtikelArt from [Lager.ArtikelArt] FOR JSON PATH";
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
            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<ArtikelArtViewModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();

            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<ArtikelArtViewModel>>
                {
                    Value = result.Value
                };
        }
        public IResult<List<ArtikelArtViewModel>> ArtikelArtViewModelNormal()
        { throw new System.NotImplementedException(); }

    }
}
