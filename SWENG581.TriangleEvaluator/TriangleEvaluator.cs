namespace SWENG581.TriangleEvaluator;

public class TriangleEvaluator
{
    public static string GetTriangleDescription(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);

        if (triangle.IsRight())
            return "Right Triangle";

        if (triangle.IsEquilateral())
            return "Equilateral Triangle";

        if (triangle.IsIsosceles())
           return "Isosceles Triangle";

        if (triangle.IsScalene())
            return "Scalene Triangle";

        return "Not a Triangle";
    }
}
