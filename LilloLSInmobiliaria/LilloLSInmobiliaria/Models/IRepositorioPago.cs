using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
    interface IRepositorioPago : IRepositorio<Pago>
    {
        IList<Pago> ObtenerTodosPorIdContrato(int idContrato);
    }
}
