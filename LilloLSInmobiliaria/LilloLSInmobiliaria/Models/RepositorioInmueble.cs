using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
    public class RepositorioInmueble : RepositorioBase, IRepositorioInmueble {

        public RepositorioInmueble(IConfiguration config): base(config)
        {

        }


        public int Alta(Inmueble p)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $" INSERT INTO inmuebles (PropietarioId, Direccion, CantAmbientes, Uso, Tipo, Precio, Estado) " +
                    $" VALUES (@propietarioid, @direccion, @cantambientes, @uso, @tipo, @precio, @estado);" +
                    $" SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@propietarioid", p.PropietarioId);
                    command.Parameters.AddWithValue("@direccion", p.Direccion);
                    command.Parameters.AddWithValue("@cantambientes", p.CantAmbientes);
                    command.Parameters.AddWithValue("@uso", p.Uso);
                    command.Parameters.AddWithValue("@tipo", p.Tipo);
                    command.Parameters.AddWithValue("@precio", p.Precio);
                    command.Parameters.AddWithValue("@estado", p.Estado);
                    connection.Open();
                    res = Convert.ToInt32(command.ExecuteScalar());
                    p.Id = res;
                    connection.Close();
                }
            }
            return res;
        }

        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM inmuebles WHERE Id = {id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public IList<Inmueble> BuscarPorPropietario(int idPropietario)
        {
            List<Inmueble> res = new List<Inmueble>();
            Inmueble inm = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT Id, PropietarioId, Direccion, Tipo, Precio, Estado" +
                    $" FROM inmuebles" +
                    $" WHERE Id=@idPropietario AND Disponible = 1";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@idPropietario", SqlDbType.Int).Value = idPropietario;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        inm = new Inmueble
                        {
                            Id = reader.GetInt32(0),
                            Prop = new Propietario
                            {
                                Id = reader.GetInt32(1),
                                Nombre = reader.GetString(2),
                                Apellido = reader.GetString(3),
                            },
                            Direccion = reader.GetString(4),
                            Tipo = reader.GetString(5),
                            Precio = reader.GetDecimal(6),
                            Estado = reader.GetBoolean(7),

                        };
                        res.Add(inm);
                    }
                    connection.Close();
                }
            }
            return res;
        }

        public int Modificacion(Inmueble p)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE inmuebles SET " +
                    $" PropietarioId=@propietarioid, Direccion=@direccion, CantAmbientes=@cantambientes, " + 
                    "Uso=@uso, Tipo=@tipo, Precio=@precio, Estado=@estado " +
                    $" WHERE Id = @id ";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@propietarioid", p.PropietarioId);
                    command.Parameters.AddWithValue("@direccion", p.Direccion);
                    command.Parameters.AddWithValue("@cantambientes", p.CantAmbientes);
                    command.Parameters.AddWithValue("@uso", p.Uso);
                    command.Parameters.AddWithValue("@tipo", p.Tipo);
                    command.Parameters.AddWithValue("@precio", p.Precio);
                    command.Parameters.AddWithValue("@estado", p.Estado);
                    command.Parameters.AddWithValue("@id", p.Id);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public Inmueble ObtenerPorId(int id)
        {
            Inmueble p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $" SELECT i.Id, Direccion, CantAmbientes, Uso, Tipo, Precio, Estado, PropietarioId, " +
                    "p.Nombre, p.Apellido " +
                    " FROM Inmuebles i INNER JOIN Propietarios p ON i.PropietarioId = p.Id " +
                    $" WHERE i.Id=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        p = new Inmueble
                        {
                            Id = reader.GetInt32(0),
                            Direccion = reader.GetString(1),
                            CantAmbientes = reader.GetInt32(2),
                            Uso = reader.GetString(3),
                            Tipo = reader.GetString(4),
                            Precio = reader.GetDecimal(5),
                            Estado = reader.GetBoolean(6),
                            PropietarioId = reader.GetInt32(7),
                            Prop = new Propietario
                            {
                                Id = reader.GetInt32(7),
                                Nombre = reader.GetString(8),
                                Apellido = reader.GetString(9)
                            }

                        };
                        return p;
                    }
                    connection.Close();
                }
            }
            return p;
        }

        public IList<Inmueble> ObtenerTodos()
        {
            IList<Inmueble> res = new List<Inmueble>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String sql = $"SELECT i.Id, Direccion, CantAmbientes, Uso, Tipo, Precio, Estado, PropietarioId, " +
                    " p.Nombre, p.Apellido " +
                    " FROM inmuebles i INNER JOIN propietarios p ON i.PropietarioId = p.Id ";


                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Inmueble p = new Inmueble
                        {
                            Id = reader.GetInt32(0),
                            Direccion = reader.GetString(1),
                            CantAmbientes = reader.GetInt32(2),
                            Uso = reader.GetString(3),
                            Tipo = reader.GetString(4),
                            Precio = reader.GetDecimal(5),
                            Estado = reader.GetBoolean(6),
                            PropietarioId = reader.GetInt32(7),
                            Prop = new Propietario
                            {
                                Id = reader.GetInt32(7),
                                Nombre = reader.GetString(8),
                                Apellido = reader.GetString(9)
                            }

                        };
                        res.Add(p);
                    }
                    connection.Close();
                }
            }
            return res;
        }

    }
}
