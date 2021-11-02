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

namespace LilloLSInmobiliaria.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ContratosController : ControllerBase
    {
        private readonly DataContext contexto;

        public ContratosController(DataContext context)
        {
            contexto = context;
        }

        // GET: api/Contratos
        [HttpGet("ObtenerContrato")]
        public async Task<ActionResult> GetContrato()
        {
            try
            {
                var usuario = User.Identity.Name;
                var fecha_actual = DateTime.Now;

                var con = await contexto.Contratos
                                .Include(x => x.Inquilino)
                                .Include(x => x.Inmueble)
                                .Where(x => x.Inmueble.Prop.Mail == usuario && x.FecInicio <= fecha_actual && x.FecFin >= fecha_actual)
                                .ToListAsync();
                return Ok(con);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
