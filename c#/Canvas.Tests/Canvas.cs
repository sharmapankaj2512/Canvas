using System.Collections.Generic;
using System.Linq;
using LanguageExt;
using LanguageExt.Common;
using static LanguageExt.Prelude;

namespace Canvas.Tests;

class Canvas
{
    private int Width { get; }
    private int Height { get; }

    private Canvas(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public static Canvas CreateCanvas(int width, int height)
    {
        return new Canvas(width, height);
    }

    public List<Point2D> Points()
    {
        return Enumerable.Range(0, Width)
            .Zip(Enumerable.Range(0, Height))
            .Select(p => new Point2D(p.Item1, p.Item2))
            .ToList();
    }

    public static Either<Error, Canvas> CreateCanvasv2(int w, int h)
    {
        if (w < 0)
            return Left<Error, Canvas>(Error.New("Width should not be negative"));
        return null;
    }
}