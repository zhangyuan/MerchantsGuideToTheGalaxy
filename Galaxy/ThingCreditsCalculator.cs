using System.Text.RegularExpressions;

namespace Galaxy
{
    public class ThingCreditsCalculator : IInputLineHandler
    {
        private readonly MyProgram myProgram;

        public ThingCreditsCalculator(MyProgram myProgram)
        {
            this.myProgram = myProgram;
        }

        public bool Apply(string line)
        {
            var match = Regex.Match(line, @"how many Credits is ((\w+ )+)(\w+) ?");
            if (match.Success)
            {
                var intergalacticNumbers = match.Groups[1].Value.Trim();
                var quantity = myProgram.GetintergalacticNumbersValue(intergalacticNumbers);
                var thingName = match.Groups[3].Value;
                var price = myProgram.GetThingPrice(thingName);
                var total = price*quantity;

                var output = string.Format("{0} {1} is {2:0.#} Credits", intergalacticNumbers, thingName, total);
                myProgram.AddOutputs(output);
                return true;
            }
            return false;
        }
    }
}