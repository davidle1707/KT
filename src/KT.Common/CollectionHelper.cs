namespace KT.Common;

public static class CollectionHelper
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> sources)
    {
        if (sources == null)
            return true;

        if (sources is T[] array && array.Length == 0)
            return true;

        if (sources is IList<T> list && list.Count == 0)
            return true;

        return !sources.Any();
    }
}