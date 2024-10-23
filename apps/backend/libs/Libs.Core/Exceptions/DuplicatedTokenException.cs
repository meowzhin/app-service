namespace FwksLabs.Libs.Core.Exceptions;

public sealed class DuplicatedTokenException(string token) : Exception($"Token for '{token}' is duplicated. Use a different value.");
