namespace KT.Common.Dto;

[Serializable]
public class CreateRequest<T> : BaseRequest
{
    public T Dto { get; set; }
}

[Serializable]
public class CreateResponse : BaseResponse
{
    public ObjectId CreatedId { get; set; }
}

[Serializable]
public class CreateManyRequest<T> : BaseRequest
{
    public IEnumerable<T> Dtos { get; set; }
}

[Serializable]
public class CreateManyResponse : BaseResponse
{
}
