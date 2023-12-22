namespace KT.Common.Dto;

[Serializable]
public class FindRequest<TLoadOptions> : FindRequest where TLoadOptions : BaseOptions
{
    public TLoadOptions LoadOptions { get; set; }

    public bool HasLoad(Func<TLoadOptions, bool> field) => LoadOptions?.Has(LoadOptions, field) ?? false;
}

[Serializable]
public class FindRequest : BaseRequest
{
    public ObjectId? ClientId { get; set; }

    public ObjectId? CreatedBy { get; set; }

    public ObjectId[] Ids { get; set; }

    public ObjectId[] NotInIds { get; set; }

    public string Text { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public bool IsOnlyGetTotalRecords { get; set; }

    public PagingOptionDto Paging { get; set; }

    public SortingOptionDto Sorting { get; set; }

    [JsonIgnore]
    public bool IsValidPaging => Paging?.IsValid ?? false;

    [JsonIgnore]
    public bool IsValidSorting => Sorting?.IsValid ?? false;

    public bool RefNameIsFull { get; set; }

    public bool GetDbQuery { get; set; }
}

[Serializable]
public class FindResponse<T> : FindResponse
{
    public List<T> Records { get; set; } = new List<T>();
}

[Serializable]
public class FindResponse : BaseResponse
{
    public long TotalRecords { get; set; }

    public string DbQuery { get; set; }
}
