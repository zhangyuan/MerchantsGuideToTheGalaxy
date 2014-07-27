using System.Text.RegularExpressions;

namespace Galaxy
{
    public interface IInputLineHandler
    {
        bool Apply(string line);
    }

    public class DefinitionHandler : IInputLineHandler
    {
        private readonly MyProgram myProgram;

        public DefinitionHandler(MyProgram myProgram)
        {
            this.myProgram = myProgram;
        }

        public bool Apply(string line)
        {
            var match = Regex.Match(line, @"^(\w+) is ([I|V|X|L|C|D|M])$");

            if (match.Success)
            {
                var intergalacticNumber = match.Groups[1].Value;
                var romanNumber = match.Groups[2].Value;

                var value = RomanNumber.GetValue(romanNumber);

                var condition = new NumberCondition(intergalacticNumber, value);
                myProgram.AddDefinition(condition);
                return true;
            }
            return false;
        }
    }
}