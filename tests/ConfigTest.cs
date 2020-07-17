using Xunit;

namespace Kryptos4
{
    public class ConfigTest
    {
        [Fact]
        public void Config_Alphabet_Has26Characters()
        {
            Assert.True(Config.alphabet.Length == 26);
        }

        [Fact]
        public void Config_Alphabet_ContainsEachLetterOfTheAlphabet()
        {
            for (char chr = 'A'; chr <= 'Z'; chr++)
            {
                Assert.True(Config.alphabet.Contains(chr));
            }
        }

        [Fact]
        public void Config_MinimumScoreToReport_IsWithinAcceptableRange()
        {
            Assert.True(Config.minimumScoreToReport >= 0 && Config.minimumScoreToReport <= 100);
        }
    }
}