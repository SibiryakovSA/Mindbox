using Mindbox.Constants;
using Mindbox.Exceptions;
using Mindbox.Factories;
using Mindbox.Models.Shapes;
using Mindbox.Models.Shapes.Parameters;
using Mindbox.Tests.Additional;
using Mindbox.Tests.Additional.Generators.Shapes.Parameters;

namespace Mindbox.Tests.Tests.Factories;

public class ShapesFactoryTests
{
    #region Parameters
    
    [Theory]
    [MemberData(nameof(CorrectParametersTypeData))]
    public void GetShape_CorrectParametersType_CorrectShapeType(string code, ShapeParameters parameters, Type expectedType)
    {
        var result = ShapesFactory.GetShape(code, parameters);

        Assert.IsType(expectedType, result);
    }
    
    public static IEnumerable<object[]> CorrectParametersTypeData =>
        new List<object[]>
        {
            new object[] { ShapesCodes.Triangle, TriangleParametersGenerator.Generate(), typeof(Triangle) },
            new object[] { ShapesCodes.Circle, CircleParametersGenerator.Generate(), typeof(Circle) }
        };
    
    [Theory]
    [MemberData(nameof(IncorrectParametersTypeData))]
    public void GetShape_IncorrectParametersType_IncorrectShapeParametersTypeException(string code, ShapeParameters parameters)
    {
        Assert.Throws<IncorrectShapeParametersTypeException>(() =>
            ShapesFactory.GetShape(code, parameters));
    }

    public static IEnumerable<object[]> IncorrectParametersTypeData =>
        new List<object[]>
        {
            new object[] { ShapesCodes.Circle, TriangleParametersGenerator.Generate() },
            new object[] { ShapesCodes.Triangle, CircleParametersGenerator.Generate() }
        };
    
    [Fact]
    public void GetShape_IncorrectShapeTypeCode_UnsupportedShapeCodeException()
    {
        var code = AnyValue.String;
        var parameters = CircleParametersGenerator.Generate();

        Assert.Throws<UnsupportedShapeCodeException>(() =>
            ShapesFactory.GetShape(code, parameters));
    }
    
    #endregion

    #region Circle

    [Fact]
    public void GetShape_NegativeCircleRadius_CreateCircleException()
    {
        var parameters = CircleParametersGenerator.Generate();
        parameters.Radius = -Additional.Constants.SmallPositive;

        Assert.Throws<CreateCircleException>(() =>
            ShapesFactory.GetShape(ShapesCodes.Circle, parameters));
    }
    
    [Fact]
    public void GetShape_ZeroCircleRadius_CreateCircleException()
    {
        var parameters = CircleParametersGenerator.Generate();
        parameters.Radius = 0;

        Assert.Throws<CreateCircleException>(() =>
            ShapesFactory.GetShape(ShapesCodes.Circle, parameters));
    }

    #endregion
    
    #region Triangle

    [Theory]
    [MemberData(nameof(ZeroSideLengthTriangleParameters))]
    public void GetShape_ZeroSideLength_CreateTriangleException(byte firstSideLength, byte secondSideLength, byte thirdSideLength)
    {
        var parameters = TriangleParametersGenerator.Generate();
        parameters.FirstSideLength = firstSideLength;
        parameters.SecondSideLength = secondSideLength;
        parameters.ThirdSideLength = thirdSideLength;

        Assert.Throws<CreateTriangleException>(() =>
            ShapesFactory.GetShape(ShapesCodes.Triangle, parameters));
    }
    
    public static IEnumerable<object[]> ZeroSideLengthTriangleParameters =>
        new List<object[]>
        {
            new object[] { 0, 0, 0 },
            new object[] { 0, 0, 1 },
            new object[] { 0, 1, 0 },
            new object[] { 0, 1, 1 },
            new object[] { 1, 0, 0 },
            new object[] { 1, 0, 1 },
            new object[] { 1, 1, 0 }
        };
    
    [Theory]
    [MemberData(nameof(HypotenuseLengthLessThenSumLegsLengthsParameters))]
    public void GetShape_HypotenuseLengthLessThenSumLegsLengths_CreateTriangleException(
        double firstSideLength, double secondSideLength, double thirdSideLength)
    {
        var parameters = TriangleParametersGenerator.Generate();
        parameters.FirstSideLength = firstSideLength;
        parameters.SecondSideLength = secondSideLength;
        parameters.ThirdSideLength = thirdSideLength;

        Assert.Throws<CreateTriangleException>(() =>
            ShapesFactory.GetShape(ShapesCodes.Triangle, parameters));
    }
    
    public static IEnumerable<object[]> HypotenuseLengthLessThenSumLegsLengthsParameters
    {
        get
        {
            var incorrectParameters = TriangleParametersGenerator.Generate();
            var firstCorrectLength = incorrectParameters.FirstSideLength;
            var secondCorrectLength = incorrectParameters.SecondSideLength;
            var incorrectHypotenuseLength = firstCorrectLength + secondCorrectLength + Additional.Constants.SmallPositive;
            
            return new List<object[]>
            {
                new object[] { firstCorrectLength, secondCorrectLength, incorrectHypotenuseLength },
                new object[] { secondCorrectLength, firstCorrectLength, incorrectHypotenuseLength },
                new object[] { incorrectHypotenuseLength, firstCorrectLength, secondCorrectLength },
                new object[] { incorrectHypotenuseLength, secondCorrectLength, firstCorrectLength },
                new object[] { firstCorrectLength, incorrectHypotenuseLength, secondCorrectLength },
                new object[] { secondCorrectLength, incorrectHypotenuseLength, firstCorrectLength }
            };
        }
    }

    #endregion
}