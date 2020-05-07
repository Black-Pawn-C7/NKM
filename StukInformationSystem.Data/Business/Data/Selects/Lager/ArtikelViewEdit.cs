using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using NKM.Base.Common.Extensions;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Models.Lager;
using StukInformationSystem.Data.Definitions.Business.Converter;
using StukInformationSystem.Data.Definitions.Business.Data.Selects.Lager;
using StukInformationSystem.Data.Resources;

namespace StukInformationSystem.Data.Business.Data.Selects.Lager {
    public class ArtikelViewEdit : IArtikelViewEdit
    {
        [Obsolete("Use DataSet instead")]
        public IResult<List<ArtikelViewModel>> ArtikelViewModelFull()
        {
            const string query = @"SELECT *  FROM [StuK_DB].[dbo].[ArtikelAnsicht]
                                   For JSON PATH";
            var cmd = new SqlCommand(query, StaticSettings.SqlConn);
            
            StaticSettings.SqlConn.Open();
            var jsonResult = new StringBuilder();
            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    jsonResult.Append(reader.GetValue(0));
                }
            }
            else
            {
                jsonResult.Append("[]");
            }

            var result = DataIoc.Ioc.GetInstance<IJsonSerializerDeserialize>().FromJson<List<ArtikelViewModel>>(jsonResult.ToString());
            StaticSettings.SqlConn.Close();
            return !result.IsSuccess()
                ? result
                : new SuccessResult<List<ArtikelViewModel>> { Value = result.Value };
        }
        [Obsolete("Use DataSet instead")]
        public IResult<List<ArtikelViewModel>> ArtikelViewModelNormal() {
            throw new System.NotImplementedException();
        }
        [Obsolete("Use DataSet instead")]
        public IResult<List<ArtikelViewModel>> ArtikelViewModelJustDeleted() {
            throw new System.NotImplementedException();
        }
        [Obsolete("Use DataSet instead")]
        public IResult<List<ArtikelViewModel>> ArtikelArtViewModel() {
            throw new System.NotImplementedException();
        }
    }
}