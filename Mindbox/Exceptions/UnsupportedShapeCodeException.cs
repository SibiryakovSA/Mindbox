namespace Mindbox.Exceptions;

public class UnsupportedShapeCodeException(string code) 
    : Exception($"Shape with code '{code}' not supported");