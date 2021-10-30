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

        // GET api/Inquilinos/
        [HttpGet("ObtenerInquilino")]
        public async Task<IActionResult> GetInquilino([FromBody]Inmueble inmueble)
        {
            try
            {
                var usuario = User.Identity.Name;
                var fecha_actual = DateTime.Now;

                var query = from cont in contexto.Contratos
                            join inmue in contexto.Inmuebles
                                on cont.InmuebleId equals inmue.Id
                            join inquilino in contexto.Inquilinos
                                on cont.InquilinoId equals inquilino.Id
                            where cont.FecInicio <= fecha_actual
                                    && cont.FecFin >= fecha_actual
                                    && inmue.Id == inmueble.Id
                            select inquilino;

                return Ok(query);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
}
