using Xunit;

namespace Kryptos4
{
    public class SolutionScorerTest
    {
        [Fact]
        public void Score_WhenGivenPerfectSolution_ScoreEqualsOneHundred() {
            var result = new KryptosCypherDecryptResult {
                solution = "                         NORTHEAST                             BERLINCLOCK                       "
            };
            var scorer = new SolutionScorer();

            scorer.Score(result);

            Assert.Equal(100, result.score);
        }

        [Fact]
        public void Score_WhenGivenNortheastInRightPlace_ScoreEqualsThirty() {
            var result = new KryptosCypherDecryptResult {
                solution = "                         NORTHEAST                                                               "
            };
            var scorer = new SolutionScorer();

            scorer.Score(result);

            Assert.Equal(30, result.score);
        }

        [Fact]
        public void Score_WhenGivenBerlinInRightPlace_ScoreEqualsThiry() {
            var result = new KryptosCypherDecryptResult {
                solution = "                                                               BERLIN                            "
            };
            var scorer = new SolutionScorer();

            scorer.Score(result);

            Assert.Equal(30, result.score);
        }

        [Fact]
        public void Score_WhenGivenClockInRightPlace_ScoreEqualsThiry() {
            var result = new KryptosCypherDecryptResult {
                solution = "                                                                     CLOCK                       "
            };
            var scorer = new SolutionScorer();

            scorer.Score(result);

            Assert.Equal(30, result.score);
        }

        [Fact]
        public void Score_WhenGivenNortheastInWrongPlace_ScoreEqualsTwenty() {
            var result = new KryptosCypherDecryptResult {
                solution = "NORTHEAST                                                                                        "
            };
            var scorer = new SolutionScorer();

            scorer.Score(result);

            Assert.Equal(20, result.score);
        }

        [Fact]
        public void Score_WhenGivenBerlinInWrongPlace_ScoreEqualsTwenty() {
            var result = new KryptosCypherDecryptResult {
                solution = "BERLIN                                                                                           "
            };
            var scorer = new SolutionScorer();

            scorer.Score(result);

            Assert.Equal(20, result.score);
        }

        [Fact]
        public void Score_WhenGivenClockInWrongPlace_ScoreEqualsTwenty() {
            var result = new KryptosCypherDecryptResult {
                solution = "CLOCK                                                                                            "
            };
            var scorer = new SolutionScorer();

            scorer.Score(result);

            Assert.Equal(20, result.score);
        }

        [Fact]
        public void Score_WhenGivenNortheastScattered_ScoreEqualsTen() {
            var result = new KryptosCypherDecryptResult {
                solution = " N O R T H E A S T                                                                               "
            };
            var scorer = new SolutionScorer();

            scorer.Score(result);

            Assert.Equal(10, result.score);
        }

        [Fact]
        public void Score_WhenGivenBerlinScattered_ScoreEqualsTen() {
            var result = new KryptosCypherDecryptResult {
                solution = " B E R L I N                                                                                     "
            };
            var scorer = new SolutionScorer();

            scorer.Score(result);

            Assert.Equal(10, result.score);
        }

        [Fact]
        public void Score_WhenGivenClockScattered_ScoreEqualsTen() {
            var result = new KryptosCypherDecryptResult {
                solution = " C L O C K                                                                                       "
            };
            var scorer = new SolutionScorer();

            scorer.Score(result);

            Assert.Equal(10, result.score);
        }
    }
}