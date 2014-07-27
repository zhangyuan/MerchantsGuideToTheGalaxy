using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace test
{
    public class MyProgram
    {
        private List<NumberCondition> inputs;
        private List<string> outputs;
        private Dictionary<string, long> things;

        public MyProgram()
        {
            inputs = new List<NumberCondition>();
            outputs = new List<string>();
            things = new Dictionary<string, long>();
        }

        public List<NumberCondition>  GetInputs()
        {
            return inputs;
        }

        public string GetOutputText()
        {
            return string.Join("\r\n", outputs);
        }

        public void AddInput(string text)
        {
            var lines = text.Split(new[] {'\r', '\n'});
            
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var match = Regex.Match(line, @"^(\w+) is ([I|V|X|L|C|D|M])$");

                if (match.Success)
                {
                    var intergalacticNumber = match.Groups[1].Value;
                    var romanNumber = match.Groups[2].Value;
                    
                    var value = RomanNumber.GetValue(romanNumber);

                    var condition = new NumberCondition(intergalacticNumber, value);
                    inputs.Add(condition);
                    continue;
                }

                match = Regex.Match(line, @"how many Credits is ((\w+ )+)(\w+) ?");
                if (match.Success)
                {
                    var intergalacticNumbers = match.Groups[1].Value.Trim();
                    var quantity = GetintergalacticNumbersValue(intergalacticNumbers);
                    var thingName = match.Groups[3].Value;
                    var price = things[thingName];
                    var total = price*quantity;
                    outputs.Add(string.Format("{0} {1} is {2} Credits", intergalacticNumbers, thingName, total));
                    continue;
                }

                match = Regex.Match(line, @"how much is(( \w+)+) ?");

                if (match.Success)
                {
                    var intergalacticNumbers = match.Groups[1].Value.Trim();
                    var total = GetintergalacticNumbersValue(intergalacticNumbers);
                    outputs.Add(string.Format("{0} is {1}", intergalacticNumbers, total));
                    continue;
                }

                match = Regex.Match(line, @"((\w+ )+)(\w+) is (\d+) Credits");
                if (match.Success)
                {
                    var intergalacticNumbers = match.Groups[1].Value;
                    var quantity = GetintergalacticNumbersValue(intergalacticNumbers);

                    var price = int.Parse(match.Groups[4].Value)/quantity;
                    things.Add(match.Groups[3].Value, price);
                    continue;
                }

                outputs.Add("I have no idea what you are talking about");
            }
        }

        private long GetintergalacticNumbersValue(string intergalacticNumbers)
        {
            var values = intergalacticNumbers.Trim().Split(' ');
            long total = 0;

            var valuesCount = values.Length;

            var current = 0;
            while (current < valuesCount)
            {
                var currentValue = IntergalacticNumberValue(values[current]);
                if ((current < valuesCount - 1))
                {
                    var nextValue = IntergalacticNumberValue(values[current + 1]);
                    if (currentValue < nextValue)
                    {
                        total += (nextValue - currentValue);
                        current += 2;
                        continue;
                    }
                }
                current++;
                total += currentValue;
            }
            return total;
        }

        private long IntergalacticNumberValue(string value)
        {
            var condition = inputs.FirstOrDefault(input => input.IntergalacticNumber == value);
            return (long) condition.Value;
        }
    }
}