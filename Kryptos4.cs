using System;

namespace Kryptos4
{
    class Kryptos4
    {
        static void Main(string[] args)
        {
            var factory = new DecryptCommandFactory();
            var handler = new DecryptCommandHandler();
            var scorer = new SolutionScorer();
            var fileWriter = new SolutionFileWriter(); 
            
            var command = factory.GetNextCommand();
            while (command != null) 
            {
                var result = handler.Solve(command);
                scorer.Score(result);

                if (result.score >= 30)
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
