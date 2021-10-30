using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LilloLSInmobiliaria.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace LilloLSInmobiliaria.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public InmueblesController(DataContext context, IConfiguration config)
        {
            contexto = context;
            this.config = config;
        }

        // GET: api/Inmuebles/5
        [HttpGet]
        //este metodo se usa en la vista Inmuebles.
        //Me devuelve una lista de todos los inmuebles del usuario actual
        public async Task<ActionResult<Inmueble>> GetListaInmuebles()
        {
            try
            {
                var usuario = User.Identity.Name;
                return Ok(contexto.Inmuebles.Include(e => e.Prop).Where(e => e.Prop.Mail == usuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/Inmuebles/5
        //este metodo se usa en la vista detalle inmueble
        //y me devuelve los datos de un inmueble
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInmueblePorId(int id)
        {
            try
            {
                var usuario = User.Identity.Name;
                return Ok(contexto.Inmuebles.Include(e => e.Prop).Where(e => e.Prop.Mail == usuario).Single(e => e.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Put api/Inmuebles/EditarEstado/5
        //Para cambiar el estado entre disponible y no disponible
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarEstado(int id)
        {
            try
            {
                var usuario = User.Identity.Name;
                var i = contexto.Inmuebles.Include(x => x.Prop)
                    .FirstOrDefault(x => x.Id == id && x.Prop.Mail == usuario);
                if (i != null) { 
                    i.Estado = !i.Estado;
                    contexto.Inmuebles.Update(i);
                    await contexto.SaveChangesAsync();
                    return Ok(i);
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

       //este metodo se usa en la vista Inquilinos
       //Me devuelve una lista con los inmuebles alquilados del usuario actual
        [HttpGet("InmueblesConContrato")]
        public async Task<IActionResult> GetInmueblesAlquilados()
        {
            try
            {
                var usuario = User.Identity.Name;
                var fecha_actual = DateTime.Now;

                var query = from inmu in contexto.Inmuebles
                              join cont in contexto.Contratos
                                on inmu.Id equals cont.InmuebleId
                            where cont.FecInicio <= fecha_actual && cont.FecFin >= fecha_actual && usuario == inmu.Prop.Mail
                            select cont;
             return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
