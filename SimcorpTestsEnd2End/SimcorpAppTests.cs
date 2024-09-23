using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpTestsEnd2End
{
    public class SimcorpAppTests
    {
        [Fact]
        public void TriangeEndToEndTest()
        {
            string fileName = Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\SimcorpPresentation\bin\\Debug\net8.0\SimcorpPresentation.exe");
            string arguments = "5.1 5.1 5.1";
            var startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string[] lines = output.Split(Environment.NewLine);
                Assert.Equal("This is a Equilateral triangle.", lines[lines.Length - 2]);
            }
        }
    }
}
