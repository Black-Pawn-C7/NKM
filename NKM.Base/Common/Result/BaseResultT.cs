using System.Collections.Generic;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;

namespace NKM.Base.Common.Result {
    public class BaseResult<TEntity> : BaseResult, IResult<TEntity>, IResult {
        public BaseResult() {
            Status = ResultStatus.Failure;
            ResultMessages = new List<string>();
        }

        public BaseResult(ResultStatus status) : base(status) { }

        public TEntity Value { get; set; }

        public new IResult<TEntity> AddMessage(string message) {
            if (!string.IsNullOrWhiteSpace(message)) ResultMessages.Add(message);
            return this;
        }
    }
}