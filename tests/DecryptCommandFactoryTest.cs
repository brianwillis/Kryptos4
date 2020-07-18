using System.Collections.Generic;
using Xunit;

namespace Kryptos4
{
    public class DecryptCommandFactoryTest
    {
        [Fact]
        public void GetNextCommand_WhenRequested26Times_KeywordIncrementsCorrectly()
        {
            var factory = new DecryptCommandFactory(new List<string>() { string.Empty }, string.Empty, "A");
            var command = new DecryptCommand();
            
            for (var i = 0; i <= 26; i++)
            {
                command = factory.GetNextCommand();
            }

            Assert.Equal("AA", command.keyword);
        }
    }
}