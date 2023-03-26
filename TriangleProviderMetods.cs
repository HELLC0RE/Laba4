using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лаба_4;

namespace Лаба_4
{
    public class TriangleProvider : ITriangleProvider
    {
        public List<Triangle> triangles = new List<Triangle>();
        public Triangle GetById(long id)
        {
            if (id > 0)
            {
                return triangles.FirstOrDefault(t => t.Id == id);
            }
            return null;
        }
        public List<Triangle> GetAll()
        {
            return triangles;
        }

        public void Save(Triangle triangle)
        {
            triangles.Add(triangle);
        }
    }
}
