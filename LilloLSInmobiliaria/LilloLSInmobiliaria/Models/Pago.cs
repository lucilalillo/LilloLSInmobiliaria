using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
    public class Pago
    {
        [Key]
        [DisplayName("Código de Pago")]
        public int Id { get; set; }

        [DisplayName("Número de pago")]
        public int NumPago { get; set; }

        [DisplayName("Fecha de pago"), DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }

        public decimal Importe { get; set; }

        [DisplayName("Código de Contrato")]
        public int ContratoId { get; set; }

        [DisplayName("Datos del Contrato")]
        public Contrato contrato { get; set; }
    }
}
