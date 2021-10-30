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
    public class InquilinosController : ControllerBase
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public InquilinosController(DataContext context, IConfiguration config)
        {
            contexto = context;
            this.config = config;
        }

        // GET: api/Inquilinos
        [HttpGet]
        public async Task<ActionResult<Inquilino>> GetInquilinos()
        {
            try {
                var usuario = User.Identity.Name;
                return await contexto.Inquilinos.SingleOrDefaultAsync(x => x.Mail == usuario);
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }

        // GET: api/Inquilinos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inquilino>> GetInquilino(int id)
        {
            try
            {
                return Ok(contexto.Inquilinos.SingleOrDefault(x => x.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Inquilinos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInquilino(int id, Inquilino inquilino)
        {
            if (id != inquilino.Id)
            {
                return BadRequest();
            }

            contexto.Entry(inquilino).State = EntityState.Modified;

            try
            {
                await contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InquilinoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Inquilinos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inquilino>> PostInquilino(Inquilino inquilino)
        {
            contexto.Inquilinos.Add(inquilino);
            await contexto.SaveChangesAsync();

            return CreatedAtAction("GetInquilino", new { id = inquilino.Id }, inquilino);
        }

        // DELETE: api/Inquilinos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInquilino(int id)
        {
            var inquilino = await contexto.Inquilinos.FindAsync(id);
            if (inquilino == null)
            {
                return NotFound();
            }

            contexto.Inquilinos.Remove(inquilino);
            await contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool InquilinoExists(int id)
        {
            return contexto.Inquilinos.Any(e => e.Id == id);
        }
    }
}
