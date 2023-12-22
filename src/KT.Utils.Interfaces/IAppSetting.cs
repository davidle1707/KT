namespace KT.Utils.Interfaces;

public interface IAppSetting
{
    string this[string key] { get; }

    string AsStr(string key);

    int AsInt(string key, int def = 0);

    bool AsBool(string key, bool def = false);
}
