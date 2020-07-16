using Xunit;

namespace Kryptos4
{
    public class KryptosCypherDecryptCommandFactoryTest
    {
        [Fact]
        public void FirstKeywordIsA()
        {
            var factory = new KryptosCypherDecryptCommandFactory();
            var command = factory.GetNextCommand();
            Assert.Equal("A", command.keyword);
        }

        [Fact]
        public void KeywordIncrementsCorrectly()
        {
            var factory = new KryptosCypherDecryptCommandFactory();
            var command = new DecryptCommand();
            
            for (var i = 0; i <= 26; i++)
            {
                command = factory.GetNextCommand();
            }

            Assert.Equal("AA", command.keyword);
        }
    }
}