namespace Fox.Model.Config
{
    public interface IModelResult
    {
        SystemCodes.Codes ErrorCodee { get; set; }
        bool isOK { get; set; }
        string Message { get; set; }
        string SystemMessage { get; set; }
    }
}