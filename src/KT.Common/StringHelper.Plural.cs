namespace KT.Common;

public static partial class StringHelper
{
    private static readonly Lazy<Pluralizer.Pluralizer> _lazyPluralizer = new(() => new Pluralizer.Pluralizer());

    public static string Pluralize(this string word) => _lazyPluralizer.Value.Pluralize(word);

    public static string Singularize(this string word) => _lazyPluralizer.Value.Singularize(word);

    public static string Titleize(this string word) => _lazyPluralizer.Value.Titleize(word);

    public static string Humanize(this string lowercaseAndUnderscoredWord) => _lazyPluralizer.Value.Humanize(lowercaseAndUnderscoredWord);

    public static string Pascalize(this string lowercaseAndUnderscoredWord) => _lazyPluralizer.Value.Pascalize(lowercaseAndUnderscoredWord);

    public static string Camelize(this string lowercaseAndUnderscoredWord) => _lazyPluralizer.Value.Camelize(lowercaseAndUnderscoredWord);

    public static string Underscore(this string pascalCasedWord) => _lazyPluralizer.Value.Underscore(pascalCasedWord);

    public static string Capitalize(this string word) => _lazyPluralizer.Value.Capitalize(word);

    public static string Uncapitalize(this string word) => _lazyPluralizer.Value.Uncapitalize(word);

    public static string Ordinalize(this int number) => _lazyPluralizer.Value.Ordinalize(number);

    public static string Dasherize(this string underscoredWord) => _lazyPluralizer.Value.Dasherize(underscoredWord);
}
