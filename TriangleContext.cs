using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_4
{
    class TriangleContext : DbContext
    {
        public TriangleContext() : base ("DBConnection")
        {

        }
        public DbSet <Triangle> Triangles { get; set; }
    }
    
    
}
