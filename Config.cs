using System.Collections.Generic;

namespace Kryptos4
{
    static class Config
    {
        //The folder to save solutions to.
        public const string outputFolder = "";

        //The location of your system's dictonary file. On most unix-like systems it's /usr/share/dict/words.
        //There's also a copy in this git repo if you don't have your own.
        public const string dictionaryFile = "/usr/share/dict/words";

        //Potential solutions receive a score from 0 (bad) to 100 (perfect).
        //We only report on solutions >= minimumScoreToReport.
        public const int minimumScoreToReport = 30;

        //The encrypted text that we're trying to decrypt. By defualt set to variations of the Kryptos 4 puzzle.
        public static List<ProblemDefinition> problemDefinitions = new List<ProblemDefinition>()
        {
            //Kryptos 4
            new ProblemDefinition {
                encryptedText = "OBKRUOXOGHULBSOLIFBBWFLRVQQPRNGKSSOTWTQSJQSSEKZZWATJKLUDIAWINFBNYPVTTMZFPKWGDKZXTJCDIGKUHUAUEKCAR",
                solutionHints = new List<SolutionHint> {
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
                }
            }
        };

        //The alphabet that we use to build the Vigenère cypher lookup table.
        //Must be exactly 26 charachers long and contain every letter of the alphabet exactly once.
        public const string alphabet = "KRYPTOSABCDEFGHIJLMNQUVWXZ";
    }
}