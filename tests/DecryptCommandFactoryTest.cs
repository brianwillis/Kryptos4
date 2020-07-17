using Xunit;

namespace Kryptos4
{
    public class DecryptCommandFactoryTest
    {
        [Fact]
        public void GetNextCommand_WhenRequested26Times_KeywordIncrementsCorrectly()
        {
            var factory = new DecryptCommandFactory(string.Empty, string.Empty, "A");
            var command = new DecryptCommand();
            
            for (var i = 0; i <= 26; i++)
            {
                command = factory.GetNextCommand();
            }

            Assert.Equal("AA", command.keyword);
        }
    }
}