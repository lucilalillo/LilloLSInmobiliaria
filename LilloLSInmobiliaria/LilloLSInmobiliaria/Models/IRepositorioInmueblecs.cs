using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
        interface IRepositorioInmueble : IRepositorio<Inmueble>
        {
            IList<Inmueble> BuscarPorPropietario(int idPropietario);
        }
}
