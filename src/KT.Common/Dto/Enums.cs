namespace KT.Common.Dto;

[Serializable]
public enum SortDirection
{
    None = 0,

    Asc = 1,

    Desc = 2
}

[Serializable]
public enum ListFilterMode
{
    In = 0,

    NotIn,

    All
}
