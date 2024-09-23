using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsCounterApp.WordsCouterLogic;
using WordsCounterApp.WordsSources;

namespace WordsCounterApp
{
    public static class Executor
    {
        public static void ShowAppInfo()
        {

            Console.WriteLine(@"                                                                                                                                                                   
                                        
              @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ 
              @@ .............................. /@@ 
              @@ @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,/@@ 
              @@ @@@@                        @@,/@@ 
              @@ @@@@ &@@@@@@@@@@@@@@@@@@@@@ @@,/@@ 
              @@ @@@@ &@@@%              @@@ @@,/@@ 
              @@ @@@@ &@@@% @@@@@@@@@@@@ @@@ @@,/@@ 
              @@ @@@@ &@@@% @@@@%%%%%@@@ @@@ @@,/@@ 
              @@ @@@@ &@@@% @@@@     @@@ @@@ @@,/@@ 
              @@ @@@@ &@@@% @@@@     @@@ @@@ @@,/@@ 
              @@ @@@@ &@@@% @@@@@@@@@@@@ @@@ @@,/@@ 
              @@ @@@@ &@@@@@@@@@@@@@@@@@@@@@ @@,/@@ 
              @@ @@@@(((((((((((((((((((((((/@@,/@@ 
              @@ //////////////////////////////./@@ 
              @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

              SimCorp

              Words Counter v. 1.0.0.1
              2024
            ");
        }

        public static List<string> PrepareFilesPaths()
        {
            var commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length == 1)
            {
                Console.WriteLine("No files were provided in the parameters.");
                Console.WriteLine(@"Example: c:\\WordsCounterApp.exe ""c:\\dir\\file1.txt"" file2.txt");
            }
            var filesPaths = commandLineArgs.Skip(1).ToList();
            Console.WriteLine("Files:");
            filesPaths.ToList().ForEach(x => Console.WriteLine(x));
            return filesPaths;
        }

        public static async Task<IEnumerable<(string word, int count)>> Process(List<string> filesPaths)
        {
            var wordsSources = filesPaths.Select(x => new FileWordsSource(x));
            var wordsCounter = new WordsCounter(wordsSources);
            var stats = await wordsCounter.Count();
            return stats;
        }

        public static void DisplaResult(IEnumerable<(string word, int count)> stats)
        {
            stats.ToList().ForEach(x => Console.WriteLine($"{x.count}: {x.word}"));
        }
    }

}
