using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_4
{
        public class TriangleValidateService : ITriangleValidateService

        {

            private readonly TriangleProvider triangleProvider;

            private readonly TriangleService triangleService;
            public NpgsqlConnection Connection;

        public TriangleValidateService(TriangleProvider triangleProvider, TriangleService triangleService)
            {
            this.triangleProvider = triangleProvider;
            this.triangleService = triangleService;
            }

        public bool IsAllValid()
        {           
                List<Triangle> triangles = triangleProvider.GetAll();
                bool isValid = true;
                foreach (var triangle in triangles)
                {
                if (triangleService.IsValidTriangle(triangle.A, triangle.B, triangle.C) == true)
                {
                    triangle.IsValid = true; // если треугольник прошел проверку isValid будет true                   
                }
                else
                {
                    triangle.IsValid = false; // если треугольник не прошел проверку isValid false
                    isValid = false;
                    continue;
                }
                if (triangleService.GetArea(triangle.A, triangle.B, triangle.C) == triangle.Area)
                {
                    triangle.IsValid = true;
                }
                else
                {
                    triangle.IsValid = false; // если треугольник не прошел проверку isValid false
                    isValid = false;
                    continue;
                }

                if (triangleService.GetType(triangle.A, triangle.B, triangle.C) == triangle.Type)
                {
                    triangle.IsValid = true;
                }
                else
                {
                    triangle.IsValid = false; // если треугольник не прошел проверку isValid false
                    isValid = false;
                    continue;
                }               
                }
            return isValid;
        }

        public bool IsValid(long id)
        {
            Triangle triangle = triangleProvider.GetById(id);
            if (triangleService.IsValidTriangle(triangle.A, triangle.B, triangle.C) == true)
            {
                triangle.IsValid = true;
            }
            if (triangleService.GetArea(triangle.A, triangle.B, triangle.C) == triangle.Area)
            {
                triangle.IsValid = true;
            }
            if (triangleService.GetType(triangle.A, triangle.B, triangle.C) == triangle.Type)
            {
                triangle.IsValid = true;
            }
            return triangle.IsValid;
        }
    }
}
