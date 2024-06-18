using Bogus;

namespace Mindbox.Tests.Additional;

public static class AnyValue
{
    static AnyValue()
    {
        Faker = new Faker();
    }
    
    private static Faker Faker { get; set; }

    public static string String => Faker.Random.String();
    
    public static double PositiveNonZeroDouble => PositiveDouble + Constants.SmallPositive;
    public static double PositiveDouble => Faker.Random.Double(0, Byte);
    
    public static byte Byte => Faker.Random.Byte();
}