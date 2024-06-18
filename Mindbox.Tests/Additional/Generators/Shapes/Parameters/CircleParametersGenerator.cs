using Bogus;
using Mindbox.Models.Shapes.Parameters;

namespace Mindbox.Tests.Additional.Generators.Shapes.Parameters;

public static class CircleParametersGenerator
{
    public static CircleParameters Generate()
    {
        var faker = new Faker<CircleParameters>()
            .RuleFor(p => p.Radius, (_, _) => AnyValue.PositiveNonZeroDouble);
        
        return faker.Generate();
    }
}