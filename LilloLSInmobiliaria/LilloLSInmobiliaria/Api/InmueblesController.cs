using LilloLSInmobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LilloLSInmobiliaria.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        private readonly Models.DataContext contexto;
        private readonly IConfiguration config;

        public InmueblesController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }

        // GET: api/<InmueblesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuario = User.Identity.Name;
                var lista = await contexto.Inmuebles
                    .Include(x => x.Prop)
                    .Where(x => x.Prop.Mail == usuario).ToListAsync();
                return Ok(lista);

            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        // GET api/<InmueblesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try {
                return Ok(contexto.Inmuebles.SingleOrDefault(x => x.Id == id));
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        // POST api/<InmueblesController>
        [HttpPost]
        public async Task<IActionResult> Post(Inmueble entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entidad.PropietarioId = contexto.Propietarios.Single(e => e.Mail == User.Identity.Name).Id;
                    contexto.Inmuebles.Add(entidad);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = entidad.Id }, entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<InmueblesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            try
            {
                var usuario = User.Identity.Name;
                var inmueble = contexto.Inmuebles
                    .Include(x => x.Prop).FirstOrDefault(x => x.Id == id);
                    if (inmueble != null) {
                    inmueble.Estado = !inmueble.Estado;
                    contexto.Inmuebles.Update(inmueble);
                    await contexto.SaveChangesAsync();
                    return Ok(inmueble);
                }
                return BadRequest();
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entidad = contexto.Inmuebles.Include(e => e.Prop).FirstOrDefault(e => e.Id == id && e.Prop.Mail == User.Identity.Name);
                var contrato = contexto.Contratos.Include(e => e.Inmueble).FirstOrDefault(e => e.InmuebleId == id);
                if (entidad != null && contrato == null)
                {
                    contexto.Inmuebles.Remove(entidad);
                    contexto.SaveChanges();
                    return Ok("Se eliminó correctamente");
                }
                return BadRequest("El inmueble tiene un contrato vigente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
