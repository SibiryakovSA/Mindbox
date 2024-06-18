using Mindbox.Models.Shapes.Parameters;

namespace Mindbox.Models.Shapes;

public partial class Triangle(TriangleParameters parameters) : Shape
{
    public double FirstSideLength { get; set; } = parameters.FirstSideLength;
    public double SecondSideLength { get; set; } = parameters.SecondSideLength;
    public double ThirdSideLength { get; set; } = parameters.ThirdSideLength;
}