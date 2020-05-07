using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;

namespace StukInformationSystem.Data.Business.Automation {
    public static class VollVersammlung {

        public static IResult Mitglieder_Status_Auto() {
            return new FailureResult(ErrorType.InternalError);
        }

        public static IResult Mitglieder_Anwärter() {
            return new FailureResult(ErrorType.InternalError);
        }

        public static IResult Clubrat_SommerVV() {
            return new FailureResult(ErrorType.InternalError);
        }
    }
}