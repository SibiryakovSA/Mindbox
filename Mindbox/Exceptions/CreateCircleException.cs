namespace Mindbox.Exceptions;

public class CreateCircleException(string serializedParameters)
    : Exception($"Can't create circle with parameters: {serializedParameters}");