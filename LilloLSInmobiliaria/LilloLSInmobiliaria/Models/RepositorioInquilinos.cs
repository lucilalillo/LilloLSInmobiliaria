using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
    public class RepositorioInquilinos
    {
		string connectionString = "Server = (localdb)\\MSSQLLocalDB;Database=LilloLSInmobiliaria;Trusted_Connection=True;MultipleActiveResultSets=true";

        public RepositorioInquilinos()
        {

        }

		public int Alta(Inquilino i)
		{
			int res = -1;
			using (SqlConnection conn = new SqlConnection(connectionString))
			{

				string sql = $"INSERT INTO inquilinos (Nombre, Apellido, Dni, Telefono, Email, ClaveInq) " +
					$"VALUES (@nombre, @apellido, @dni, @telefono, @email, @claveinq);" +
					$"SELECT SCOPE_IDENTITY();";

				using (SqlCommand command = new SqlCommand(sql, conn))
				{

					command.Parameters.AddWithValue("@nombre", i.Nombre);
					command.Parameters.AddWithValue("@apellido", i.Apellido);
					command.Parameters.AddWithValue("@dni", i.Dni);
					command.Parameters.AddWithValue("@telefono", i.Telefono);
					command.Parameters.AddWithValue("@email", i.Email);
					command.Parameters.AddWithValue("@claveinq", i.ClaveInq);
					conn.Open();
					res = Convert.ToInt32(command.ExecuteScalar());
					i.Id = res;
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
				string sql = $"DELETE FROM inquilinos WHERE Id = {id}";
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

		public int Modificacion(Inquilino i)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"UPDATE inquilinos SET " +
					$"Nombre=@nombre, Apellido=@apellido, Dni=@dni, Telefono=@telefono, Email=@email, ClaveInq=@claveinq " +
					$"WHERE Id = @id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@nombre", i.Nombre);
					command.Parameters.AddWithValue("@apellido", i.Apellido);
					command.Parameters.AddWithValue("@dni", i.Dni);
					command.Parameters.AddWithValue("@telefono", i.Telefono);
					command.Parameters.AddWithValue("@email", i.Email);
					command.Parameters.AddWithValue("@claveprop", i.ClaveInq);
					command.Parameters.AddWithValue("@idPropietarios", i.Id);
					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}

		public IList<Inquilino> ObtenerTodos()
		{
			IList<Inquilino> res = new List<Inquilino>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT Id, Nombre, Apellido, Dni, Telefono, Email" +
					$" FROM inquilinos" +
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
						Inquilino i = new Inquilino
						{
							Id = reader.GetInt32(0),
							Nombre = (string)reader[nameof(Inquilino.Nombre)],
							Apellido = (string)reader[nameof(Inquilino.Apellido)],
							Dni = (string)reader[nameof(Inquilino.Dni)],
							Telefono = (string)reader[nameof(Inquilino.Telefono)],
							Email = (string)reader[nameof(Inquilino.Email)],
						};
						res.Add(i);
					}
					connection.Close();
				}
			}
			return res;
		}

		public Inquilino ObtenerPorId(int id)
		{
			Inquilino i = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT Id, Nombre, Apellido, Dni, Telefono, Email FROM inquilinos" +
					$" WHERE Id=@id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.Add("@id", SqlDbType.Int).Value = id;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						i = new Inquilino
						{
							Id = reader.GetInt32(0),
							Nombre = (string)reader[nameof(Inquilino.Nombre)],
							Apellido = (string)reader[nameof(Inquilino.Apellido)],
							Dni = (string)reader[nameof(Inquilino.Dni)],
							Telefono = (string)reader[nameof(Inquilino.Telefono)],
							Email = (string)reader[nameof(Inquilino.Email)],
						};
						return i;
					}
					connection.Close();
				}
			}
			return i;
		}
	}
}
