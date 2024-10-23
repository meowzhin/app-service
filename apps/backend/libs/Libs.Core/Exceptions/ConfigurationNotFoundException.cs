namespace FwksLabs.Libs.Core.Exceptions;

public sealed class ConfigurationNotFoundException() : Exception("Obfuscator configuration was not found. Try calling .Configure() first.");
