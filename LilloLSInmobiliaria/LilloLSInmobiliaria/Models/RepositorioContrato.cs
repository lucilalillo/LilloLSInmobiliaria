using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
    public class RepositorioContrato : RepositorioBase, IRepositorioContrato
    {        
		public RepositorioContrato(IConfiguration config): base(config)
        {

        }

		public int Alta(Contrato c)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"INSERT INTO contratos (InmuebleId, InquilinoId, FecInicio, FecFin, Monto, Estado, GaranteId) " +
					$"VALUES (@idInmueble, @idInquilino, @fechaInicio, @fechaFin, @monto, @estado, @idgarante);" +
					$"SELECT SCOPE_IDENTITY();";//devuelve el id insertado
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@idInmueble", c.InmuebleId);
					command.Parameters.AddWithValue("@idInquilino", c.InquilinoId);
					command.Parameters.AddWithValue("@fechaInicio", c.FecInicio);
					command.Parameters.AddWithValue("@fechaFin", c.FecFin);
					command.Parameters.AddWithValue("@monto", c.Monto);
					command.Parameters.AddWithValue("@estado", c.Estado);
					command.Parameters.AddWithValue("@idgarante",c.GaranteId);
					connection.Open();
					res = Convert.ToInt32(command.ExecuteScalar());
					c.Id = res;
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
				string sql = $"DELETE FROM contratos WHERE Id = {id}";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					//command.Parameters.AddWithValue("@id", id);
					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}

		public int Modificacion(Contrato c)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"UPDATE contratos SET InmuebleId=@idInmueble, InquilinoId=@idInquilino, FecInicio=@fechaInicio, FecFin=@fechaFin, Monto=@monto, Estado=@estado, GaranteId=@idgarante " +
					$" WHERE Id = @id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@idInmueble", c.InmuebleId);
					command.Parameters.AddWithValue("@idInquilino", c.InquilinoId);
					command.Parameters.AddWithValue("@fechaInicio", c.FecInicio);
					command.Parameters.AddWithValue("@fechaFin", c.FecFin);
					command.Parameters.AddWithValue("@monto", c.Monto);
					command.Parameters.AddWithValue("@estado", c.Estado);
					command.Parameters.AddWithValue("@idgarante",c.GaranteId);
					command.Parameters.AddWithValue("@id", c.Id);
					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}

		public IList<Contrato> ObtenerTodos()
		{
			IList<Contrato> res = new List<Contrato>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT c.Id, InmuebleId, InquilinoId, FecInicio, FecFin, Monto, " +
					" c.Estado, c.GaranteId, inq.Nombre, inq.Apellido , i.Direccion, g.Nombre, g.Apellido " +
					$" FROM contratos c INNER JOIN inmuebles i ON c.InmuebleId = i.Id " +
					$" INNER JOIN inquilinos inq ON c.InquilinoId = inq.Id " +
					$"INNER JOIN garantes g ON c.GaranteId = g.Id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Contrato c = new Contrato
						{
							Id = reader.GetInt32(0),
							InmuebleId = reader.GetInt32(1),
							InquilinoId = reader.GetInt32(2),
							FecInicio = reader.GetDateTime(3),
							FecFin = reader.GetDateTime(4),
							Monto = reader.GetDecimal(5),
							Estado = reader.GetBoolean(6),
							GaranteId = reader.GetInt32(7),
							Inquilino = new Inquilino
							{
								Id = reader.GetInt32(2),
								Nombre = reader.GetString(8),
								Apellido = reader.GetString(9),
							},
							Inmueble = new Inmueble
							{
								Id = reader.GetInt32(1),
								Direccion = reader.GetString(10),
							},
							Garante = new Garante
							{ 
								Id = reader.GetInt32(7),
								Nombre = reader.GetString(11),
								Apellido = reader.GetString(12),
							}
						};
						res.Add(c);
					}
					connection.Close();
				}
			}
			return res;
		}



		public Contrato ObtenerPorId(int id)
		{
			Contrato c = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT Id, InmuebleId, InquilinoId, FecInicio, FecFin, Monto, Estado, GaranteId FROM contratos " +
					$" WHERE Id=@id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@id", SqlDbType.Int).Value = id;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						c = new Contrato
						{
							Id = reader.GetInt32(0),
							InmuebleId = reader.GetInt32(1),
							InquilinoId = reader.GetInt32(2),
							FecInicio = reader.GetDateTime(3),
							FecFin = reader.GetDateTime(4),
							Monto = reader.GetDecimal(5),
							Estado = reader.GetBoolean(6),
							GaranteId = reader.GetInt32(7),
						};
					}
					connection.Close();
				}
			}
			return c;
		}

		public IList<Contrato> ObtenerPorInmuebleId(int id)
		{
			IList<Contrato> res = new List<Contrato>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT c.Id, InmuebleId, InquilinoId, FecInicio, FecFin, Monto, c.Estado, c.GaranteId " +
					$"i.Direccion, inq.Nombre, inq.Apellido, g.Nombre, g.Apellido " +
					$" FROM contratos c INNER JOIN inmuebles i ON c.InmuebleId = i.Id " +
					$"INNER JOIN Inquilinos inq ON c.InquilinoId = inq.Id " +
					$"INNER JOIN garantes g ON c.GaranteId = g.Id" +
					$"WHERE i.Id = @idInmueble";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@idInmueble", SqlDbType.Int).Value = id;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Contrato c = new Contrato
						{
							Id = reader.GetInt32(0),
							InmuebleId = reader.GetInt32(1),
							InquilinoId = reader.GetInt32(2),
							FecInicio = reader.GetDateTime(3),
							FecFin = reader.GetDateTime(4),
							Monto = reader.GetDecimal(5),
							Estado = reader.GetBoolean(6),
							GaranteId = reader.GetInt32(7),
							Inmueble = new Inmueble
							{
								Id = reader.GetInt32(1),
								Direccion = reader.GetString(8),
							},
							Inquilino = new Inquilino
							{
								Id = reader.GetInt32(2),
								Nombre = reader.GetString(9),
								Apellido = reader.GetString(10),
							},
							Garante = new Garante {
								Id = reader.GetInt32(7),
								Nombre = reader.GetString(11),
								Apellido = reader.GetString(12),
							}
						};
						res.Add(c);
					}
					connection.Close();
				}
			}
			return res;
		}

        public IList<Contrato> ObtenerTodosVigentes(DateTime fechaInicio, DateTime fechaFin)
        {
			IList<Contrato> res = new List<Contrato>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT c.Id, c.InmuebleId, c.InquilinoId, FecInicio, FecFin, Monto, c.Estado, i.Direccion, inq.Nombre, inq.Apellido  " +
					$" FROM contratos c INNER JOIN inmuebles i ON c.InmuebleId = i.Id " +
					$"INNER JOIN inquilinos inq ON c.InquilinoId = inq.Id " +
					$"WHERE c.Estado = 1" +
					$"AND((FecInicio < @fecInicio)AND(FecFin > @fecFin))" +
					$"OR((FecInicio BETWEEN @fecInicio AND @fecFin)AND(FecFin BETWEEN @fecInicio AND @fecFin))" +
					$"OR((FecInicio < @fecInicio)AND(FecFin BETWEEN @fecInicio AND @fecFin))" +
					$"OR((FecInicio BETWEEN @fecInicio AND @fecFin)AND(FecFin > @fecFin));";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@fecInicio", SqlDbType.DateTime).Value = fechaInicio;
					command.Parameters.Add("@fecFin", SqlDbType.DateTime).Value = fechaFin;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Contrato c = new Contrato
						{
							Id = reader.GetInt32(0),
							InmuebleId = reader.GetInt32(1),
							InquilinoId = reader.GetInt32(2),
							FecInicio = reader.GetDateTime(3),
							FecFin = reader.GetDateTime(4),
							Monto = reader.GetDecimal(5),
							Estado = reader.GetBoolean(6),
							Inmueble = new Inmueble
							{
								Id = reader.GetInt32(1),
								Direccion = reader.GetString(7),
							},
							Inquilino = new Inquilino
							{
								Id = reader.GetInt32(2),
								Nombre = reader.GetString(8),
								Apellido = reader.GetString(9),
							},

						};
						res.Add(c);
					}
					connection.Close();
				}
			}
			return res;
		}
	}
    }
