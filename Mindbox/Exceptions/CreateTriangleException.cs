namespace Mindbox.Exceptions;

public class CreateTriangleException(string serializedParameters)
    : Exception($"Can't create triangle with parameters: {serializedParameters}");