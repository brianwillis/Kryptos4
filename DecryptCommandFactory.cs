using System;
using System.Collections.Generic;

namespace Kryptos4
{
    class DecryptCommandFactory
    {
        private List<String> defaultSourceTexts;
        private int nextSourceTextIndex = 0;
        private string defaultAlphabet;
        private string nextKeyword;
        private char[,] defaultLookupTable;
        
        public DecryptCommandFactory(List<string> defaultSourceTexts, string defaultAlphabet, string nextKeyword)
        {
            this.defaultSourceTexts = defaultSourceTexts;
            this.defaultAlphabet = defaultAlphabet;
            this.nextKeyword = nextKeyword;
            BuildLookupTable();
        }

        public DecryptCommandFactory()
        {
            defaultSourceTexts = Config.sourceTexts;
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
                sourceText = defaultSourceTexts[nextSourceTextIndex],
                alphabet = defaultAlphabet,
                keyword = nextKeyword,
                lookupTable = defaultLookupTable
            };

            nextSourceTextIndex++;
            if (nextSourceTextIndex == defaultSourceTexts.Count) {
                nextSourceTextIndex = 0;
                nextKeyword = GenerateNextKeyword(nextKeyword);
            }            

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