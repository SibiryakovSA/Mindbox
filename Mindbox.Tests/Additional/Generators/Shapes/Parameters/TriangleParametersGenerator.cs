using Bogus;
using Mindbox.Models.Shapes.Parameters;

namespace Mindbox.Tests.Additional.Generators.Shapes.Parameters;

public static class TriangleParametersGenerator
{
    public static TriangleParameters Generate()
    {
        var faker = new Faker<TriangleParameters>()
            .RuleFor(p => p.FirstSideLength, (_, _) => AnyValue.PositiveNonZeroDouble)
            .RuleFor(p => p.SecondSideLength, (_, _) => AnyValue.PositiveNonZeroDouble)
            .FinishWith((f, p) => p.ThirdSideLength = f.Random.Double(
                Math.Abs(p.FirstSideLength - p.SecondSideLength), 
                p.FirstSideLength + p.SecondSideLength)
            );
        
        return faker.Generate();
    }
}