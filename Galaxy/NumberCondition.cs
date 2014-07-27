using System;

namespace Galaxy
{
    public class NumberCondition
    {
        public NumberCondition(string intergalacticNumber, RomanNumberValue value)
        {
            Value = value;
            IntergalacticNumber = intergalacticNumber;
        }

        public RomanNumberValue Value {get; private set; }

        public string IntergalacticNumber { get; private set;}
    }
}