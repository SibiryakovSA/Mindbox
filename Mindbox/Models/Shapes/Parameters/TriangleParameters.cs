namespace Mindbox.Models.Shapes.Parameters;

public class TriangleParameters : ShapeParameters
{
    public required double FirstSideLength { get; set; }
    public required double SecondSideLength { get; set; }
    public required double ThirdSideLength { get; set; }
}