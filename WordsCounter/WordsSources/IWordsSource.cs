using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCounterApp.WordsSources
{
    public interface IWordsSource
    {
        Task<IEnumerable<string>> LoadWords();
    }
}
