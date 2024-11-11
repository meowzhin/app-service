namespace FwksLabs.Libs.Core.Extensions;

public static class StringExtensions
{
    public static bool IsEqualTo(this string source, string target) =>
        string.Equals(source, target, StringComparison.InvariantCultureIgnoreCase);

    public static bool HasValue(this string source) => !string.IsNullOrWhiteSpace(source);
}
