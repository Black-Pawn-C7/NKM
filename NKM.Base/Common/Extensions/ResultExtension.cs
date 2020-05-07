using System;
using System.Linq;
using NKM.Base.Common.Result;
using NKM.Base.Definition.Common.Result;
using NKM.Base.Definition.Enums;

namespace NKM.Base.Common.Extensions {
    public static class ResultExtension {
        public static IResult<TEntity> ToSuccessResult<TEntity>(this IResult<TEntity> failureResult) {
            var result = new SuccessResult<TEntity> {
                Value = failureResult.Value, ErrorType = failureResult.ErrorType
            };
            return result.CopyMessages(failureResult);
        }

        public static IResult<TEntity1> CopyMessages<TEntity1, TEntity2>(this IResult<TEntity1> result, IResult<TEntity2> copyMessageResult) {
            if (copyMessageResult == null)
                return result;
            foreach (var resultMessage in copyMessageResult.ResultMessages)
                result.AddMessage(resultMessage);
            return result;
        }

        public static IResult CopyMessages(this IResult result, IResult copyMessageResult) {
            if (copyMessageResult == null)
                return result;
            foreach (var resultMessage in copyMessageResult.ResultMessages)
                result.AddMessage(resultMessage);
            return result;
        }

        public static string FullMessage(this IResult result, string separator = null) {
            if (result.ResultMessages.Count <= 1)
                return result.ResultMessages.FirstOrDefault() ?? string.Empty;
            separator = separator ?? Environment.NewLine;
            return result.ResultMessages.Aggregate(string.Empty, (current, message) => current + message + separator);
        }

        public static bool IsSuccess(this IResult result) {
            return result.Status == ResultStatus.Success;
        }

        public static bool IsSuccess<T>(this IResult<T> result) {
            return result.Status == ResultStatus.Success;
        }
    }
}