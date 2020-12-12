using System.Threading.Tasks;

namespace Kryptos4
{
    class SolutionScorer
    {
        public async Task Score(ProblemCommand problem, Solution solution) {
            await Task.Run(() => {
                var allHintsPresentInCorrectPlace = true;
                solution.score = 0;            

                //1/n points each for having a clue present in the correct place.
                //1/n+1 points each for having a clue present in the wrong place.
                foreach (var hint in Config.solutionHints)
                {
                    if (HintIsPresentInCorrectPlace(hint, solution.decryptedText))
                    {
                        solution.score += (100 / Config.solutionHints.Count);
                        solution.narrative.Add($"{hint.hintText} is present in the correct place.");
                    }
                    else if (HintIsPresentInWrongPlace(hint, solution.decryptedText))
                    {
                        allHintsPresentInCorrectPlace = false;
                        solution.score += (100 / (Config.solutionHints.Count + 1));
                        solution.narrative.Add($"{hint.hintText} is present in the wrong place.");
                    }
                    else
                    {
                        allHintsPresentInCorrectPlace = false;
                    }
                }

                if (allHintsPresentInCorrectPlace) 
                {
                    solution.score = 100;
                    solution.narrative.Add("Perfect solution.");
                }
            });
        }

        private bool HintIsPresentInCorrectPlace(SolutionHint hint, string decryptedText)
        {
            return decryptedText.Substring(hint.indexWhereHintBeginsInEncryptedText, hint.hintText.Length) == hint.hintText;
        }

        private bool HintIsPresentInWrongPlace(SolutionHint hint, string decryptedText)
        {
            return decryptedText.Contains(hint.hintText);
        }
    }
}