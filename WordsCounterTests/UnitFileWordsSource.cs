using WordsCounterApp.WordsSources;

namespace WordsCounterTests
{
    public class UnitFileWordsSource
    {
        private string filesDir = Path.Combine(AppContext.BaseDirectory, "ExampleFiles");

        [Fact]
        public async Task NoFileTest()
        {
            await Assert.ThrowsAsync<Exception>(() => new FileWordsSource("no exits").LoadWords());
        }

        [Fact]
        public async Task EmptyFileTest()
        {
            var result = await new FileWordsSource(Path.Combine(filesDir, "file0.txt")).LoadWords();
            Assert.Empty(result);
        }

        [Fact]
        public async Task Example1ReadingTest()
        {
            var words = new string[] { "go", "do", "that", "thing", "that", "you", "do", "so", "well" };
            var result = await new FileWordsSource(Path.Combine(filesDir, "file1.txt")).LoadWords();
            Assert.Equal(words, result);
        }

        [Fact]
        public async Task Example2ReadingTest()
        {
            var words = new string[] { "i", "play", "football", "well" };
            var result = await new FileWordsSource(Path.Combine(filesDir, "file2.txt")).LoadWords();
            Assert.Equal(words, result);
        }

        [Fact]
        public async Task WhiteCharsTest()
        {
            var words = new string[] { "i", "play", "football", "well" };
            var result = await new FileWordsSource(Path.Combine(filesDir, "file3.txt")).LoadWords();
            Assert.Equal(words, result);
        }
    }
}