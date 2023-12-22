namespace KT.Common.Dto;

[Serializable]
public class ExtendKeyValueObjDto
{
    public List<KeyValueObjDto> Extends { get; set; } = new List<KeyValueObjDto>();

    public object this[string extendKey, bool setNullToRemove = true]
    {
        get => Extends.SingleOrDefault(f => f.Key == extendKey)?.Value;
        set
        {
            if (value == null)
            {
                Extends.RemoveAll(a => a.Key == extendKey);
            }
            else
            {
                var row = Extends.SingleOrDefault(f => f.Key == extendKey);
                if (row != null)
                {
                    row.Value = value;
                }
                else
                {
                    Extends.Add(new KeyValueObjDto { Key = extendKey, Value = value });
                }
            }
        }
    }

    public KeyValueObjDto Extend(string key, bool emptyIfNotFound = false)
    {
        var row = Extends.SingleOrDefault(f => f.Key == key);

        return row ?? (emptyIfNotFound ? new KeyValueObjDto() : null);
    }
}

[Serializable]
public class KeyValueObjDto
{
    public string Key { get; set; }

    public object Value { get; set; }

    [JsonIgnore] 
    public bool ValueAsBool => Value.ToBool();

    [JsonIgnore]
    public string ValueAsStr => Value.ToStr();

    [JsonIgnore]
    public int ValueAsInt => Value.ToInt();
}