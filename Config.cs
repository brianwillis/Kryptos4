namespace Kryptos4
{
    static class Config
    {
        //The folder to save solutions to.
        public const string outputFolder = "";

        //Potential solutions receive a score from 0 (bad) to 100 (perfect).
        //We only report on solutions >= minimumScoreToReport.
        public const int minimumScoreToReport = 40;

        //Keywords are generated from A -> Z, then from AA -> ZZ, and so on.
        //The keyword that we start with is set by firstKeyword. Set this to something higher than "A" (e.g. "AAAAA") to skip over shorter keywords.
        public const string firstKeyword = "A";

        //We stop checking for solutions when we hit lastKeyword.
        public const string lastKeyword = "AAAAA";

        //The encrypted text that we're trying to decrypt. By defualt set to the text of the Kryptos 4 puzzle.
        public const string sourceText = "OBKRUOXOGHULBSOLIFBBWFLRVQQPRNGKSSOTWTQSJQSSEKZZWATJKLUDIAWINFBNYPVTTMZFPKWGDKZXTJCDIGKUHUAUEKCAR";

        //The alphabet that we use to build the Vigenère cypher lookup table.
        //Must be exactly 26 charachers long and contain every letter of the alphabet exactly once.
        public const string alphabet = "KRYPTOSABCDEFGHIJLMNQUVWXZ";
    }
}