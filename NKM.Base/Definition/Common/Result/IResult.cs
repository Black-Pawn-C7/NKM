using System.Collections.Generic;
using NKM.Base.Definition.Enums;

namespace NKM.Base.Definition.Common.Result {
    public interface IResult {
        ResultStatus Status { get; }

        ErrorType ErrorType { get; set; }

        IList<string> ResultMessages { get; }

        IResult AddMessage(string message);
    }
}