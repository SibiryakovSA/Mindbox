namespace Mindbox.Models.Shapes;

public partial class Circle : Shape
{
    public override double GetArea() => 
        Math.PI * Math.Pow(Radius, 2);
}