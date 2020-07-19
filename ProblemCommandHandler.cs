namespace Kryptos4
{
    class ProblemCommandHandler
    {
        public Solution Solve(ProblemCommand problem)
        {
            var solution = new Solution();
            var keywordIndex = 0;

            foreach(var chr in problem.encryptedText.ToCharArray())
            {
                // We want to skip puctuation characters.
                if (!problem.alphabet.Contains(chr)) 
                {
                    solution.decryptedText += chr;
                    continue;
                }

                var keywordLetter = problem.keyword.Substring(keywordIndex, 1).ToCharArray()[0];
                var row = 0;

                for (var i = 0; i < problem.alphabet.Length; i++)
                {
                    if (problem.lookupTable[i, 0] == keywordLetter)
                    {
                        row = i;
                        break;
                    }
                }

                for (var i = 0; i < problem.alphabet.Length; i++) 
                {
                    if (problem.lookupTable[row, i] == chr)
                    {
                        solution.decryptedText += problem.lookupTable[0, i];
                        break;
                    }
                }

                keywordIndex++;
                if (keywordIndex >= problem.keyword.Length) {
                    keywordIndex = 0;
                }
            }

            return solution;
        }
    }
}