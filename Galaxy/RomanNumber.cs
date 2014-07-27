using System;

namespace Galaxy
{
    public class RomanNumber
    {
        public static RomanNumberValue GetValue(string romanNumber)
        {
            RomanNumberValue result;

            Enum.TryParse(romanNumber, out result);

            return result;
        }
    }

    public enum RomanNumberValue
    {
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }
}