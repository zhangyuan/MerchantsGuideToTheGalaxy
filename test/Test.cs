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

        [Fact(Skip="not implement")]
        public void should_calculate_intergalactic_numbers()
        {
            var progam = new MyProgram();
            progam.AddInput("glob is I\r\nprok is V\r\nhow much is prok glob ?");
            Assert.Equal("glob is 6", progam.GetOutputText());
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
