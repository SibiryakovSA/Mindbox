using Mindbox.Models.Shapes;
using Mindbox.Tests.Additional.Generators.Shapes.Parameters;

namespace Mindbox.Tests.Additional.Generators.Shapes;

public static class TriangleGenerator
{
    public static Triangle Generate()
    {
        var parameters = TriangleParametersGenerator.Generate();
        
        return new Triangle(parameters);
    }
}