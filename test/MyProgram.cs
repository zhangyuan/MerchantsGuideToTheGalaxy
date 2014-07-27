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

        public MyProgram()
        {
            inputs = new List<NumberCondition>();
            outputs = new List<string>();
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

                match = Regex.Match(line, @"how much is (\w+) ?");

                if (match.Success)
                {
                    var value = match.Groups[1].Value.Trim();

                    var condition = inputs.FirstOrDefault(input => input.IntergalacticNumber == value);

                    outputs.Add(string.Format("{0} is {1}", value, (int)condition.Value));
                    continue;
                }
            }
        }
    }
}