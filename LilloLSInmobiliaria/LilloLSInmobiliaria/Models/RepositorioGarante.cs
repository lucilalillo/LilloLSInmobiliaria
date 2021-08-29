using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
    public class RepositorioGarante : RepositorioBase
    {
		public RepositorioGarante(IConfiguration config) : base(config)
		{

		}

		public int Alta(Garante g)
		{
			int res = -1;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{

				string sql = $"INSERT INTO garantes (Nombre, Apellido, Dni, Telefono, Mail) " +
					$"VALUES (@nombre, @apellido, @dni, @telefono, @mail);" +
					$"SELECT SCOPE_IDENTITY();";

				using (SqlCommand command = new SqlCommand(sql, conn))
				{

					command.Parameters.AddWithValue("@nombre", g.Nombre);
					command.Parameters.AddWithValue("@apellido", g.Apellido);
					command.Parameters.AddWithValue("@dni", g.Dni);
					command.Parameters.AddWithValue("@telefono", g.Telefono);
					command.Parameters.AddWithValue("@mail", g.Mail);
					conn.Open();
					res = Convert.ToInt32(command.ExecuteScalar());
					g.Id = res;
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
				string sql = $"DELETE FROM garantes WHERE Id = {id}";
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

		public int Modificacion(Garante g)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"UPDATE garantes SET " +
					$"Nombre=@nombre, Apellido=@apellido, Dni=@dni, Telefono=@telefono, Mail=@mail " +
					$"WHERE Id = @id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@nombre", g.Nombre);
					command.Parameters.AddWithValue("@apellido", g.Apellido);
					command.Parameters.AddWithValue("@dni", g.Dni);
					command.Parameters.AddWithValue("@telefono", g.Telefono);
					command.Parameters.AddWithValue("@mail", g.Mail);
					command.Parameters.AddWithValue("@id", g.Id);
					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}

		public IList<Garante> ObtenerTodos()
		{
			IList<Garante> res = new List<Garante>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT Id, Nombre, Apellido, Dni, Telefono, Mail" +
					$" FROM garantes" +
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
						Garante g = new Garante
						{
							Id = reader.GetInt32(0),
							Nombre = (string)reader[nameof(Garante.Nombre)],
							Apellido = (string)reader[nameof(Garante.Apellido)],
							Dni = (string)reader[nameof(Garante.Dni)],
							Telefono = (string)reader[nameof(Garante.Telefono)],
							Mail = (string)reader[nameof(Garante.Mail)],
						};
						res.Add(g);
					}
					connection.Close();
				}
			}
			return res;
		}

		public Garante ObtenerPorId(int id)
		{
			Garante g = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT Id, Nombre, Apellido, Dni, Telefono, Mail FROM garantes" +
					$" WHERE Id=@id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.Add("@id", SqlDbType.Int).Value = id;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						g = new Garante
						{
							Id = reader.GetInt32(0),
							Nombre = (string)reader[nameof(Garante.Nombre)],
							Apellido = (string)reader[nameof(Garante.Apellido)],
							Dni = (string)reader[nameof(Garante.Dni)],
							Telefono = (string)reader[nameof(Garante.Telefono)],
							Mail = (string)reader[nameof(Garante.Mail)],
						};
						return g;
					}
					connection.Close();
				}
			}
			return g;
		}
	}
}
