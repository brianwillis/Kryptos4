using System;
using System.Collections.Generic;

namespace Kryptos4
{
    class ProblemCommandFactory
    {
        private List<ProblemDefinition> defaultProblemDefinitions;
        private int nextProblemDefinitionIndex = 0;
        private string defaultAlphabet;
        private string nextKeyword;
        private char[,] defaultLookupTable;
        
        public ProblemCommandFactory(List<ProblemDefinition> defaultProblemDefinitions, string defaultAlphabet, string nextKeyword)
        {
            this.defaultProblemDefinitions = defaultProblemDefinitions;
            this.defaultAlphabet = defaultAlphabet;
            this.nextKeyword = nextKeyword;
            BuildLookupTable();
        }

        public ProblemCommandFactory()
        {
            defaultProblemDefinitions = Config.problemDefinitions;
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
                    if (index >= defaultAlphabet.Length)
                    {
                        index -= defaultAlphabet.Length;
                    }
                    var letter = defaultAlphabet.Substring(index, 1).ToCharArray()[0];
                    defaultLookupTable[i,j] = letter;
                }
            }
        }

        public ProblemCommand GetNextCommand()
        {            
            var command = new ProblemCommand
            {
                encryptedText = defaultProblemDefinitions[nextProblemDefinitionIndex].encryptedText,
                keyword = nextKeyword,
                alphabet = defaultAlphabet,                
                lookupTable = defaultLookupTable,
                solutionHints = defaultProblemDefinitions[nextProblemDefinitionIndex].solutionHints
            };

            nextProblemDefinitionIndex++;
            if (nextProblemDefinitionIndex == defaultProblemDefinitions.Count)
            {
                nextProblemDefinitionIndex = 0;
                nextKeyword = GenerateNextKeyword(nextKeyword);
            }            

            return command;
        }

        private string GenerateNextKeyword(string oldKeyword)
        {
            if (oldKeyword == string.Empty)
            {
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