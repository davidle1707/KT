namespace KT.Common.Dto;

[Serializable]
public class DeleteRequest
{
    public ObjectId Id { get; set; }

    public ObjectId? By { get; set; }

    public bool FetchInfo { get; set; }
}

[Serializable]
public class DeleteResponse<T> : BaseResponse
{
    public T Dto { get; set; }
}