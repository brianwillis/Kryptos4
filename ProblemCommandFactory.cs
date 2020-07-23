using System;
using System.IO;

namespace Kryptos4
{
    class ProblemCommandFactory
    {
        private string[] keywords;
        private int nextKeywordIndex = 0;
        private string lastKeyword = string.Empty;
        
        public ProblemCommandFactory()
        {
            keywords = File.ReadAllLines(Config.dictionaryFile);
            for(var i = 0; i < keywords.Length; i++)
            {
                keywords[i] = keywords[i].Replace("-", "").ToUpper();
            }
        }

        public ProblemCommand GetNextCommand(string partiallyDecryptedText = "")
        {            
            var command = new ProblemCommand
            {
                encryptedText = partiallyDecryptedText == string.Empty ? Config.encryptedText : partiallyDecryptedText,
                keyword = keywords[nextKeywordIndex]
            };
            nextKeywordIndex++;
            return command;
        }

        public string GetLastKeyword()
        {
            if (lastKeyword == string.Empty)
            {
                lastKeyword = keywords[keywords.Length - 1];
            }
            return lastKeyword;
        }
    }
}