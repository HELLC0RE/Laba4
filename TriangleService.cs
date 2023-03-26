using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_4
{
    public class TriangleService : ITriangleService
    {
        
        public NpgsqlConnection Connection;
        public TriangleProvider triangleProvider;
        public TriangleService(NpgsqlConnection connection)
        {
            Connection = connection;
        }
        public bool IsValidTriangle(double a, double b, double c)
        {      
               var command = new NpgsqlCommand("SELECT * FROM triangles where \"SideA\"=@a and \"SideB\"=@b and \"SideC\"=@c LIMIT 1", Connection);
                command.Parameters.AddWithValue("@a", a);
                command.Parameters.AddWithValue("@b", b);
                command.Parameters.AddWithValue("@c", c);
                var reader = command.ExecuteReader();

            if (reader.Read())
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }                                                                      
        }

        public TriangleType GetType(double a, double b, double c)
        {
            var command = new NpgsqlCommand("SELECT * FROM triangles where \"SideA\"=@a and \"SideB\"=@b and \"SideC\"=@c LIMIT 1", Connection);
            command.Parameters.AddWithValue("@a", a);
            command.Parameters.AddWithValue("@b", b);
            command.Parameters.AddWithValue("@c", c);
            var reader = command.ExecuteReader();           
                if (reader.Read())
                {
                    string s = reader.GetString(4);
                    TriangleType typeFromDB = (TriangleType)Enum.Parse(typeof(TriangleType), s);
                    reader.Close();
                    return typeFromDB;
                }
                else
                {
                    reader.Close();
                    return 0;
                }                                                            
        }


        public double GetArea(double a, double b, double c)
        {
            var command = new NpgsqlCommand("SELECT * FROM triangles where \"SideA\"=@a and \"SideB\"=@b and \"SideC\"=@c LIMIT 1", Connection);
            command.Parameters.AddWithValue("@a", a);
            command.Parameters.AddWithValue("@b", b);
            command.Parameters.AddWithValue("@c", c);
            var reader = command.ExecuteReader();           
                if (reader.Read())
                {
                    double s = reader.GetDouble(6);
                    reader.Close();
                    return s;
                }
                else
                {
                    reader.Close();
                    return -1;
                }                     
        }

        public void Save(long id, double a, double b, double c, TriangleType type, bool isValid, double area)
        {                                        
                try
                {
                    var command = new NpgsqlCommand("INSERT INTO triangles (\"ID\", \"SideA\", \"SideB\", \"SideC\", \"Type\", \"isValid\", \"Area\") VALUES (@id, @a, @b, @c, @type, @isValid, @area)", Connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@a", a);
                    command.Parameters.AddWithValue("@b", b);
                    command.Parameters.AddWithValue("@c", c);
                    command.Parameters.AddWithValue("@type", type.ToString());
                    command.Parameters.AddWithValue("@isValid", isValid);
                    command.Parameters.AddWithValue("@area", area);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Ошибка при сохранении: {ex.Message}");
                }
        }       
    }
}
