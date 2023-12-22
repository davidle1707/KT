namespace KT.Common.Pluralizer;

internal class PluralRules
{
    private readonly PluralizerRuleSet _rules;

    internal PluralRules(PluralizerRuleSet rules)
    {
        _rules = rules;
    }

    public PluralRules Add(string ruleExpression, string replacementExpression)
    {
        _rules.Plurals.Add(new PluralizerRule(ruleExpression, replacementExpression));
        return this;
    }
}

internal class SingularRules
{
    private readonly PluralizerRuleSet _rules;

    internal SingularRules(PluralizerRuleSet rules)
    {
        _rules = rules;
    }

    public SingularRules Add(string ruleExpression, string replacementExpression)
    {
        _rules.Singulars.Add(new PluralizerRule(ruleExpression, replacementExpression));
        return this;
    }
}

internal class IrregularRules
{
    private readonly PluralRules _plurals;
    private readonly SingularRules _singulars;

    internal IrregularRules(SingularRules singulars, PluralRules plurals)
    {
        _singulars = singulars;
        _plurals = plurals;
    }

    public IrregularRules Add(string singular, string plural)
    {
        _plurals.Add("(" + singular[0] + ")" + singular[1..] + "$", "$1" + plural[1..]);
        _singulars.Add("(" + plural[0] + ")" + plural[1..] + "$", "$1" + singular[1..]);
        return this;
    }
}

internal class UncountableRules
{
    private readonly PluralizerRuleSet _rules;

    internal UncountableRules(PluralizerRuleSet rules)
    {
        _rules = rules;
    }

    public UncountableRules Add(string word)
    {
        _rules.Uncountables.Add(word.ToLowerInvariant());
        return this;
    }
}