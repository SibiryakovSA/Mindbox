namespace Mindbox.Models.Shapes;

public partial class Triangle : Shape
{
    public override double GetArea()
    {
        var halfPerimeter = (FirstSideLength + SecondSideLength + ThirdSideLength) / 2;

        return Math.Sqrt(halfPerimeter * (halfPerimeter - FirstSideLength) 
                                       * (halfPerimeter - SecondSideLength) 
                                       * (halfPerimeter - ThirdSideLength));
    }
    
    public bool IsIsosceles()
    {
        var sides = new[] { FirstSideLength, SecondSideLength, ThirdSideLength };
        var sortedSides = sides.Order().ToList();
        var permissibleError = Math.Pow(10, -50);

        return Math.Abs(Math.Pow(sortedSides[0], 2) + Math.Pow(sortedSides[1], 2) - Math.Pow(sortedSides[2], 2)) < permissibleError;
    }

}