﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Models
{
    public class Inmueble
    {
        [Key]
        [Display(Name = "Codigo de Inmueble")]
        public int Id { get; set; }

        public Propietario Prop { get; set; }

        [ForeignKey(nameof(PropietarioId))]
        [Display(Name = "Dueño")]
        public int PropietarioId { get; set; }

        [Required]
        public String Direccion { get; set; }

        [Required, Display(Name = "Cantidad de Ambientes")]
        public int CantAmbientes { get; set; }

        [Required]
        public String Uso { get; set; }

        [Required,]
        public String Tipo { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public bool Estado { get; set; }

        public override string ToString()
        {
            return $"{Prop.Nombre} {Prop.Apellido} {Direccion} {CantAmbientes} {Uso} {Tipo} {Precio} {Estado}";
        }

    }
}
