using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_4
{
    public interface ITriangleService

    {

        bool IsValidTriangle(double a, double b, double c);

        TriangleType GetType(double a, double b, double c);

        double GetArea(double a, double b, double c);

        void Save(long id, double a, double b, double c, TriangleType type, bool isValid, double area);

    }
}
