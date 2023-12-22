namespace KT.Common.Dto;

[Serializable]
public class BaseRequest
{
    public ObjectId? By { get; set; }
}

[Serializable]
public class BaseResponse
{
    public bool Success => Errors == null || Errors.Count == 0;

    public List<string> WarnMessages { get; set; }

    public List<ErrorItem> Errors { get; set; }

    [JsonIgnore]
    public IEnumerable<string> ErrorMessages => Errors?.Select(a => a.Message);

    public void AddError(string msg = "", int code = 500)
    {
        Errors ??= new List<ErrorItem>();
        Errors.Add(new ErrorItem(msg, code));
    }

    public void AddErrors(IEnumerable<ErrorItem> items)
    {
        Errors ??= new List<ErrorItem>();
        Errors.AddRange(items);
    }

    public static TResponse Create<TResponse>() where TResponse : BaseResponse, new() => new() { };

    public static TResponse CreateError<TResponse>(params ErrorItem[] items) where TResponse : BaseResponse, new() => new()
    {
        Errors = new List<ErrorItem>(items)
    };
}

[Serializable]
public class ErrorItem
{
    public int Code { get; set; }

    public string Message { get; set; }

    public ErrorItem(string message = "", int code = 500)
    {
        Code = code;
        Message = message;
    }
}
