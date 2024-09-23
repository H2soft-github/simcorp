using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsCounterApp.WordsSources;

namespace WordsCounterTests
{
    public class FilesValidatorTests
    {
        private string filesDir = Path.Combine(AppContext.BaseDirectory, "ExampleFiles");

        [Fact]
        public void ValidateValidFilePathsNoException()
        {

            var validFiles = new List<string>
            {
                Path.Combine(filesDir, "file1.txt"),
                Path.Combine(filesDir, "file2.txt"),
            };
            var validator = new FilesValidator(validFiles);
            validator.Validate();
        }

        [Fact]
        public void ValidateFileDoesNotExistThrowsFileNotFoundException()
        {
            var invalidFiles = new List<string>
            {
                Path.Combine(filesDir, "file_not_exist.txt")
            };
            var validator = new FilesValidator(invalidFiles);
            var exception = Assert.Throws<FileNotFoundException>(() => validator.Validate());
            Assert.Contains("does not exist", exception.Message);
        }

        [Fact]
        public void ValidateDuplicateFilesThrowsException()
        {
            var filesWithDuplicate = new List<string>
            {
                Path.Combine(filesDir, "file1.txt"),
                Path.Combine(filesDir, "../ExampleFiles/file1.txt"),
            };
            var validator = new FilesValidator(filesWithDuplicate);
            var exception = Assert.Throws<ArgumentException>(() => validator.Validate());
            Assert.Contains("is duplicated", exception.Message);
        }

        [Fact]
        public void ValidateNullFilePathsThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new FilesValidator(null).Validate());
            Assert.Equal("FilesPaths", exception.ParamName);
        }
    }
}
