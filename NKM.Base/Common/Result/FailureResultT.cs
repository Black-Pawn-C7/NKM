using NKM.Base.Definition.Enums;

namespace NKM.Base.Common.Result {
    public class FailureResult<TEntity> : BaseResult<TEntity> {
        public FailureResult() : base(ResultStatus.Failure) {
            ErrorType = ErrorType.InternalError;
        }

        public FailureResult(ErrorType errorType) : base(ResultStatus.Failure) {
            ErrorType = errorType;
        }
    }
}