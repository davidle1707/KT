using System.Text.RegularExpressions;

namespace KT.Common.Pluralizer;

/// <summary>
///     This class is not meant to be used directly.
/// </summary>
internal class PluralizerRule
{
    private readonly Regex _regex;
    private readonly string _replacement;

    internal PluralizerRule(string pattern, string replacement)
    {
        _regex = new Regex(pattern, RegexOptions.IgnoreCase);
        _replacement = replacement;
    }

    internal string Apply(string word)
    {
        if (!_regex.IsMatch(word))
        {
            return null;
        }

        return _regex.Replace(word, _replacement);
    }
}

/// <summary>
///     This class is not menat to be used diretly.
/// </summary>
internal class PluralizerRuleSet
{
    public PluralizerRuleSet(IList<PluralizerRule> plurals, IList<PluralizerRule> singulars, IList<string> uncountables, Func<int, string> ordanizeFunc)
    {
        Plurals = plurals;
        Singulars = singulars;
        Uncountables = uncountables;
        Ordanize = ordanizeFunc;
    }

    internal IList<PluralizerRule> Plurals { get; }
    internal IList<PluralizerRule> Singulars { get; }
    internal IList<string> Uncountables { get; }

    internal Func<int, string> Ordanize { get; set; }
}
