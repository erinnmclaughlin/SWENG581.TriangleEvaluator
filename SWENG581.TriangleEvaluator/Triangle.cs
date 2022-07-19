namespace SWENG581.TriangleEvaluator;

public class Triangle
{
    public double A { get; init; }
    public double B { get; init; }
    public double C { get; init; }
    public double[] Sides => new double[] { A, B, C };

    private double LargestSide => Sides.Max();

    public Triangle(double a, double b, double c)
    {
        if (a <= 0) throw new ArgumentOutOfRangeException(nameof(a), "Value must be positive.");
        if (b <= 0) throw new ArgumentOutOfRangeException(nameof(b), "Value must be positive.");
        if (c <= 0) throw new ArgumentOutOfRangeException(nameof(c), "Value must be positive.");

        A = a;
        B = b;
        C = c;
    }

    public bool IsEquilateral()
    {
        return A == B && B == C;
    }

    public bool IsIsosceles()
    {
        if (!IsValid() || IsEquilateral()) return false;

        var sides = Sides.Where(s => s != LargestSide);
        return sides.First() == sides.Last();
    }

    public bool IsScalene()
    {
        return IsValid() && !IsEquilateral() && !IsIsosceles();
    }

    public bool IsRight()
    {
        if (!IsValid() || IsEquilateral()) return false;

        var hypotenuse = Sides.Max();
        return Sides.Where(s => s != hypotenuse).Sum(s => Math.Pow(s, 2)) == Math.Pow(hypotenuse, 2);
    }

    public bool IsValid()
    {
        var largestSide = Sides.Max();
        return largestSide < Sides.Sum() - largestSide;
    }
}
