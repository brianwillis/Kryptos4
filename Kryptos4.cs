using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            Solve().Wait();
            watch.Stop();
            var finish = DateTime.Now;
            
            Console.WriteLine($"Started at: {start}");
            Console.WriteLine($"Finished at: {finish}");
            Console.WriteLine($"Elapsed time: {watch.Elapsed.TotalSeconds:F0} seconds");           
        }

        private static async Task Solve()
        {
            var handler = new ProblemCommandHandler();
            
            var outerFactory = new ProblemCommandFactory();
            var outerCommand = outerFactory.GetNextCommand();
            while (outerCommand.keyword != outerFactory.GetLastKeyword())
            {
                Console.WriteLine(outerCommand.keyword);

                var tasks = new List<Task<Solution>>();
                var outerResult = await handler.Solve(outerCommand);
                var innerFactory = new ProblemCommandFactory();
                ProblemCommand innerCommand;

                do {   
                    innerCommand = innerFactory.GetNextCommand(outerResult.decryptedText);
                    tasks.Add(handler.Solve(outerCommand, innerCommand));                    
                } while (innerCommand.keyword != innerFactory.GetLastKeyword());

                Task.WaitAll(tasks.ToArray());

                outerCommand = outerFactory.GetNextCommand();
            }
        }
    }
}
