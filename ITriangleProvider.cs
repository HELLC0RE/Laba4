using System.Collections.Generic;

namespace Лаба_4
{    
        public interface ITriangleProvider

        {
            Triangle GetById(long id);

            List<Triangle> GetAll();

            void Save(Triangle triangle);

        }
}