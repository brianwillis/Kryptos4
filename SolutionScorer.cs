namespace Kryptos4
{
    class SolutionScorer
    {
        public void Score(ProblemCommand problem, Solution solution) {
            solution.score = 0;

            //100 points for having all hits present and in the correct place.
            if (AllHintsPresentInCorrectPlace(problem, solution))
            {
                solution.score = 100;
                solution.narrative.Add("Perfect solution.");
                return;
            }

            //1/n points each for having a clue present in the correct place.
            //1/n+1 points each for having a clue present in the wrong place.
            foreach (var hint in problem.solutionHints)
            {
                if (HintIsPresentInCorrectPlace(hint, solution.decryptedText))
                {
                    solution.score += (100 / problem.solutionHints.Count);
                    solution.narrative.Add($"{hint.hintText} is present in the correct place.");
                }
                else if (HintIsPresentInWrongPlace(hint, solution.decryptedText))
                {
                    solution.score += (100 / (problem.solutionHints.Count + 1));
                    solution.narrative.Add($"{hint.hintText} is present in the wrong place.");
                }                
            }
        }

        private bool AllHintsPresentInCorrectPlace(ProblemCommand problem, Solution solution)
        {
            foreach (var hint in problem.solutionHints)
            {
                if (!HintIsPresentInCorrectPlace(hint, solution.decryptedText))
                {
                    return false;
                }
            }
            return true;       
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