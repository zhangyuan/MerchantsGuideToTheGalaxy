using System.Collections.Generic;
using System.Linq;

namespace Galaxy
{
    public class MyProgram
    {
        private readonly Dictionary<string, RomanNumberValue> definitions;
        private readonly List<string> outputs;
        private readonly Dictionary<string, decimal> things;
        private readonly List<IInputLineHandler> handlers;
        private string input;

        public MyProgram()
        {
            definitions = new Dictionary<string, RomanNumberValue>();
            outputs = new List<string>();
            things = new Dictionary<string, decimal>();

            handlers = new List<IInputLineHandler>
                {
                    new DefinitionHandler(this),
                    new ThingCreditsCalculator(this),
                    new NumberCalculator(this),
                    new ThingPriceCalculator(this)
                };
        }

        public string GetOutputText()
        {
            return string.Join("\r\n", outputs);
        }

        public void LoadText(string text)
        {
            input = text;
        }

        public void Run(string text)
        {
            var lines = text.Split(new[] {'\r', '\n'});

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var handler = handlers.FirstOrDefault(h => h.Apply(line));

                if (handler != null)
                {
                    continue;
                }

                outputs.Add("I have no idea what you are talking about");
            }
        }

        public void AddThing(string value, decimal price)
        {
            things.Add(value, price);
        }

        public void AddOutputs(string format)
        {
            outputs.Add(format);
        }

        public void AddDefinition(NumberCondition condition)
        {
            definitions.Add(condition.IntergalacticNumber, condition.Value);
        }

        public decimal GetThingPrice(string name)
        {
            return things[name];
        }

        public long GetintergalacticNumbersValue(string intergalacticNumbers)
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

        private long IntergalacticNumberValue(string intergalacticNumber)
        {
            return (long)definitions[intergalacticNumber];
        }
    }
}