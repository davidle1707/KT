namespace KT.Common.Dto;

[Serializable]
public abstract class BaseOptions
{
    public bool Has<TLoadOptions>(TLoadOptions source, Func<TLoadOptions, bool> field) where TLoadOptions : BaseOptions
        => source != null && field(source);

    public void SetAll(bool value, params string[] ignoreNames)
    {
        var typeBool = typeof(bool);
        foreach (var prop in GetType().GetProperties().Where(a => (ignoreNames.Length == 0 || !ignoreNames.Contains(a.Name)) && a.PropertyType == typeBool))
        {
            prop.SetValue(this, value);
        }
    }

    public bool All(bool value, params string[] ignoreNames)
    {
        var typeBool = typeof(bool);
        foreach (var prop in GetType().GetProperties().Where(a => (ignoreNames.Length == 0 || !ignoreNames.Contains(a.Name)) && a.PropertyType == typeBool))
        {
            var propValue = (bool)prop.GetValue(this);
            if (propValue != value)
            {
                return false;
            }
        }

        return true;
    }

    public bool Any(bool value, params string[] ignoreNames)
    {
        var typeBool = typeof(bool);
        foreach (var prop in GetType().GetProperties().Where(a => (ignoreNames.Length == 0 || !ignoreNames.Contains(a.Name)) && a.PropertyType == typeBool))
        {
            var propValue = (bool)prop.GetValue(this);
            if (propValue == value)
            {
                return true;
            }
        }

        return false;
    }
}
