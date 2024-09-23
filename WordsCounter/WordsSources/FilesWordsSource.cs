using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCounterApp.WordsSources
{
    public class FileWordsSource : IWordsSource
    {
        private readonly char[] SEPARATORS  = new[] { ' ', '\t', '\n', '\r' };
        public string FilePath { get; }

        public FileWordsSource(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }


        public async Task<IEnumerable<string>> LoadWords()
        {
            var words = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        var lineWords = line.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                        lineWords = lineWords.Select(x => x.ToLower()).ToArray();
                        words.AddRange(lineWords);
                    }
                }
                return words;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading file {FilePath}: {ex.Message}", ex);
            }
        }
    }
}
