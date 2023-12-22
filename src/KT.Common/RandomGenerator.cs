using System.Security.Cryptography;
using System.Text;

namespace KT.Common;

public sealed class RandomGenerator
{
    public const string LowerLetters = "abcdefghijklmnopqrstuvwxyz";
    public const string UpperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public const string SpecialCharacters = "`~!@#$%^&*()-_[{]}\\|;:'\",.>/?"; //remove '<'
    public const string Numbers = "0123456789";

    public string GenerateNumbers(int length)
    {
        return Generate(length, numbers: true, lowerChars: false, upperChars: false, specialChars: false);
    }

    public string GenerateLowerChars(int length)
    {
        return Generate(length, numbers: false, lowerChars: true, upperChars: false, specialChars: false);
    }

    public string GenerateUpperChars(int length)
    {
        return Generate(length, numbers: false, lowerChars: false, upperChars: true, specialChars: false);
    }

    public string GenerateLowerUpperChars(int length)
    {
        return Generate(length, numbers: false, lowerChars: true, upperChars: true, specialChars: false);
    }

    public string GenerateSpecialChars(int length)
    {
        return Generate(length, numbers: false, lowerChars: false, upperChars: false, specialChars: true);
    }

    public string Generate(int length, bool numbers = true, bool lowerChars = true, bool upperChars = true, bool specialChars = true)
    {
        var generate = new StringBuilder();

        var patterns = new List<string>();
        if (numbers) patterns.Add(Numbers);
        if (lowerChars) patterns.Add(LowerLetters);
        if (upperChars) patterns.Add(UpperLetters);
        if (specialChars) patterns.Add(SpecialCharacters);
        if (patterns.Count == 0) patterns.Add(Numbers); //all conditions pattern is false, get number pattern as default

        for (var i = 0; i < length; i++)
        {
            byte index = (patterns.Count > 0) ? GenerateRandomDigit((byte)patterns.Count) : (byte)0;
            generate.Append(GenerateString(1, patterns[index]));
        }

        return generate.ToString();
    }

    /// <summary>
    /// RandomStringGenerator constants (LowerLetters, UpperLetters, SpecialCharacters, Numbers), maximum length of parttern is 255
    /// </summary>
    public string GenerateString(int lengh, string pattern)
    {
        var generate = new StringBuilder();

        var generatePattern = pattern.Length <= 255 ? pattern : pattern[..255];

        for (var i = 0; i < lengh; i++)
        {
            var roll = GenerateRandomDigit((byte)generatePattern.Length);
            generate.Append(generatePattern[roll]);
        }

        return generate.ToString();
    }

    #region Generate processing

    private RNGCryptoServiceProvider _rgnCrypto;

    private byte GenerateRandomDigit(byte numberSides = 10)
    {
        if (numberSides <= 0 || numberSides > 255)
        {
            throw new ArgumentOutOfRangeException("number sides must be between 1 and 255");
        }

        // Create a new instance of the RNGCryptoServiceProvider.
        if (_rgnCrypto == null) _rgnCrypto = new RNGCryptoServiceProvider();

        // Create a byte array to hold the random value.
        var randomNumber = new byte[1];

        do
        {
            // Fill the array with a random value.
            _rgnCrypto.GetBytes(randomNumber);
        }
        while (!IsFairRoll(randomNumber[0], numberSides));

        return (byte)(randomNumber[0] % numberSides);
    }

    private bool IsFairRoll(byte roll, byte numSides)
    {
        // There are MaxValue / numSides full sets of numbers that can come up
        // in a single byte.  For instance, if we have a 6 sided die, there are
        // 42 full sets of 1-6 that come up.  The 43rd set is incomplete.
        var fullSetsOfValues = Byte.MaxValue / numSides;

        // If the roll is within this range of fair values, then we let it continue.
        // In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use
        // < rather than <= since the = portion allows through an extra 0 value).
        // 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair
        // to use.
        return roll < numSides * fullSetsOfValues;
    }

    #endregion
}