using NKM.Base.Definition.Common.Result;
namespace StukInformationSystem.Data.Definitions.Business.Data.Update
{
    interface IWebUpdateConsumption
    { 
        IResult UpdateWareConsumption(int menge, int artikelId, int typeId, int dienstID, int bereichId);
    }
}
