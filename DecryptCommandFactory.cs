using System;

namespace Kryptos4
{
    class DecryptCommandFactory
    {

        private string defaultSourceText;
        private string defaultAlphabet;
        private string nextKeyword;
        private char[,] defaultLookupTable;
        
        public DecryptCommandFactory(string defaultSourceText, string defaultAlphabet, string nextKeyword)
        {
            this.defaultSourceText = defaultSourceText;
            this.defaultAlphabet = defaultAlphabet;
            this.nextKeyword = nextKeyword;
            BuildLookupTable();
        }

        public DecryptCommandFactory()
        {
            defaultSourceText = Config.sourceText;
            defaultAlphabet = Config.alphabet;
            nextKeyword = Config.firstKeyword;
            BuildLookupTable();
        }

        private void BuildLookupTable()
        {
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

        public DecryptCommand GetNextCommand()
        {            
            var command = new DecryptCommand {
                sourceText = defaultSourceText,
                alphabet = defaultAlphabet,
                keyword = nextKeyword,
                lookupTable = defaultLookupTable
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