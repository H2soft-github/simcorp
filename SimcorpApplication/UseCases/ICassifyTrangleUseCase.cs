using SimcorpCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimcorpApplication.UseCases
{
    public interface IClassifyTriangleUseCase
    {
        string ClassifyTriangle(decimal sideA, decimal sideB, decimal sideC);
    }
}
