using System.Collections.Generic;
using NKM.Base.Definition.Common.Result;
using StukInformationSystem.Data.Common.Models.Lager;

namespace StukInformationSystem.Data.Definitions.Business.Data.Selects.Lager {
    public interface IArtikelViewEdit {

        IResult<List<ArtikelViewModel>> ArtikelViewModelFull();
        IResult<List<ArtikelViewModel>> ArtikelViewModelNormal();
        IResult<List<ArtikelViewModel>> ArtikelViewModelJustDeleted();

        IResult<List<ArtikelViewModel>> ArtikelArtViewModel();
        
    }
}