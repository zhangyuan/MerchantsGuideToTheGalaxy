using Galaxy;
using Xunit;

namespace test
{
    public class Test
    {
        [Fact]
        public void should_calculate_one_intergalactic_number()
        {
            var progam = new MyProgram();
            progam.LoadText("glob is I\r\nhow much is glob ?");
            progam.Run();
            Assert.Equal("glob is 1", progam.GetOutputText());
        }

        [Fact]
        public void should_calculate_intergalactic_numbers_from_large_to_small()
        {
            var progam = new MyProgram();
            progam.LoadText("glob is I\r\nprok is V\r\nhow much is prok glob ?");
            progam.Run();
            Assert.Equal("prok glob is 6", progam.GetOutputText());
        }

        [Fact]
        public void should_calculate_intergalactic_numbers_from_small_to_large()
        {
            var progam = new MyProgram();
            progam.LoadText("glob is I\r\nprok is V\r\nhow much is glob prok ?");
            progam.Run();
            Assert.Equal("glob prok is 4", progam.GetOutputText());
        }

        [Fact]
        public void should_calculate_intergalactic_numbers_of_out_of_order()
        {
            var progam = new MyProgram();
            progam.LoadText("glob is I\r\nprok is V\r\npish is X\r\ntegj is L\r\nhow much is pish tegj glob glob ?");
            progam.Run();
            Assert.Equal("pish tegj glob glob is 42", progam.GetOutputText());
        }

        [Fact]
        public void should_calculate_total_price_of_intergalactic_things_of_Silver()
        {
            var progam = new MyProgram();
            progam.LoadText("glob is I\r\nprok is V\r\npish is X\r\ntegj is L\r\nglob glob Silver is 34 Credits\r\nhow many Credits is glob prok Silver ?");
            progam.Run();
            Assert.Equal("glob prok Silver is 68 Credits", progam.GetOutputText());
        }

        [Fact]
        public void should_calculate_total_price_of_intergalactic_things_of_Gold()
        {
            var progam = new MyProgram();
            progam.LoadText("glob is I\r\nprok is V\r\npish is X\r\ntegj is L\r\nglob prok Gold is 57800 Credits\r\nhow many Credits is glob prok Gold ?");
            progam.Run();
            Assert.Equal("glob prok Gold is 57800 Credits", progam.GetOutputText());
        }

        [Fact]
        public void should_calculate_total_price_of_intergalactic_things_of_Iron()
        {
            var progam = new MyProgram();
            progam.LoadText("glob is I\r\nprok is V\r\npish is X\r\ntegj is L\r\npish pish Iron is 3910 Credits\r\nhow many Credits is glob prok Iron ?");
            progam.Run();
            Assert.Equal("glob prok Iron is 782 Credits", progam.GetOutputText());
        }

        [Fact]
        public void should_return_error_message_with_unidentified_input()
        {
            var progam = new MyProgram();
            progam.LoadText("glob is I\r\nprok is V\r\npish is X\r\ntegj is L\r\nhow much wood could a woodchuck chuck if a woodchuck could chuck wood ?");
            progam.Run();
            Assert.Equal("I have no idea what you are talking about", progam.GetOutputText());
        }

        [Fact]
        public void should_return_all_outputs_for_all_inputs()
        {
            var progam = new MyProgram();
            var input = "glob is I\r\nprok is V\r\npish is X\r\ntegj is L\r\nglob glob Silver is 34 Credits\r\n" +
                        "glob prok Gold is 57800 Credits\r\npish pish Iron is 3910 Credits\r\n" +
                        "how much is pish tegj glob glob ?\r\nhow many Credits is glob prok Silver ?\r\n" +
                        "how many Credits is glob prok Gold ?\r\nhow many Credits is glob prok Iron ?\r\n" +
                        "how much wood could a woodchuck chuck if a woodchuck could chuck wood ?";
            var expected = "pish tegj glob glob is 42\r\nglob prok Silver is 68 Credits\r\n" +
                           "glob prok Gold is 57800 Credits\r\nglob prok Iron is 782 Credits\r\n" +
                           "I have no idea what you are talking about";
            progam.LoadText(input);
            progam.Run();
            Assert.Equal(expected, progam.GetOutputText());
        }
    }
}
