using System.Collections.Generic;
using Xunit;

namespace Kryptos4
{
    public class SolutionScorerTest
    {
        [Fact]
        public void Score_WhenGivenPerfectSolution_ScoreEqualsOneHundred() {
            var problem = GetDefaultProblem();
            var solution = new Solution 
            {
                decryptedText = "                         NORTHEAST                             BERLINCLOCK                       "
            };
            var scorer = new SolutionScorer();

            scorer.Score(problem, solution);

            Assert.Equal(100, solution.score);
        }

        [Fact]
        public void Score_WhenGivenNortheastInRightPlace_ScoreEqualsThirty() {
            var problem = GetDefaultProblem();
            var solution = new Solution 
            {
                decryptedText = "                         NORTHEAST                                                               "
            };
            var scorer = new SolutionScorer();

            scorer.Score(problem, solution);

            Assert.Equal(33, solution.score);
        }

        [Fact]
        public void Score_WhenGivenBerlinInRightPlace_ScoreEqualsThiry() {
            var problem = GetDefaultProblem();
            var solution = new Solution {
                decryptedText = "                                                               BERLIN                            "
            };
            var scorer = new SolutionScorer();

            scorer.Score(problem, solution);

            Assert.Equal(33, solution.score);
        }

        [Fact]
        public void Score_WhenGivenClockInRightPlace_ScoreEqualsThiry() {
            var problem = GetDefaultProblem();
            var solution = new Solution {
                decryptedText = "                                                                     CLOCK                       "
            };
            var scorer = new SolutionScorer();

            scorer.Score(problem, solution);

            Assert.Equal(33, solution.score);
        }

        [Fact]
        public void Score_WhenGivenNortheastInWrongPlace_ScoreEqualsTwenty() {
            var problem = GetDefaultProblem();
            var solution = new Solution {
                decryptedText = "NORTHEAST                                                                                        "
            };
            var scorer = new SolutionScorer();

            scorer.Score(problem, solution);

            Assert.Equal(25, solution.score);
        }

        [Fact]
        public void Score_WhenGivenBerlinInWrongPlace_ScoreEqualsTwenty() {
            var problem = GetDefaultProblem();
            var solution = new Solution {
                decryptedText = "BERLIN                                                                                           "
            };
            var scorer = new SolutionScorer();

            scorer.Score(problem, solution);

            Assert.Equal(25, solution.score);
        }

        [Fact]
        public void Score_WhenGivenClockInWrongPlace_ScoreEqualsTwenty() {
            var problem = GetDefaultProblem();
            var solution = new Solution {
                decryptedText = "CLOCK                                                                                            "
            };
            var scorer = new SolutionScorer();

            scorer.Score(problem, solution);

            Assert.Equal(25, solution.score);
        }

        private ProblemCommand GetDefaultProblem()
        {
            return new ProblemCommand {
                encryptedText = Config.encryptedText
            };
        }
    }
}