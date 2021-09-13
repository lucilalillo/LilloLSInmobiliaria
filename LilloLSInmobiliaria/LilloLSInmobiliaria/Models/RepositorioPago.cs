using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
    public class RepositorioPago : RepositorioBase
    {
		public RepositorioPago(IConfiguration config) : base(config)
		{
		}
			
		public int Alta(Pago pa)
			{
				int res = -1;
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					string sql = $"INSERT INTO pagos (ContratoId, NumPago, Importe, FechaPago) " +
						$"VALUES (@contratoid, @numPago, @importe, @fechapago);" +
						$"SELECT SCOPE_IDENTITY();";//devuelve el id insertado
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.CommandType = CommandType.Text;
						command.Parameters.AddWithValue("@contratoid", pa.ContratoId);
						command.Parameters.AddWithValue("@numPago", pa.NumPago);
						command.Parameters.AddWithValue("@importe", pa.Importe);
						command.Parameters.AddWithValue("@fechapago", pa.FechaPago);
						connection.Open();
						res = Convert.ToInt32(command.ExecuteScalar());
						pa.Id = res;
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
					string sql = $"DELETE FROM pagos WHERE Id = @id";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.CommandType = CommandType.Text;
						command.Parameters.AddWithValue("@id", id);
						connection.Open();
						res = command.ExecuteNonQuery();
						connection.Close();
					}
				}
				return res;
			}

			public int Modificacion(Pago pa)
			{
				int res = -1;
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					string sql = $"UPDATE pagos SET NumPago=@numpago, FechaPago=@fechaPago, " +
						$"Importe=@importe, ContratoId=@contratoid " +
						$"WHERE Id = @id";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{

						command.CommandType = CommandType.Text;
						command.Parameters.AddWithValue("@numpago", pa.NumPago);
						command.Parameters.AddWithValue("@fechaPago", pa.FechaPago);
						command.Parameters.AddWithValue("@importe", pa.Importe);
						command.Parameters.AddWithValue("@contratoid", pa.ContratoId);
						command.Parameters.AddWithValue("@id", pa.Id);
						connection.Open();
						res = command.ExecuteNonQuery();
						connection.Close();
					}
				}
				return res;
			}

		public IList<Pago> ObtenerTodos()
		{
			IList<Pago> res = new List<Pago>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{

				string sql = $"SELECT pa.Id, NumPago, FechaPago, Importe, pa.ContratoId, " +
					"c.InmuebleId, i.Direccion, c.InquilinoId, inq.Apellido,  " +
					"c.FecInicio, c.FecFin, c.Monto, c.Estado " +
					"FROM pagos pa, contratos c, inmuebles i, inquilinos inq " +
					"WHERE pa.ContratoId = c.Id AND c.InmuebleId = i.Id " +
					"AND c.InquilinoId = inq.Id; ";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Pago pa = new Pago
						{
							Id = reader.GetInt32(0),
							NumPago = reader.GetInt32(1),
							FechaPago = reader.GetDateTime(2),
							Importe = reader.GetDecimal(3),
							ContratoId = reader.GetInt32(4),

							contrato = new Contrato
							{
								Id = reader.GetInt32(4),
								InmuebleId = reader.GetInt32(5),
								
								Inmueble = new Inmueble
								{
									Id = reader.GetInt32(5),
									Direccion = reader.GetString(6),
								},

								
								Inquilino = new Inquilino
								{
									Id = reader.GetInt32(7),
									Apellido = reader.GetString(8)
								},

								FecInicio = reader.GetDateTime(9),
								FecFin = reader.GetDateTime(10),
								Monto = reader.GetDecimal(11),
								Estado = reader.GetBoolean(12),

							}
						};
						res.Add(pa);
					}
					connection.Close();
				}
			}
			return res;
		}

		public Pago ObtenerPorId(int id)
		{
			Pago pa = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT pa.Id, NumPago, FechaPago, Importe, ContratoId, ca.InmuebleId, ca.InquilinoId, ca.FecInicio, ca.FecFin, ca.Monto, ca.Estado  " +
					$"FROM pagos pa INNER JOIN contratos ca ON pa.ContratoId = ca.Id" +
					$" WHERE pa.Id=@idPago";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@idPago", SqlDbType.Int).Value = id;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						pa = new Pago
						{
							Id = reader.GetInt32(0),
							NumPago = reader.GetInt32(1),
							FechaPago = reader.GetDateTime(2),
							Importe = reader.GetDecimal(3),
							ContratoId = reader.GetInt32(4),
							contrato = new Contrato
							{
								Id = reader.GetInt32(4),
								InmuebleId = reader.GetInt32(5),
								
								Inmueble = new Inmueble
								{
									Id = reader.GetInt32(5),

								},
								
								InquilinoId = reader.GetInt32(6),
								Inquilino = new Inquilino
								{
									Id = reader.GetInt32(6),

								},

								FecInicio = reader.GetDateTime(7),
								FecFin = reader.GetDateTime(8),
								Monto = reader.GetDecimal(9),
								Estado = reader.GetBoolean(10),
							}
						};
					}
					connection.Close();
				}
			}
			return pa;
		}
	}
    }
