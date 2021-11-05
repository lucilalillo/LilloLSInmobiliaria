using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
    public class Propietario
    {
        [Key]
        [Display(Name = "Codigo de Propietario")]
        public int Id { get; set; }

        [Required]
        public String Nombre { get; set; }

        [Required]
        public String Apellido { get; set; }

        [Required]
        public String Dni { get; set; }

        [Required]
        public String Telefono { get; set; }

        [Required, EmailAddress]
        public String Mail { get; set; }

        [Required, DataType(DataType.Password)]
        public String ClaveProp { get; set; }

        public override string ToString()
        {
            return $"{Id} {Nombre} {Apellido} {Dni} {Telefono} {Mail}";
        }

    }
}
