using System;

namespace Kryptos4
{
    class KryptosCypherDecryptCommandFactory
    {

        private string defaultsourceText = "OBKRUOXOGHULBSOLIFBBWFLRVQQPRNGKSSOTWTQSJQSSEKZZWATJKLUDIAWINFBNYPVTTMZFPKWGDKZXTJCDIGKUHUAUEKCAR";
        private string defaultAlphabet = "KRYPTOSABCDEFGHIJLMNQUVWXZ";
        private char[,] defaultLookupTable;
        private string nextKeyword;
        
        public KryptosCypherDecryptCommandFactory()
        {
            nextKeyword = "A";

            defaultLookupTable = new char[defaultAlphabet.Length, defaultAlphabet.Length];
            for (var i = 0; i < defaultAlphabet.Length; i++)
            {
                for (var j = 0; j < defaultAlphabet.Length; j++)
                {
                    var index = i + j;
                    if (index >= defaultAlphabet.Length) {
                        index -= defaultAlphabet.Length;
                    }
                    var letter = defaultAlphabet.Substring(index, 1).ToCharArray()[0];
                    defaultLookupTable[i,j] = letter;
                }
            }
        }

        public KryptosCypherDecryptCommand GetNextCommand()
        {
            var command = new KryptosCypherDecryptCommand {
                sourceText = defaultsourceText,
                alphabet = defaultAlphabet,
                lookupTable = defaultLookupTable,
                keyword = nextKeyword
            };

            nextKeyword = GenerateNextKeyword(nextKeyword);

            return command;
        }

        private string GenerateNextKeyword(string oldKeyword)
        {
            if (oldKeyword == string.Empty) {
                return "A";
            }

            var allCharsExceptLast = oldKeyword.Substring(0, oldKeyword.Length-1);
            var lastChar = oldKeyword.Substring(oldKeyword.Length-1, 1);

            if (lastChar == "Z") 
            {
                return GenerateNextKeyword(allCharsExceptLast) + "A";
            }
            else
            {
                var nextChar = Convert.ToChar(lastChar);
                nextChar++;
                return allCharsExceptLast + nextChar;
            }
        }
    }
}