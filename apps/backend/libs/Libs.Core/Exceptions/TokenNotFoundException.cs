namespace FwksLabs.Libs.Core.Exceptions;

public sealed class TokenNotFoundException(int token) : Exception($"Obfuscator Token '{token}' was not found.");
