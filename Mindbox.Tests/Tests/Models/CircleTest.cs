using Mindbox.Tests.Additional.Generators.Shapes;

namespace Mindbox.Tests.Tests.Models;

public class CircleTest
{
    #region GetArea

    [Fact]
    public void GetArea_Circle_CorrectArea()
    {
        var circle = CircleGenerator.Generate();
        
        var result = circle.GetArea();

        var expectedResult = Math.PI * Math.Pow(circle.Radius, 2);
        Assert.Equal(expectedResult, result);
    }

    #endregion
}