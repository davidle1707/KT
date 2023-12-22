using System.Text.RegularExpressions;
using KT.Common.Pluralizer.Cultures;

namespace KT.Common.Pluralizer;

internal class Pluralizer
{
    private readonly EnglishRules _englishRules;

    public Pluralizer()
    {
        _englishRules = new EnglishRules();
    }

    public string Pluralize(string word)
    {
        return ApplyRules(_englishRules.RuleSet.Plurals, word);
    }

    public string Singularize(string word)
    {
        return ApplyRules(_englishRules.RuleSet.Singulars, word);
    }

    public string Titleize(string word)
    {
        return Regex.Replace(Humanize(Underscore(word)), @"\b([a-z])",
                             match => match.Captures[0].Value.ToUpper());
    }

    //TODO: this must be improved to handle Pascal Casing
    public string Humanize(string lowercaseAndUnderscoredWord)
    {
        return Capitalize(Regex.Replace(lowercaseAndUnderscoredWord, @"_", " "));
    }

    public string Pascalize(string lowercaseAndUnderscoredWord)
    {
        return Regex.Replace(lowercaseAndUnderscoredWord, "(?:^|_)(.)",
                             match => match.Groups[1].Value.ToUpper());
    }

    public string Camelize(string lowercaseAndUnderscoredWord)
    {
        return Uncapitalize(Pascalize(lowercaseAndUnderscoredWord));
    }

    public string Underscore(string pascalCasedWord)
    {
        return Regex.Replace(
            Regex.Replace(
                Regex.Replace(pascalCasedWord, @"([A-Z]+)([A-Z][a-z])", "$1_$2"), @"([a-z\d])([A-Z])",
                "$1_$2"), @"[-\s]", "_").ToLower();
    }

    public string Capitalize(string word)
    {
        return word[..1].ToUpper() + word[1..].ToLower();
    }

    public string Uncapitalize(string word)
    {
        return word[..1].ToLower() + word[1..];
    }

    //TODO: this is not generalizable to other cultures since it does not supoorts grammatical gender
    public string Ordinalize(int number)
    {
        var rules = _englishRules.RuleSet;
        if (rules.Ordanize != null)
        {
            return rules.Ordanize(number);
        }
        return number.ToString();
    }

    public string Dasherize(string underscoredWord)
    {
        return underscoredWord.Replace('_', '-');
    }

    private string ApplyRules(IList<PluralizerRule> rules, string word)
    {
        string result = word;

        if (!_englishRules.RuleSet.Uncountables.Contains(word.ToLower()))
        {
            for (int i = rules.Count - 1; i >= 0; i--)
            {
                if ((result = rules[i].Apply(word)) != null)
                {
                    break;
                }
            }
        }

        return result ?? word;
    }
}
