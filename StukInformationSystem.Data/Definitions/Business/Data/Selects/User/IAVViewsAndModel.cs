using System;
using NKM.Base.Definition.Common.Result;
using Xuser = NKM.File.Common.Person.User;
namespace StukInformationSystem.Data.Definitions.Business.Data.Selects.User
{
    public interface IAVViewsAndModel
    {
        IResult<double> AVDiensteGesamt(Xuser valUser);       
        IResult<DateTime> LastAVDienst(Xuser valUser);
        IResult<DateTime> FirstAVDienst(Xuser valUser);
        IResult<bool> GroßesAVRecht(Xuser valUser);
    }
}