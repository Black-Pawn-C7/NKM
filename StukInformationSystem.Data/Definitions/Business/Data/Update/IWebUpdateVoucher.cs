using NKM.Base.Definition.Common.Result;
namespace StukInformationSystem.Data.Definitions.Business.Data.Update
{
    interface IWebUpdateVoucher
    { 
        IResult UpdateVoucher(double menge, int mitgliederId, int dienstId, int bereichId);
    }
}
