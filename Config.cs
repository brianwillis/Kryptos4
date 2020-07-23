using System.Collections.Generic;

namespace Kryptos4
{
    static class Config
    {
        //The folder to save solutions to. Don't leave a slash at the very end.
        public const string outputFolder = "/Users/Brian/Development/Kryptos4/output";

        //The location of your system's dictonary file. On most unix-like systems it's /usr/share/dict/words.
        //There's also a copy in this git repo if you don't have your own.
        public const string dictionaryFile = "/usr/share/dict/words";

        //Potential solutions receive a score from 0 (bad) to 100 (perfect).
        //We only report on solutions >= minimumScoreToReport.
        public const int minimumScoreToReport = 30;

        //The alphabet that we use to build the Vigenère cypher lookup table.
        //Must be exactly 26 charachers long and contain every letter of the alphabet exactly once.
        public const string alphabet = "KRYPTOSABCDEFGHIJLMNQUVWXZ";

        //The lookup tbal which we use to decrypt Vigenère cyphers.
        //You don't need to set this yourself. It will be populated from the alphabet automatically.
        public static char[,] lookupTable = new char[alphabet.Length, alphabet.Length];

        //The encrypted text that we're trying to decrypt. By defualt set to the Kryptos 4 puzzle.
        public const string encryptedText = "OBKRUOXOGHULBSOLIFBBWFLRVQQPRNGKSSOTWTQSJQSSEKZZWATJKLUDIAWINFBNYPVTTMZFPKWGDKZXTJCDIGKUHUAUEKCAR";
        
        //Hints that we have about the solved version of the puzzle. We use these for scoring solutions.
        public static List<SolutionHint> solutionHints = new List<SolutionHint>
        {
            new SolutionHint
            {
                hintText = "NORTHEAST",
                indexWhereHintBeginsInEncryptedText = 25
            },
            new SolutionHint
            {
                hintText = "BERLIN",
                indexWhereHintBeginsInEncryptedText = 63
            },
            new SolutionHint 
            {
                hintText = "CLOCK",
                indexWhereHintBeginsInEncryptedText = 69
            }
        };
    }
}