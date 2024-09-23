using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsCounterApp.WordsSources;
using App = WordsCounterApp.WordsCouterLogic;

namespace WordsCounterTests
{
    public class WordsCounter
    {
        [Fact]
        public async Task CountShouldReturnCorrectWordCountsFromMultipleSources()
        {
            var wordsSourceMock1 = new Mock<IWordsSource>();
            wordsSourceMock1.Setup(x => x.LoadWords())
                .ReturnsAsync(new List<string> { "apple", "banana", "apple" });

            var wordsSourceMock2 = new Mock<IWordsSource>();
            wordsSourceMock2.Setup(x => x.LoadWords())
                .ReturnsAsync(new List<string> { "banana", "orange" });

            var sources = new List<IWordsSource> { wordsSourceMock1.Object, wordsSourceMock2.Object };
            var wordsCounter = new App.WordsCounter(sources);
            var result = await wordsCounter.Count();
            Assert.Collection(result,
                item => Assert.Equal(("apple", 2), item),
                item => Assert.Equal(("banana", 2), item),
                item => Assert.Equal(("orange", 1), item)
            );
        }

        [Fact]
        public async Task CountShouldReturnEmptyListWhenNoWordsInSources()
        {
            var wordsSourceMock = new Mock<IWordsSource>();
            wordsSourceMock.Setup(x => x.LoadWords())
                .ReturnsAsync(new List<string>());
            var sources = new List<IWordsSource> { wordsSourceMock.Object };
            var wordsCounter = new App.WordsCounter(sources);
            var result = await wordsCounter.Count();
            Assert.Empty(result);
        }

        [Fact]
        public async Task CountShouldHandleEmptySources()
        {
            var sources = new List<IWordsSource>();
            var wordsCounter = new App.WordsCounter(sources);
            var result = await wordsCounter.Count();
            Assert.Empty(result);
        }

        [Fact]
        public async Task CountShouldHandleNullWordsInSources()
        {
            var wordsSourceMock = new Mock<IWordsSource>();
            wordsSourceMock.Setup(x => x.LoadWords())
                .ReturnsAsync(new List<string> { null, "apple", null });

            var sources = new List<IWordsSource> { wordsSourceMock.Object };
            var wordsCounter = new App.WordsCounter(sources);
            var result = await wordsCounter.Count();
            Assert.Collection(result,
                item => Assert.Equal(("apple", 1), item)
            );
        }
    }
}
