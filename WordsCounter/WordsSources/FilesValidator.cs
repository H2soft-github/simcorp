using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCounterApp.WordsSources
{
    public class FilesValidator(List<string> filesPaths)
    {
        public List<string> FilesPaths => filesPaths;

        public void Validate()
        {
            if (FilesPaths == null || filesPaths.Count == 0)
            {
                throw new ArgumentNullException(nameof(FilesPaths));
            }
            var paths = new HashSet<string>();
            foreach (var file in filesPaths)
            {
                var fullPath = Path.GetFullPath(file);
                if (!File.Exists(fullPath))
                {
                    throw new FileNotFoundException($"The file {fullPath} does not exist.");
                }

                if (!paths.Add(fullPath))
                {
                    throw new ArgumentException($"The file {fullPath} is duplicated.");
                }
            }
        }
    }
}
