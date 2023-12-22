namespace KT.Common.Dto;

public class SortingOptionDto
{
    public List<SortingItem> Items { get; set; }

    public bool IsValid => Items.Any(i => i.IsValid);

    public SortingOptionDto(params SortingItem[] items)
    {
        Items = new List<SortingItem>(items.Where(i => i?.IsValid ?? false));
    }

    public void Add(string fieldName, SortDirection direction)
    {
        Items.RemoveAll(i => i.FieldName.EqualsX(fieldName));
        Items.Add(new SortingItem(fieldName, direction));
    }
}

public class SortingItem
{
    public string FieldName { get; set; }

    public SortDirection Direction { get; set; }

    public bool IsValid => !string.IsNullOrWhiteSpace(FieldName) && Direction != SortDirection.None;

    public SortingItem(string fieldName, SortDirection direction)
    {
        FieldName = fieldName;
        Direction = direction;
    }
}