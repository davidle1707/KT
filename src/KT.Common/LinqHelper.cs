namespace KT.Common;

public static class LinqHelper
{
    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
    {
        using var enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            yield return getPart(enumerator, size);
        }

        static IEnumerable<T> getPart(IEnumerator<T> _enumerator, int _size)
        {
            do
            {
                yield return _enumerator.Current;
            } while (--_size > 0 && _enumerator.MoveNext());
        }
    }

    public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action, int? batchSize = 10)
    {
        if (batchSize > 0)
        {
            foreach (var batch in enumeration.Batch(batchSize.Value))
            {
                foreach (var item in batch)
                {
                    action(item);
                }
            }
        }
        else
        {
            foreach (var item in enumeration)
            {
                action(item);
            }
        }
    }
}