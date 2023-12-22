namespace KT.Utils.Interfaces;

[Serializable]
public class KTContext
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public bool IsDebug { get; set; }

    public Dictionary<string, object> Extend = new();

    public virtual void Release() { }

    public object this[string extendKey]
    {
        get => Extend.TryGetValue(extendKey, out var extendValue) ? extendValue : null;
        set
        {
            if (value == null)
            {
                Extend.Remove(extendKey);
            }
            else
            {
                Extend[extendKey] = value;
            }
        }
    }
}