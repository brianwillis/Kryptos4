using System;
using System.Diagnostics;

namespace Kryptos4
{
    class Kryptos4
    {
        static void Main(string[] args)
        {
            Config.BuildLookupTable();

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
            var handler = new ProblemCommandHandler();
            var scorer = new SolutionScorer();
            var fileWriter = new SolutionFileWriter();
            
            var outerFactory = new ProblemCommandFactory();
            var outerCommand = outerFactory.GetNextCommand();
            while (outerCommand.keyword != outerFactory.GetLastKeyword())
            {
                Console.WriteLine(outerCommand.keyword);

                var outerResult = handler.Solve(outerCommand);

                var innerFactory = new ProblemCommandFactory();
                var innerCommand = innerFactory.GetNextCommand(outerResult.decryptedText);
                while (innerCommand.keyword != innerFactory.GetLastKeyword())
                {
                    var innerResult = handler.Solve(innerCommand);

                    scorer.Score(innerCommand, innerResult);

                    if (innerResult.score >= Config.minimumScoreToReport)
                    {
                        fileWriter.Write(outerCommand, innerCommand, innerResult);

                        if (innerResult.score == 100)
                        {
                            //We've found the correct solution, so we can stop.
                            return;
                        }
                    }

                    innerCommand = innerFactory.GetNextCommand(outerResult.decryptedText);
                }
                outerCommand = outerFactory.GetNextCommand();
            }
        }
    }
}
