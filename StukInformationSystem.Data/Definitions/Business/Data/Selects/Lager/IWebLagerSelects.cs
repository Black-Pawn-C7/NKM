using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Models.Lager;

namespace StukInformationSystem.Data.Definitions.Business.Data.Selects.Lager
{
    public interface IWebLagerSelects {
        IResult<List<WebArtikelZaehlliste>> GetZaehlliste(int did, int bereichId, int type);
        IResult<List<ArtikelCount>> GetArtikelCountVerbrauch(int did, int bereichId);
        IResult<List<ArtikelGebindeMulti>> GetArtikelMultiplicator();
        IResult<List<ArtikelCount>> GetArtikelCountZaehlListe(int did, int bereichId, int type);
        IResult<List<ArtikelCount>> GetArtikelCount(int bereichId);
        IResult<List<Bereiche>> GetBereiche();
    }
}
