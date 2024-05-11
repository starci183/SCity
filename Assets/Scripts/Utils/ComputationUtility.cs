using System;
using System.Numerics;

public static class ComputationUtility
{
    public static float ComputeDenomination(
        BigInteger value,
        int decimals = 6,
        int fractionDigits = 2
        )
    {
        var decimalMultiplier = MathF.Pow(10, fractionDigits);
        var divisor = MathF.Pow(10, decimals);
        var result = (float)(value * new BigInteger(decimalMultiplier) / new BigInteger(divisor));
        return result / decimalMultiplier;
    }
}