using FluentAssertions;
using Fwks.Libs.Core.Security.Tests.MemberData;

namespace Fwks.Libs.Core.Security.Tests;

public sealed class ObfuscatorTests : ObfuscatorMemberData
{
    public ObfuscatorTests()
    {
        Obfuscator.Configure(x =>
        {
            x.MinLength = 5;
            x.Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        });
    }

    [Theory(DisplayName = "Encode should return an encoded string with a least 5 characters.")]
    [MemberData(nameof(DefaultEncodingValues))]
    public void EncodeTest(int decodedValue, string encodedValue)
    {
        var actual = Obfuscator.Encode(decodedValue);

        actual.Should().Be(encodedValue);
        actual.Length.Should().BeGreaterThanOrEqualTo(5);
    }

    [Theory(DisplayName = "Encode with custom min length configuration should return an encoded string with the specified value.")]
    [MemberData(nameof(CustomMinLength))]
    public void EncodeWithCustomMinLengthTest(int minLength)
    {
        Obfuscator.Configure(x => x.MinLength = minLength);

        var actual = Obfuscator.Encode(1);

        actual.Length.Should().BeGreaterThanOrEqualTo(minLength);
    }

    [Theory(DisplayName = "Encode with custom alphabet configuration should return an encoded string different than the defaultsome w.")]
    [MemberData(nameof(CustomAlphabetEncodingValues))]
    public void EncodeWithCustomAlphabetTest(int decodedValue, string defaultValue, string customValue)
    {
        Obfuscator.Configure(x =>
        {
            x.Alphabet = "RB1u6xdkLFgifIVpWXN8DhweQEOTYqy0lUrabJHojcC974PMKvzmntA35SZG2s";
        });

        var actual = Obfuscator.Encode(decodedValue);

        actual.Should().NotBe(defaultValue);
        actual.Should().Be(customValue);
        actual.Length.Should().BeGreaterThanOrEqualTo(5);
    }

    [Theory(DisplayName = "Encode with salt should return an encoded string with a least 5 characters.")]
    [MemberData(nameof(SaltedEncodingValues))]
    public void EncodeWithSaltedTest(int decodedValue, string defaultValue, string saltedValue)
    {
        var actual = Obfuscator.Encode(decodedValue, 1);

        actual.Should().NotBe(defaultValue);
        actual.Should().Be(saltedValue);
        actual.Length.Should().BeGreaterThanOrEqualTo(5);
    }

    [Theory(DisplayName = "Decode should return the original number from when it was created.")]
    [MemberData(nameof(DefaultEncodingValues))]
    public void DecodeTest(int decodedValue, string encodedValue)
    {
        var actual = Obfuscator.Decode(encodedValue);

        actual.Should().Be(decodedValue);
    }

    [Theory(DisplayName = "Decode with salt should return the original number from when it was created.")]
    [MemberData(nameof(SaltedEncodingValues))]
    public void DecodeWithSaltTest(int decodedValue, string _, string saltedvalue)
    {
        var actual = Obfuscator.Decode(saltedvalue);

        actual.Should().Be(decodedValue);
    }
}
