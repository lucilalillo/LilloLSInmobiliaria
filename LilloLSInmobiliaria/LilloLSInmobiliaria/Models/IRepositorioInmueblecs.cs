using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
        public interface IRepositorioInmueble : IRepositorio<Inmueble>
        {
            IList<Inmueble> BuscarPorPropietario(int idPropietario);
        }
}
