using System.Collections.Generic;

namespace Kryptos4
{
    class ProblemCommand
    {
        public string encryptedText;
        public string keyword;
        public string alphabet;
        public char[,] lookupTable;
        public List<SolutionHint> solutionHints;
    }
}