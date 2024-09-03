using System.Collections.Generic;

namespace Fwks.Libs.Core.Security.Tests.MemberData;

public class ObfuscatorMemberData
{
    protected ObfuscatorMemberData() { }

    public static IEnumerable<object[]> DefaultEncodingValues()
    {
        yield return new object[] { 1, "UkLWZ" };
        yield return new object[] { 2, "gbHJd" };
        yield return new object[] { 3, "EfhxL" };
        yield return new object[] { 10, "98Fqg" };
        yield return new object[] { 11, "xhoCp" };
        yield return new object[] { 12, "vEmzD" };
        yield return new object[] { 100, "86uR0" };
        yield return new object[] { 1000, "pndkl" };
        yield return new object[] { 10000, "RHEAe" };
        yield return new object[] { 100000, "ArUOs" };
        yield return new object[] { 1000000, "gMvFo" };
        yield return new object[] { 10000000, "PO2g6" };
    }

    public static IEnumerable<object[]> CustomAlphabetEncodingValues()
    {
        yield return new object[] { 1, "UkLWZ", "SKpiC" };
        yield return new object[] { 2, "gbHJd", "XwCqB" };
        yield return new object[] { 3, "EfhxL", "M0ZSO" };
        yield return new object[] { 10, "98Fqg", "QFPb9" };
        yield return new object[] { 11, "xhoCp", "blxRw" };
        yield return new object[] { 12, "vEmzD", "TN0Ys" };
        yield return new object[] { 100, "86uR0", "W8cjO" };
        yield return new object[] { 1000, "pndkl", "3dFvW" };
        yield return new object[] { 10000, "RHEAe", "x2DXw" };
        yield return new object[] { 100000, "ArUOs", "D3f28" };
        yield return new object[] { 1000000, "gMvFo", "XsQ8B" };
        yield return new object[] { 10000000, "PO2g6", "Y3ZKV" };
    }

    public static IEnumerable<object[]> SaltedEncodingValues()
    {
        yield return new object[] { 1, "UkLWZ", "kQKMT" };
        yield return new object[] { 2, "gbHJd", "XnbHb" };
        yield return new object[] { 3, "EfhxL", "jGwup" };
        yield return new object[] { 10, "98Fqg", "U6LgW" };
        yield return new object[] { 11, "xhoCp", "iwDjf" };
        yield return new object[] { 12, "vEmzD", "ojldr" };
        yield return new object[] { 100, "86uR0", "6VEgb" };
        yield return new object[] { 1000, "pndkl", "5WJQC" };
        yield return new object[] { 10000, "RHEAe", "gbjRHm" };
        yield return new object[] { 100000, "ArUOs", "RIkter" };
        yield return new object[] { 1000000, "gMvFo", "X3oLDbH" };
        yield return new object[] { 10000000, "PO2g6", "cthXVuQ" };
    }

    public static IEnumerable<object[]> CustomMinLength()
    {
        yield return new object[] { 6 };
        yield return new object[] { 7 };
        yield return new object[] { 8 };
        yield return new object[] { 9 };
        yield return new object[] { 10 };
    }
}