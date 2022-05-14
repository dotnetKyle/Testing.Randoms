using System;
using System.Security.Cryptography;

namespace Testing.Randoms;

public static class RandomGenerator
{
    static RandomNumberGenerator _randomNumberGenerator = RandomNumberGenerator.Create();

    public static string GetRandomString(int length = 12, bool removeSpecialChars = true)
    {
        var bytes = new byte[length];
        _randomNumberGenerator.GetBytes(bytes);
        var base64 = Convert.ToBase64String(bytes);
        if (removeSpecialChars)
        {
            return base64
                .Replace('/', 'x')
                .Replace('+', 'x')
                .Replace('=', 'x');
        }
        else
        {
            return base64;
        }
    }
}
