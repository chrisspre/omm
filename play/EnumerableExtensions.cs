namespace play;

public static class EnumerableExtensions
{
    public static IEnumerable<(int, T)> WithIndex<T>(this IEnumerable<T> items)
    {
        var index = 0;
        foreach (var item in items)
        {
            yield return (index, item);
            index += 1;
        }
    }




    public static IEnumerable<T> Intersperse<S, T>(this IEnumerable<S> source, Func<T, int, T, T> intersperser)
      where S : T
    {
        var i = 0;
        var enumerator = source.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            yield break;
        }
        var previous = enumerator.Current;
        while (enumerator.MoveNext())
        {
            if (i != 0) yield return intersperser(previous, i, enumerator.Current);
            yield return previous;
            previous = enumerator.Current;
            i += 1;
        }
    }

    public static IEnumerable<T> Intersperse<S, T>(this IEnumerable<S> source, Func<int, T> intersperser)
      where S : T
    {
        var i = 0;
        foreach (var item in source)
        {
            if (i != 0) yield return intersperser(i);
            yield return item;
            i += 1;
        }
    }
}