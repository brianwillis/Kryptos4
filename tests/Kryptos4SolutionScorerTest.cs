using Xunit;

namespace Kryptos4
{
    class Kryptos4SolutionScorerTest
    {
        [Fact]
        public void Score_WhenGivenPerfectSolution_ScoreEqualsOneHundred() {
            var result = new KryptosCypherDecryptResult {
                solution = "                         NORTHEAST                             BERLINCLOCK                       "
            };
            var scorer = new Kryptos4SolutionScorer();

            scorer.Score(result);

            Assert.Equal(100, result.score);
        }

        [Fact]
        public void Score_WhenGivenNortheast_ScoreEqualsThirty() {
            var result = new KryptosCypherDecryptResult {
                solution = "                         NORTHEAST                                                               "
            };
            var scorer = new Kryptos4SolutionScorer();

            scorer.Score(result);

            Assert.Equal(30, result.score);
        }

        [Fact]
        public void Score_WhenGivenBerlin_ScoreEqualsThiry() {
            var result = new KryptosCypherDecryptResult {
                solution = "                                                               BERLIN                            "
            };
            var scorer = new Kryptos4SolutionScorer();

            scorer.Score(result);

            Assert.Equal(30, result.score);
        }

        [Fact]
        public void Score_WhenGivenClock_ScoreEqualsThiry() {
            var result = new KryptosCypherDecryptResult {
                solution = "                                                                     CLOCK                       "
            };
            var scorer = new Kryptos4SolutionScorer();

            scorer.Score(result);

            Assert.Equal(30, result.score);
        }    
    }
}