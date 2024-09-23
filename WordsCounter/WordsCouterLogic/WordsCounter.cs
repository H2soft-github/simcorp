using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsCounterApp.WordsSources;

namespace WordsCounterApp.WordsCouterLogic
{
    public class WordsCounter(IEnumerable<IWordsSource> wordsSources)
    {
        public IEnumerable<IWordsSource> Sources => wordsSources;

        public async Task<IEnumerable<(string word, int count)>> Count()
        {
            var sorucesResult = await Task.WhenAll(wordsSources.Select(x => x.LoadWords()).ToList());
            var result = sorucesResult.SelectMany(x => x)
                .Where(x => !string.IsNullOrEmpty(x))
                .GroupBy(x => x)
                .Select(x => (word: x.Key, count: x.Count()))
                .ToList();
            return result;
        }
    }
}
