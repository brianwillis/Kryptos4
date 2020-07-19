using System;
using System.IO;
using System.Reflection;

namespace Kryptos4
{
    class SolutionFileWriter
    {
        private string outputFolder;

        public SolutionFileWriter() {
            outputFolder = Config.outputFolder;
            
            if (outputFolder == String.Empty)
            {
                outputFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().GetName().CodeBase) + Path.DirectorySeparatorChar + "output";

                //On macOS Path.GetDirectoryName() prepends "file:" to the result. This needs to be removed.
                if (outputFolder.Substring(0, 5) == "file:")
                {
                    outputFolder = outputFolder.Substring(5);
                }

                Console.WriteLine($"No output folder specified in config. Defaulting to {outputFolder}\n");
            }

            if (!Directory.Exists(outputFolder))
            {
                try 
                {
                    Directory.CreateDirectory(outputFolder);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Environment.Exit(-1);
                }
            }
        }

        public void Write(ProblemCommand problem, Solution solution)
        {
            try 
            {
                var fileName = $"{solution.score} - {problem.keyword}";
                
                var report =
                    $"Keyword: {problem.keyword}\n" +
                    $"Alphabet: {problem.alphabet}\n" +
                    "Lookup table:\n";
                
                for (var i = 0; i < problem.alphabet.Length; i++)
                {
                    for (var j = 0; j < problem.alphabet.Length; j++) {
                        report += problem.lookupTable[i,j];
                    }
                    report += '\n';
                }

                report += '\n';

                report += 
                    $"Source text: {problem.encryptedText}\n" +
                    $"Result text: {solution.decryptedText}\n";

                report += '\n';

                report += 
                    $"Score: {solution.score}\n" +
                    "Narrative: ";
                
                if (solution.narrative.Count == 1)
                {
                    report += solution.narrative[0] + '\n';
                }
                else 
                {
                    report += "\n";
                    foreach (var narration in solution.narrative)
                    {
                        report += $"- {narration}\n";
                    }
                }

                System.IO.File.WriteAllText($"{outputFolder}{Path.DirectorySeparatorChar}{fileName}.txt", report);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}