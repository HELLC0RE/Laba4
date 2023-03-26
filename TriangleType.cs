using Npgsql;
using System;

namespace Лаба_4
{
    [Flags]
    public enum TriangleType
    {
        Oxygon = 1,
        Obtuse = 2,
        Right = 4,
        Scalene = 8,
        Isosceles = 16,
        Equilateral = 32,
        Equilateral_Obtuse = Equilateral | Obtuse,
        Equilateral_Right = Equilateral | Right,
        Equilateral_Oxygon = Equilateral | Oxygon,
        Isosceles_Obtuse = Isosceles | Obtuse,
        Isosceles_Right = Isosceles | Right,
        Isosceles_Oxygon = Isosceles | Oxygon,
        Scalene_Obtuse = Scalene | Obtuse,
        Scalene_Right = Scalene | Right,
        Scalene_Oxygon = Scalene | Oxygon
    }
}