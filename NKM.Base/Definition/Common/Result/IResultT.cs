namespace NKM.Base.Definition.Common.Result {
    public interface IResult<TEntity> : IResult {
        TEntity Value { get; set; }

        new IResult<TEntity> AddMessage(string message);
    }
}