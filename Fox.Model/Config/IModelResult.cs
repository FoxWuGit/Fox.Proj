namespace Fox.Model.Config
{
    public interface IModelResult
    {
        SystemCodes.Codes? ErrorCode { get; set; }
        bool IsOk { get; set; }
        string Message { get; set; }
        string SystemMessage { get; set; }
    }

    public interface IModelResult<T> : IModelResult
    {
        T ResultData { get; set; }
    }
}