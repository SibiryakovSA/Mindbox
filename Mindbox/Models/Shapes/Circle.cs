using Mindbox.Models.Shapes.Parameters;

namespace Mindbox.Models.Shapes;

public partial class Circle(CircleParameters parameters) : Shape
{
    public double Radius { get; set; } = parameters.Radius;
}