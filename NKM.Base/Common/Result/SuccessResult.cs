using NKM.Base.Definition.Enums;

namespace NKM.Base.Common.Result {
    public class SuccessResult : BaseResult {
        public SuccessResult() : base(ResultStatus.Success) { }
    }
}