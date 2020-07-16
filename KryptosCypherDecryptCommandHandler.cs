namespace Kryptos4
{
    class KryptosCypherDecryptCommandHandler
    {
        public DecryptCommandResult Solve(DecryptCommand command)
        {
            var result = new DecryptCommandResult();
            var keywordIndex = 0;

            foreach(var chr in command.sourceText.ToCharArray())
            {
                // We want to skip puctuation characters.
                if (!command.alphabet.Contains(chr)) 
                {
                    result.solution += chr;
                    continue;
                }

                var keywordLetter = command.keyword.Substring(keywordIndex, 1).ToCharArray()[0];
                var row = 0;

                for (var i = 0; i < command.alphabet.Length; i++)
                {
                    if (command.lookupTable[i, 0] == keywordLetter)
                    {
                        row = i;
                        break;
                    }
                }

                for (var i = 0; i < command.alphabet.Length; i++) 
                {
                    if (command.lookupTable[row, i] == chr)
                    {
                        result.solution += command.lookupTable[0, i];
                        break;
                    }
                }

                keywordIndex++;
                if (keywordIndex >= command.keyword.Length) {
                    keywordIndex = 0;
                }
            }

            return result;
        }
    }
}