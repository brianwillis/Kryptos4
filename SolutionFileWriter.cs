using System;
using System.IO;

namespace Kryptos4
{
    class SolutionFileWriter
    {
        public void Write(DecryptCommand command, DecryptCommandResult result)
        {
            try 
            {
                var fileName = $"{result.score} - {command.keyword}";
                
                var report =
                    $"Keyword: {command.keyword}\n" +
                    $"Alphabet: {command.alphabet}\n" +
                    "Lookup table:\n";
                
                for (var i = 0; i < command.alphabet.Length; i++)
                {
                    for (var j = 0; j < command.alphabet.Length; j++) {
                        report += command.lookupTable[i,j];
                    }
                    report += '\n';
                }

                report += '\n';

                report += 
                    $"Source text: {command.sourceText}\n" +
                    $"Result text: {result.solution}\n";

                report += '\n';

                report += 
                    $"Score: {result.score}\n" +
                    "Narrative: ";
                
                if (result.narrative.Count == 1)
                {
                    report += result.narrative[0] + '\n';
                }
                else 
                {
                    report += "\n";
                    foreach (var narration in result.narrative)
                    {
                        report += $"- {narration}\n";
                    }
                }

                report += "\n";

                System.IO.File.WriteAllText(@"/Users/Brian/Development/Kryptos4/output/" + fileName + ".txt", report);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}