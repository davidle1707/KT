namespace KT.Common.Pluralizer.Cultures;

internal abstract class CultureRules
{
    protected CultureRules(
        Func<PluralRules, PluralRules> plurals,
        Func<SingularRules, SingularRules> singulars,
        Func<IrregularRules, IrregularRules> irregulars,
        Func<UncountableRules, UncountableRules> uncountables,
        Func<int, string> ordanizeFunc)
    {
        if (plurals == null) throw new ArgumentNullException(nameof(plurals));
        if (singulars == null) throw new ArgumentNullException(nameof(singulars));
        if (uncountables == null) throw new ArgumentNullException(nameof(uncountables));
        if (ordanizeFunc == null) throw new ArgumentNullException(nameof(ordanizeFunc));

        RuleSet = new PluralizerRuleSet(new List<PluralizerRule>(), new List<PluralizerRule>(), new List<string>(), ordanizeFunc);

        Plurals = new PluralRules(RuleSet);
        Singulars = new SingularRules(RuleSet);
        Uncountables = new UncountableRules(RuleSet);
        Irregulars = new IrregularRules(Singulars, Plurals);

        plurals(Plurals);
        singulars(Singulars);
        uncountables(Uncountables);
        irregulars(Irregulars);
    }

    public PluralRules Plurals { get; }
    public SingularRules Singulars { get; }
    public UncountableRules Uncountables { get; }
    public IrregularRules Irregulars { get; }

    internal PluralizerRuleSet RuleSet { get; }
}