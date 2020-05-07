using NKM.Base.Definition.Enums;

namespace NKM.Base.Common.Result {
    public class SuccessResult<TEntity> : BaseResult<TEntity> {
        public SuccessResult() : base(ResultStatus.Success) { }
    }
}