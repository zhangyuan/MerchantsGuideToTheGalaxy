using System.Text.RegularExpressions;

namespace Galaxy
{
    public class ThingPriceCalculator : IInputLineHandler
    {
        private readonly MyProgram myProgram;

        public ThingPriceCalculator(MyProgram myProgram)
        {
            this.myProgram = myProgram;
        }

        public bool Apply(string line)
        {
            var match = Regex.Match(line, @"((\w+ )+)(\w+) is (\d+) Credits");
            if (match.Success)
            {
                var intergalacticNumbers = match.Groups[1].Value;
                var quantity = myProgram.GetintergalacticNumbersValue(intergalacticNumbers);

                var price = decimal.Parse(match.Groups[4].Value)/quantity;
                var name = match.Groups[3].Value;
                myProgram.AddThing(name, price);
                return true;
            }
            return false;
        }
    }
}