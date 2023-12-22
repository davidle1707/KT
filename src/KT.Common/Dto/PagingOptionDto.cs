namespace KT.Common.Dto;

[Serializable]
public class PagingOptionDto
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; } = int.MaxValue;

    public int PageCount { get; set; }

    public long TotalRecords { get; set; }

    public bool IsValid => PageSize != int.MaxValue;

    public int PageStartIndex => (PageIndex <= 1 || PageSize == int.MaxValue) ? 0 : (PageIndex - 1) * PageSize;
}
