using System.Collections.Generic;
using Xunit;

namespace Kryptos4
{
    public class DecryptCommandFactoryTest
    {
        [Fact]
        public void GetNextCommand_WhenRequested26Times_KeywordIncrementsCorrectly()
        {
            var factory = new ProblemCommandFactory(new List<ProblemDefinition>() { new ProblemDefinition() }, string.Empty, "A");
            var command = new ProblemCommand();
            
            for (var i = 0; i <= 26; i++)
            {
                command = factory.GetNextCommand();
            }

            Assert.Equal("AA", command.keyword);
        }
    }
}