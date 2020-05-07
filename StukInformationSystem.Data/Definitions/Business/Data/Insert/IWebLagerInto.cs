using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NKM.Base.Definition.Common.Result;

namespace StukInformationSystem.Data.Definitions.Business.Data.Insert
{
    public interface IWebLagerInto {
        IResult InsertFillBarlisten(int did, int BarID);
        IResult InsertIntoBarlisten(int did, int bereichId, int artikelId, double vor, double trans, double nach,double frei,double rollover);
        IResult InsertFillZaehlListe(int did, int bereichId, int type);
        IResult InsertTransfer(int artikelId, int bereichFrom, int bereichTo, int dId, int gebinde, double lose);
    }
}
