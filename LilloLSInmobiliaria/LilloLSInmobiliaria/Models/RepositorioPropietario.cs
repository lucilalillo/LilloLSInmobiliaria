using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
    public class RepositorioPropietario
    {
        string connectionString = "Server = (localdb)\\MSSQLLocalDB;Database=LilloLSInmobiliaria;Trusted_Connection=True;MultipleActiveResultSets=true";

        public RepositorioPropietario()
        {

        }

        public int Alta(Propietario p) {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString)) {

				string sql = $"INSERT INTO propietarios (Nombre, Apellido, Dni, Telefono, Mail, ClaveProp) " +
					$"VALUES (@nombre, @apellido, @dni, @telefono, @mail, @claveprop);" +
					$"SELECT SCOPE_IDENTITY();";

				using (SqlCommand command = new SqlCommand(sql, conn)) { 
				
					command.Parameters.AddWithValue("@nombre", p.Nombre);
					command.Parameters.AddWithValue("@apellido", p.Apellido);
					command.Parameters.AddWithValue("@dni", p.Dni);
					command.Parameters.AddWithValue("@telefono", p.Telefono);
					command.Parameters.AddWithValue("@mail", p.Mail);
					command.Parameters.AddWithValue("@claveprop", p.ClaveProp);
					conn.Open();
					res = Convert.ToInt32(command.ExecuteScalar());
					p.Id = res;
					conn.Close();
				}
			}
			return res;
		}

		public int Baja(int id)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"DELETE FROM propietarios WHERE Id = {id}";
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

		public int Modificacion(Propietario p)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"UPDATE propietarios SET " +
					$"Nombre=@nombre, Apellido=@apellido, Dni=@dni, Telefono=@telefono, Mail=@mail " +
					$"WHERE Id = @id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@nombre", p.Nombre);
					command.Parameters.AddWithValue("@apellido", p.Apellido);
					command.Parameters.AddWithValue("@dni", p.Dni);
					command.Parameters.AddWithValue("@telefono", p.Telefono);
					command.Parameters.AddWithValue("@mail", p.Mail);
					command.Parameters.AddWithValue("@id", p.Id);
					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}

		public IList<Propietario> ObtenerTodos()
		{
			IList<Propietario> res = new List<Propietario>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT Id, Nombre, Apellido, Dni, Telefono, Mail" +
					$" FROM propietarios" +
					$" ORDER BY Apellido, Nombre";/* +
					$" OFFSET 0 ROWS " +
					$" FETCH NEXT 10 ROWS ONLY ";*/
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Propietario p = new Propietario
						{
							Id = reader.GetInt32(0),
							Nombre = (string)reader[nameof(Propietario.Nombre)],
							Apellido = (string)reader[nameof(Propietario.Apellido)],
							Dni = (string)reader[nameof(Propietario.Dni)],
							Telefono = (string)reader[nameof(Propietario.Telefono)],
							Mail = (string)reader[nameof(Propietario.Mail)],
						};
						res.Add(p);
					}
					connection.Close();
				}
			}
			return res;
		}

		public Propietario ObtenerPorId(int id)
		{
			Propietario p = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT Id, Nombre, Apellido, Dni, Telefono, Mail FROM propietarios" +
					$" WHERE Id=@id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.Add("@id", SqlDbType.Int).Value = id;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						p = new Propietario
						{
							Id = reader.GetInt32(0),
							Nombre = (string)reader[nameof(Propietario.Nombre)],
							Apellido = (string)reader[nameof(Propietario.Apellido)],
							Dni = (string)reader[nameof(Propietario.Dni)],
							Telefono = (string)reader[nameof(Propietario.Telefono)],
							Mail = (string)reader[nameof(Propietario.Mail)],
						};
						return p;
					}
					connection.Close();
				}
			}
			return p;
		}
	}

}
