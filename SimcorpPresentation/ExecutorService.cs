using SimcorpApplication.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpPresentation
{
    public class ExecutorService : IExecutorService
    {
        public void ClassifyTriangle()
        {
            var sides = GetTriangleSidesFromCMD();
            var triangelType = ((IClassifyTriangleUseCase) new ClassifyTriangleUseCase()).ClassifyTriangle(sides[0], sides[1], sides[2]);
            PrintTriangleType(triangelType);
        }

        public void ShowAppInfo()
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

              Triangle type detector v. 1.0.0.1
              2024
            ");
        }

        private decimal[] GetTriangleSidesFromCMD()
        {
            var commandLineArgs = Environment.GetCommandLineArgs();
            var args = commandLineArgs.Skip(1).ToArray();
            var sides = new ArgsToDecimals(args, 3).ToDecimals();
            return sides;
        }

        private void PrintTriangleType(string triangleType)
        {
            Console.WriteLine($"This is a {triangleType} triangle.");
        }
    }
}
