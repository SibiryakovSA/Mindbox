namespace Mindbox.Exceptions;

public class IncorrectShapeParametersTypeException(string shapeCode, string expectedParametersType, string actualParametersType)
    : Exception($@"Can't create shape '{shapeCode}', required parameters type '{expectedParametersType}', but was {actualParametersType}");