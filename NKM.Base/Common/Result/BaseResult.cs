using System.Collections.Generic;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;

namespace NKM.Base.Common.Result {
    public class BaseResult : IResult {
        public BaseResult() {
            ClassType = GetType().Name;
            Status = ResultStatus.Failure;
            ResultMessages = new List<string>();
        }

        public BaseResult(ResultStatus status) {
            ClassType = GetType().Name;
            Status = status;
            ErrorType = ErrorType.Unknown;
            ResultMessages = new List<string>();
        }

        public string ClassType { get; }

        public virtual ResultStatus Status { get; set; }

        public ErrorType ErrorType { get; set; }

        public virtual IList<string> ResultMessages { get; set; }

        public IResult AddMessage(string message) {
            if (!string.IsNullOrWhiteSpace(message)) ResultMessages.Add(message);
            return this;
        }
    }
}