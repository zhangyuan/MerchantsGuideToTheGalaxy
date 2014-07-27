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

        [Fact(Skip = "not implement")]
        public void should_calculate_total_price_of_intergalactic_goods()
        {
            
        }

        [Fact(Skip = "not implement")]
        public void should_return_error_message_with_invalid_question()
        {
            
        }
    }
}
