namespace KT.Common.Dto;

[Serializable]
public class BaseDto : BaseIdDto
{
    public DateTime CreatedDate { get; set; }

    public ObjectId? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public ObjectId? ModifiedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public ObjectId? DeletedBy { get; set; }

    public string Description { get; set; }
}

[Serializable]
public class BaseIdDto
{
    public ObjectId Id { get; set; }
}
