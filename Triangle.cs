using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Лаба_4
{
    
    public class Triangle
    {
        public long Id { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public TriangleType Type { get; set; }
        public bool IsValid { get; set; }
        public double Area { get; set; }

        public Triangle(long id, double a, double b, double c, TriangleType type, bool isValid, double area)
        {
            Id = id;
            A = a;
            B = b;
            C = c;
            Type = type;
            IsValid = isValid;
            Area = area;
        }       
    }
}

   