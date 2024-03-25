namespace Csdl.Graph;

static class StringExtensions
{
    public static string[] SplitAtLast(this string field, char separator)
    {
        var ix = field.LastIndexOf(separator);
        return ix > 0 ? [field[..ix], field[(ix + 1)..]] : [field];
    }


    public static string Join(this IEnumerable<string> items, string separator, string lastSeparator)
    {
        var list = items.ToList();
        if (list.Count == 0)
        {
            return "";
        }
        if (list.Count == 1)
        {
            return list[0];
        }
        if (list.Count == 2)
        {
            return $"{list[0]} {lastSeparator} {list[1]}";
        }
        return $"{string.Join(separator, list.Take(list.Count - 1))} {lastSeparator} {list.Last()}";
    }
}
