using Mindbox.Models.Shapes;
using Mindbox.Tests.Additional.Generators.Shapes.Parameters;

namespace Mindbox.Tests.Additional.Generators.Shapes;

public static class CircleGenerator
{
    public static Circle Generate()
    {
        var parameters = CircleParametersGenerator.Generate();
        
        return new Circle(parameters);
    }
}