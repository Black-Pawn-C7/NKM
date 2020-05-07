using System.Collections.Generic;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Models.Lager;

namespace StukInformationSystem.Data.Definitions.Business.Data.Selects.Lager
{
    public interface IArtikelArtGet
    {
        IResult<List<ArtikelArtViewModel>> ArtikelArtViewModelFull();
        IResult<List<ArtikelArtViewModel>> ArtikelArtViewModelNormal();

    }
}
