using System;
using System.Diagnostics;

namespace Kryptos4
{
    class Kryptos4
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            var start = DateTime.Now;
            watch.Start();
            Solve();
            watch.Stop();
            var finish = DateTime.Now;
            Console.WriteLine($"Started at: {start}");
            Console.WriteLine($"Finished at: {finish}");
            Console.WriteLine($"Elapsed time: {watch.Elapsed.TotalSeconds:F0} seconds");           
        }

        private static void Solve()
        {
            var factory = new ProblemCommandFactory();
            var handler = new ProblemCommandHandler();
            var scorer = new SolutionScorer();
            var fileWriter = new SolutionFileWriter();

            double totalCommands = 0;
            for (int i = 1; i <= Config.lastKeyword.Length; i++)
            {
                totalCommands += Math.Pow(26, i) * Config.problemDefinitions.Count;
            }
            var commandsChecked = 0;
            var percentComplete = 0;
            
            var command = factory.GetNextCommand();
            while (command.keyword != Config.lastKeyword) 
            {
                var result = handler.Solve(command);
                scorer.Score(command, result);

                if (result.score >= Config.minimumScoreToReport)
                {
                    fileWriter.Write(command, result);

                    if (result.score == 100)
                    {
                        //We've found the correct solution, so we can stop.
                        return;
                    }
                }

                commandsChecked++;
                if (percentComplete != Convert.ToInt32(commandsChecked / totalCommands * 100)) 
                {
                    percentComplete = Convert.ToInt32(commandsChecked / totalCommands * 100);
                    Console.WriteLine($"{percentComplete}% complete at {DateTime.Now}");
                    if (percentComplete == 100)
                    {
                        Console.WriteLine(string.Empty);
                    }
                }

                command = factory.GetNextCommand();
            }
        }
    }
}
