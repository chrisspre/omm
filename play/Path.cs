using System.Diagnostics;

namespace play;




// interface IEnd { }

// interface ISingleton<T> where T : ISingleton<T> { public abstract static T Instance { get; } }

// class Tail : IEnd, ISingleton<Tail> { private Tail() { } public static Tail Instance { get; } = new(); }

// class Tip : IEnd { private Tip() { } public static Tip Instance { get; } = new(); }

interface ISegment { };

record Node(string Var, string Label) : ISegment;

record Edge(string Label) : ISegment;

class Repetition(Range range, ISegment[] even, ISegment[] odd) : ISegment
{
    public Range Range { get; } = range;
    public ISegment[] Even { get; } = even;
    public ISegment[] Odd { get; } = odd;
}

class Path(params ISegment[] segments) : ISegment
{
    // public ISegment[] Segments { get; } = segments.Length % 2 != 0 ? segments : throw new ArgumentException("segments.Length must be odd");
    public ISegment[] Segments { get; } = segments;

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.FormatSegments(Segments);
        return builder.ToString();
    }
}

static class StringBuilderExtensions
{
    public static void FormatSegments(this StringBuilder builder, ISegment[] segments)
    {
        foreach (var segment in segments)
        {
            Format(builder, segment);
        }

        static void Format(StringBuilder builder, ISegment segment)
        {
            switch (segment)
            {
                case Node node:
                    builder.AppendFormat("({0}:{1})", node.Var, node.Label);
                    break;
                case Edge edge:
                    builder.AppendFormat(" --/:{0}/-> ", edge.Label);
                    break;
                case Repetition repetition:
                    builder.FormatSegments(repetition.Even);
                    builder.AppendFormat("[ ");
                    builder.FormatSegments([.. repetition.Odd, .. repetition.Even]);
                    builder.AppendFormat(" ]* ");
                    break;
            }
        }
    }
}