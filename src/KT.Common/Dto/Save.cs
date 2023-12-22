namespace KT.Common.Dto;

[Serializable]
public class SaveRequest<T> : BaseRequest
{
    public virtual T Dto { get; set; }

    public BaseOptions Options { get; set; }

    [NonSerialized]
    public Func<T, Task> IfInsert;

    [NonSerialized]
    public Func<T, Task> IfUpdate;
}

[Serializable]
public class SaveResponse : BaseResponse
{
    public ObjectId SavedId { get; set; }

    public bool IsNew { get; set; }
}
