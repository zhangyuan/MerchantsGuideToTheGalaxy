using Xunit;

namespace test
{
    public class Test
    {
        [Fact]
        public void should_calculate_one_intergalactic_number()
        {
            var progam = new MyProgram();
            progam.AddInput("glob is I\r\nhow much is glob ?");
            Assert.Equal("glob is 1", progam.GetOutputText());
        }

        [Fact]
        public void should_calculate_intergalactic_numbers_from_large_to_small()
        {
            var progam = new MyProgram();
            progam.AddInput("glob is I\r\nprok is V\r\nhow much is prok glob ?");
            Assert.Equal("prok glob is 6", progam.GetOutputText());
        }

        [Fact]
        public void should_calculate_intergalactic_numbers_from_small_to_large()
        {
            var progam = new MyProgram();
            progam.AddInput("glob is I\r\nprok is V\r\nhow much is glob prok ?");
            Assert.Equal("glob prok is 4", progam.GetOutputText());
        }

        [Fact]
        public void should_calculate_intergalactic_numbers_of_out_of_order()
        {
            var progam = new MyProgram();
            progam.AddInput("glob is I\r\nprok is V\r\npish is X\r\ntegj is L\r\nhow much is pish tegj glob glob ?");
            Assert.Equal("pish tegj glob glob is 42", progam.GetOutputText());
        }

        [Fact]
        public void should_calculate_total_price_of_intergalactic_things()
        {
            var progam = new MyProgram();
            progam.AddInput("glob is I\r\nprok is V\r\npish is X\r\ntegj is L\r\nglob glob Silver is 34 Credits\r\nhow many Credits is glob prok Silver ?");
            Assert.Equal("glob prok Silver is 68 Credits", progam.GetOutputText());
        }

        [Fact]
        public void should_return_error_message_with_unidentified_input()
        {
            var progam = new MyProgram();
            progam.AddInput("glob is I\r\nprok is V\r\npish is X\r\ntegj is L\r\nhow much wood could a woodchuck chuck if a woodchuck could chuck wood ?");
            Assert.Equal("I have no idea what you are talking about", progam.GetOutputText());
        }
    }
}
