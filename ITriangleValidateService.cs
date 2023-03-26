using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_4
{
        public interface ITriangleValidateService

        {
            bool IsAllValid();

            bool IsValid(long id);
        }  
}
