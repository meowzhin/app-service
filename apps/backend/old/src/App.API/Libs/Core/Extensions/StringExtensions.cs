using FwksLab.Libs.Core.Constants;

namespace FwksLabs.Libs.Core.Extensions;

public static class StringExtensions
{
    public static string RemoveSpaces(this string value) =>
        value.Replace(" ", string.Empty);

    public static string SpaceTitleCase(this string value) =>
        RegexPatterns.TitleCase().Replace(value, " $1").Trim();

    public static string ToPascalCase(this string value, bool removeSpaces = false)
    {
        value = RegexPatterns.PascalCase().Replace(value, match => match.Groups[1].Value.ToUpper());

        return removeSpaces ? value.RemoveSpaces() : value;
    }

    public static string ToCamelCase(this string value, bool removeSpaces = false)
    {
        value = value.ToPascalCase();

        value = value.Length > 0 ? value[..1].ToLower() + value[1..] : value;

        return removeSpaces ? value.RemoveSpaces() : value;
    }

    public static string ToSlugCase(this string value, bool lowerCase = true) =>
        ToSlugSnakeCase(value, "-", lowerCase);

    public static string ToSnakeCase(this string value, bool lowerCase = true) =>
        ToSlugSnakeCase(value, "_", lowerCase);

    private static string ToSlugSnakeCase(string value, string character, bool toLower)
    {
        value = RegexPatterns.SlugSnakeStepOne().Replace(value, $"$1{character}$2");

        value = RegexPatterns.SlugSnakeStepTwo().Replace(value, $"$1{character}$2");

        value = RegexPatterns.SlugSnakeStepThree().Replace(value, character);

        return toLower ? value.ToLower() : value;
    }
}
