namespace Kryptos4
{
    class SolutionScorer
    {
        public void Score(DecryptCommandResult result) {
            result.score = 0;
            var northeastPresentInCorrectPlace = IsNortheastPresentInCorrectPlace(result.solution);
            var berlinPresentInCorrectPlace = IsBerlinPresentInCorrectPlace(result.solution);
            var clockPresentInCorrectPlace = IsClockPresentInCorrectPlace(result.solution);

            //100 points for having all three clues present and in the correct place.
            if (northeastPresentInCorrectPlace && berlinPresentInCorrectPlace && clockPresentInCorrectPlace)
            {
                result.score = 100;
                result.narrative.Add("Perfect solution.");
                return;
            }

            //30 points each for having a clue present in the correct place.
            //20 points each for having a clue present in the wrong place.
            //10 points for having the characters that make up a clue scattered somewhere in the solution.
            if (northeastPresentInCorrectPlace)
            {
                result.score += 30;
                result.narrative.Add("Northeast is present in the correct place.");
            }
            else if (IsNortheastPresentInWrongPlace(result.solution))
            {
                result.score += 20;
                result.narrative.Add("Northeast is present in the wrong place.");
            }
            else if (IsNortheastScatteredInTheSolution(result.solution))
            {
                result.score += 10;
                result.narrative.Add("Northeast is scattered in the solution.");
            }

            if (berlinPresentInCorrectPlace)
            {
                result.score += 30;
                result.narrative.Add("Berlin is present in the correct place.");
            }
            else if (IsBerlinPresentInWrongPlace(result.solution))
            {
                result.score += 20;
                result.narrative.Add("Berlin is present in the wrong place.");
            }
            else if (IsBerlinScatteredInTheSolution(result.solution))
            {
                result.score += 10;
                result.narrative.Add("Berlin is scattered in the solution.");
            }

            if (clockPresentInCorrectPlace)
            {
                result.score += 30;
                result.narrative.Add("Clock is present in the correct place.");
            }
            else if (IsClockPresentInWrongPlace(result.solution))
            {
                result.score += 20;
                result.narrative.Add("Clock is present in the wrong place.");
            }
            else if (IsClockScatteredInTheSolution(result.solution))
            {
                result.score += 10;
                result.narrative.Add("Clock is scattered in the solution.");
            }
        }

        private bool IsNortheastPresentInCorrectPlace(string solution)
        {
            return solution.Substring(25, 9) == "NORTHEAST";
        }

        private bool IsBerlinPresentInCorrectPlace(string solution)
        {
            return solution.Substring(63, 6) == "BERLIN";
        }

        private bool IsClockPresentInCorrectPlace(string solution)
        {
            return solution.Substring(69, 5) == "CLOCK";
        }

        private bool IsNortheastPresentInWrongPlace(string solution)
        {
            return !IsNortheastPresentInCorrectPlace(solution) && solution.Contains("NORTHEAST");
        }

        private bool IsBerlinPresentInWrongPlace(string solution)
        {
            return !IsBerlinPresentInCorrectPlace(solution) && solution.Contains("BERLIN");
        }

        private bool IsClockPresentInWrongPlace(string solution)
        {
            return !IsClockPresentInCorrectPlace(solution) && solution.Contains("CLOCK");
        }

        private bool IsNortheastScatteredInTheSolution(string solution)
        {
            return IsStringScatteredInSolution("NORTHEAST", solution);
        }

        private bool IsBerlinScatteredInTheSolution(string solution)
        {
            return IsStringScatteredInSolution("BERLIN", solution);
        }

        private bool IsClockScatteredInTheSolution(string solution)
        {
            return IsStringScatteredInSolution("CLOCK", solution);
        }

        private bool IsStringScatteredInSolution(string search, string solution)
        {
            var chars = search.ToCharArray();
            foreach (var chr in chars)
            {
                if (!solution.Contains(chr))
                {
                    return false;
                }
                solution.Remove(solution.IndexOf(chr), 1);
            }
            return true;
        }
    }
}