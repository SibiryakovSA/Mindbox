using Mindbox.Tests.Additional.Generators.Shapes;

namespace Mindbox.Tests.Tests.Models;

public class TriangleTest
{
    #region GetArea

    [Theory]
    [InlineData(5, 5, 6, 12)]
    [InlineData(3, 4, 5, 6)]
    public void GetArea_Triangle_CorrectArea(byte firstSideLength, byte secondSideLength, byte thirdSideLength, double expectedArea)
    {
        var triangle = TriangleGenerator.Generate();
        triangle.FirstSideLength = firstSideLength;
        triangle.SecondSideLength = secondSideLength;
        triangle.ThirdSideLength = thirdSideLength;
        
        var result = triangle.GetArea();

        Assert.Equal(expectedArea, result);
    }

    #endregion
    
    #region IsIsosceles

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(3, 4, 6, false)]
    public void IsIsosceles_Triangle_CorrectArea(byte firstSideLength, byte secondSideLength, byte thirdSideLength, bool expectedIsIsosceles)
    {
        var triangle = TriangleGenerator.Generate();
        triangle.FirstSideLength = firstSideLength;
        triangle.SecondSideLength = secondSideLength;
        triangle.ThirdSideLength = thirdSideLength;
        
        var result = triangle.IsIsosceles();

        Assert.Equal(expectedIsIsosceles, result);
    }

    #endregion
}