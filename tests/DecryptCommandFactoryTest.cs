using Xunit;

namespace Kryptos4
{
    public class DecryptCommandFactoryTest
    {
        [Fact]
        public void FirstKeywordIsA()
        {
            var factory = new DecryptCommandFactory();
            var command = factory.GetNextCommand();
            Assert.Equal("A", command.keyword);
        }

        [Fact]
        public void KeywordIncrementsCorrectly()
        {
            var factory = new DecryptCommandFactory();
            var command = new DecryptCommand();
            
            for (var i = 0; i <= 26; i++)
            {
                command = factory.GetNextCommand();
            }

            Assert.Equal("AA", command.keyword);
        }
    }
}