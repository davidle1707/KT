namespace KT.Common;

 public class NameValueIndexer<TValue> //System.Dynamic.DynamicObject
{
    private readonly Func<string, TValue> _getValue;

    public NameValueIndexer(Func<string, TValue> getValue)
    {
        _getValue = getValue;
    }

    public TValue this[string name] => _getValue(name);
}