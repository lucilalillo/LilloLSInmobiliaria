using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
    public class RepositorioPropietario : RepositorioBase, IRepositorioPropietario
    {

		public RepositorioPropietario(IConfiguration config) : base(config)
        {

        }

        public int Alta(Propietario p) {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString)) {

				string sql = $"INSERT INTO propietarios (Nombre, Apellido, Dni, Telefono, Mail, ClaveProp, Avatar) " +
					$"VALUES (@nombre, @apellido, @dni, @telefono, @mail, @claveprop, @avatar);" +
					$"SELECT SCOPE_IDENTITY();";

				using (SqlCommand command = new SqlCommand(sql, conn)) { 
				
					command.Parameters.AddWithValue("@nombre", p.Nombre);
					command.Parameters.AddWithValue("@apellido", p.Apellido);
					command.Parameters.AddWithValue("@dni", p.Dni);
					command.Parameters.AddWithValue("@telefono", p.Telefono);
					command.Parameters.AddWithValue("@mail", p.Mail);
					command.Parameters.AddWithValue("@claveprop", p.ClaveProp);
					if (String.IsNullOrEmpty(p.Avatar))
					{
						command.Parameters.AddWithValue("@avatar", DBNull.Value);
					}
					else
					{
						command.Parameters.AddWithValue("@avatar", p.Avatar);
					}
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
					$"Nombre=@nombre, Apellido=@apellido, Dni=@dni, Telefono=@telefono, "+
						$"Mail=@mail, Avatar=@avatar WHERE Id = @id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@nombre", p.Nombre);
					command.Parameters.AddWithValue("@apellido", p.Apellido);
					command.Parameters.AddWithValue("@dni", p.Dni);
					command.Parameters.AddWithValue("@telefono", p.Telefono);
					command.Parameters.AddWithValue("@mail", p.Mail);
					command.Parameters.AddWithValue("@avatar", p.Avatar);
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
				string sql = $"SELECT Id, Nombre, Apellido, Dni, Telefono, Mail, Avatar" +
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
							Avatar = reader["Avatar"].ToString(),
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
				string sql = $"SELECT Id, Nombre, Apellido, Dni, Telefono, Mail, Avatar FROM propietarios" +
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
							Avatar = reader["Avatar"].ToString(),
						};
						return p;
					}
					connection.Close();
				}
			}
			return p;
		}

        public Propietario ObtenerPorEmail(string email)
        {
			Propietario p = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT Id, Nombre, Apellido, Dni, Telefono, Mail, ClaveProp, Avatar FROM propietarios" +
					$" WHERE Mail=@mail";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.Add("@mail", SqlDbType.VarChar).Value = email;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						p = new Propietario
						{
							Id = reader.GetInt32(0),
							Nombre = reader.GetString(1),
							Apellido = reader.GetString(2),
							Dni = reader.GetString(3),
							Telefono = reader.GetString(4),
							Mail = reader.GetString(5),
							ClaveProp = reader.GetString(6),
							Avatar = reader["Avatar"].ToString(),

						};
					}
					connection.Close();
				}
			}
			return p;
		}

        public IList<Propietario> BuscarPorNombre(string nombre)
        {
			List<Propietario> res = new List<Propietario>();
			Propietario p = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT Id, Nombre, Apellido, Dni, Telefono, Mail, ClaveProp, Avatar FROM propietarios" +
					$" WHERE Nombre LIKE %@nombre% OR Apellido LIKE %@nombre";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						p = new Propietario
						{
							Id = reader.GetInt32(0),
							Nombre = reader.GetString(1),
							Apellido = reader.GetString(2),
							Dni = reader.GetString(3),
							Telefono = reader.GetString(4),
							Mail = reader.GetString(5),
							ClaveProp = reader.GetString(6),
							Avatar = reader["Avatar"].ToString(),
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
