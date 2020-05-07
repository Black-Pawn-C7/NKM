using NKM.Base.Definition.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StukInformationSystem.Data.Definitions.Business.Data.Delete {
    public interface IDeleteFromDienst {
        IResult DeleteAll(int id);
        IResult DeleteDienst(int id);
        IResult DeleteGutscheine(int id);
        IResult DeleteDienste(int id);
        IResult DeleteVerbrauch(int id);
        IResult DeleteAbrechnung(int id);
    }
}
