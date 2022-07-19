using FluentAssertions;
using Xunit;

namespace SWENG581.TriangleEvaluator.Tests;

public class TriangleEvaluatorTests
{
    [Theory]
    [InlineData(5, 5, 10)] // A = B, C = A + B
    [InlineData(5, 5, 11)] // A = B, C > A + B
    [InlineData(6, 5, 11)] // A > B, C = A + B
    [InlineData(6, 5, 12)] // A > B, C > A + B
    [InlineData(5, 6, 11)] // A < B, C = A + B
    [InlineData(5, 6, 12)] // A < B, C > A + B
    [InlineData(5, 10, 5)] // A = C, B = A + C
    [InlineData(5, 11, 5)] // A = C, B > A + C
    [InlineData(6, 11, 5)] // A > C, B = A + C
    [InlineData(6, 12, 5)] // A > C, B > A + C
    [InlineData(5, 11, 6)] // A < C, B = A + C
    [InlineData(5, 12, 6)] // A < C, B > A + C
    [InlineData(10, 5, 5)] // B = C, A = B + C
    [InlineData(11, 5, 5)] // B = C, A > B + C
    [InlineData(11, 6, 5)] // B > C, A = B + C
    [InlineData(12, 6, 5)] // B > C, A > B + C
    [InlineData(11, 5, 6)] // B < C, A = B + C
    [InlineData(12, 5, 6)] // B < C, A > B + C
    public void TriangleEvaluator_ShouldIdentifyInvalidTriangle(double a, double b, double c)
    {
        var description = TriangleEvaluator.GetTriangleDescription(a, b, c);
        description.Should().Be("Not a Triangle");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(double.Epsilon)]
    [InlineData(double.MaxValue)]
    public void TriangleEvaluator_ShouldIdentifyEquilateralTriangle(double sideLength)
    {
        var description = TriangleEvaluator.GetTriangleDescription(sideLength, sideLength, sideLength);
        description.Should().Be("Equilateral Triangle");
    }

    [Theory]
    [InlineData(5, 3, 4)] // A^2 = B^2 + C^2
    [InlineData(3, 5, 4)] // B^2 = A^2 + C^2
    [InlineData(3, 4, 5)] // C^2 = A^2 + B^2
    public void TriangleEvaluator_ShouldIdentifyRightTriangle(double a, double b, double c)
    {
        var description = TriangleEvaluator.GetTriangleDescription(a, b, c);
        description.Should().Be("Right Triangle");
    }

    [Theory]
    [InlineData(5, 5, 8)] // A = B
    [InlineData(5, 8, 5)] // A = C
    [InlineData(8, 5, 5)] // B = C
    public void TriangleEvaluator_ShouldIdentifyIsoscelesTriangle(double a, double b, double c)
    {
        var description = TriangleEvaluator.GetTriangleDescription(a, b, c);
        description.Should().Be("Isosceles Triangle");
    }

    [Theory]
    [InlineData(13, 14, 15)] // A < B < C
    [InlineData(13, 15, 14)] // A < C < B
    [InlineData(14, 13, 15)] // B < A < C
    [InlineData(15, 13, 14)] // B < C < A
    [InlineData(14, 15, 13)] // C < A < B
    [InlineData(15, 14, 13)] // C < B < A
    public void TriangleEvaluator_ShouldIdentifyScaleneTriangle(double a, double b, double c)
    {
        var description = TriangleEvaluator.GetTriangleDescription(a, b, c);
        description.Should().Be("Scalene Triangle");
    }
}