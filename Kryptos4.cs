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

                command = factory.GetNextCommand();
            }
        }
    }
}
