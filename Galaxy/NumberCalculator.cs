using System.Text.RegularExpressions;

namespace Galaxy
{
    public class NumberCalculator : IInputLineHandler
    {
        private readonly MyProgram myProgram;

        public NumberCalculator(MyProgram myProgram)
        {
            this.myProgram = myProgram;
        }

        public bool Apply(string line)
        {
            var match = Regex.Match(line, @"how much is(( \w+)+) ?");

            if (match.Success)
            {
                var intergalacticNumbers = match.Groups[1].Value.Trim();
                var total = myProgram.GetintergalacticNumbersValue(intergalacticNumbers);
                myProgram.AddOutputs(string.Format("{0} is {1}", intergalacticNumbers, total));
                return true;
            }
            return false;
        }
    }
}