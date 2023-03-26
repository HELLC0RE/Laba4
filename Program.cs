using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Лаба_4
{
    internal class Program
    {

        static void Main(string[] args)
        {
            using (TriangleContext db = new TriangleContext())
            {
                // создаем два объекта Triangle
                Triangle triangle1 = new Triangle(1, 2, 2, 2, TriangleType.Oxygon | TriangleType.Equilateral, false, 2);
                Triangle triangle2 = new Triangle(1, 2, 2, 2, TriangleType.Oxygon | TriangleType.Equilateral, false, 2);

                // добавляем их в бд
                db.Triangles.Add(triangle1);
                db.Triangles.Add(triangle2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var triangles = db.Triangles;
                Console.WriteLine("Список объектов:");
                foreach (Triangle t in triangles)
                {
                    Console.WriteLine("{0}.{1} - {2}", t.Id, t.A, t.B, t.C);
                }
            }
            Console.Read();
        }

    }
}