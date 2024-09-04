namespace FwksLabs.Libs.Core.Security.Exceptions;

public sealed class ConfigurationNotFoundException() : Exception("Obfuscator configuration was not found. Try calling .Configure() first.");
