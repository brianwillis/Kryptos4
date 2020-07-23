using System;
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
                if (!Config.alphabet.Contains(chr)) 
                {
                    solution.decryptedText += chr;
                    continue;
                }

                var keywordLetter = Convert.ToChar(problem.keyword.Substring(keywordIndex, 1));
                
                var row = 0;
                for (row = 0; row < Config.alphabet.Length; row++)
                {
                    if (Config.lookupTable[row, 0] == keywordLetter)
                    {
                        break;
                    }
                }
                
                var col = 0;
                for (col = 0; col < Config.alphabet.Length; col++) 
                {
                    if (Config.lookupTable[row, col] == chr)
                    {
                        solution.decryptedText += Config.lookupTable[0, col];
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