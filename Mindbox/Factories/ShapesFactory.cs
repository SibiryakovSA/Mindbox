using Mindbox.Constants;
using Mindbox.Exceptions;
using Mindbox.Models.Shapes;
using Mindbox.Models.Shapes.Parameters;
using Newtonsoft.Json;

namespace Mindbox.Factories;

public class ShapesFactory
{
    public static Shape GetShape<T>(string code, T parameters) 
        where T : ShapeParameters
    {
        switch (code)
        {
            case ShapesCodes.Circle:
                var circleParameters = ConvertParameters<CircleParameters>(code, parameters);
                EnsureCanCreateCircle(circleParameters);
                return new Circle(circleParameters);
            
            case ShapesCodes.Triangle:
                var triangleParameters = ConvertParameters<TriangleParameters>(code, parameters);
                EnsureCanCreateTriangle(triangleParameters);
                return new Triangle(triangleParameters);
            
            default:
                throw new UnsupportedShapeCodeException(code);
        }
    }

    private static T ConvertParameters<T>(string shapeCode, ShapeParameters parameters) 
        where T : ShapeParameters
    {
        return parameters as T
               ?? throw new IncorrectShapeParametersTypeException(shapeCode, typeof(T).Name, parameters.GetType().Name);
    }

    private static void EnsureCanCreateCircle(CircleParameters parameters)
    {
        if (parameters.Radius <= 0)
        {
            var serializedParameters = JsonConvert.SerializeObject(parameters);
            throw new CreateCircleException(serializedParameters);
        }
    }

    private static void EnsureCanCreateTriangle(TriangleParameters parameters)
    {
        var isSidesPositive = parameters is { FirstSideLength: > 0, SecondSideLength: > 0, ThirdSideLength: > 0 };

        var isLengthCorrect = isSidesPositive
                && parameters.FirstSideLength + parameters.SecondSideLength > parameters.ThirdSideLength 
                && parameters.SecondSideLength + parameters.ThirdSideLength > parameters.FirstSideLength
                && parameters.ThirdSideLength + parameters.FirstSideLength > parameters.SecondSideLength;

        if (!isLengthCorrect)
        {
            var serializedParameters = JsonConvert.SerializeObject(parameters);
            throw new CreateTriangleException(serializedParameters);
        }
    }
}