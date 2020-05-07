using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;

namespace StukInformationSystem.Data.Jobs
{
    public static class OncePerWeek
    {
        public static IResult HabenNeueMitgliederDenAnwärterStatus()
        {
            return new FailureResult();
        }
       
        public static IResult SindHausverboteAbgelaufen()
        {
            return new FailureResult();
        }

        public static IResult DerWarenbestandIstUnterMin()
        {
            return new FailureResult();
        }
    }
}
