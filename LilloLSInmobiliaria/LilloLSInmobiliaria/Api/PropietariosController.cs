using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LilloLSInmobiliaria.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using DataContext = LilloLSInmobiliaria.Models.DataContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LilloLSInmobiliaria.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PropietariosController : ControllerBase
    {
        private readonly Models.DataContext contexto;
        private readonly IConfiguration config;

        public PropietariosController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }


        // GET: api/<PropietariosController>
        [HttpGet]
        public async Task<ActionResult<Propietario>> Get()
        {
            try
            {
                var usuario = User.Identity.Name;
                return await contexto.Propietarios.SingleOrDefaultAsync(x => x.Mail == usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<PropietariosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(contexto.Propietarios.SingleOrDefault(x => x.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<controller>/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(contexto.Propietarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<controller>/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] LoginView loginView)
        {
            try
            {
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: loginView.Clave,
                    salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 1000,
                    numBytesRequested: 256 / 8));
                var p = await contexto.Propietarios.FirstOrDefaultAsync(x => x.Mail == loginView.Usuario);
                if (p == null || p.ClaveProp != hashed)
                {
                    return BadRequest("Nombre de usuario o clave incorrecta");
                }
                else
                {
                    var key = new SymmetricSecurityKey(
                        System.Text.Encoding.ASCII.GetBytes(config["TokenAuthentication:SecretKey"]));
                    var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, p.Mail),
                        new Claim("FullName", p.Nombre + " " + p.Apellido),
                        new Claim(ClaimTypes.Role, "Propietario"),
                    };

                    var token = new JwtSecurityToken(
                        issuer: config["TokenAuthentication:Issuer"],
                        audience: config["TokenAuthentication:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: credenciales
                    );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("usuarioActual")]
        public async Task<ActionResult<Propietario>> UsuarioActual()
        {
            try
            {

                var usuario = User.Identity.Name;

                return Ok(contexto.Propietarios.SingleOrDefault(x => x.Mail == usuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<PropietariosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Propietario entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await contexto.Propietarios.AddAsync(entidad);
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

        // PUT api/<PropietariosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] Propietario entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entidad.Id = id;
                    Propietario original = await contexto.Propietarios.FindAsync(id);
                    if (String.IsNullOrEmpty(entidad.ClaveProp))
                    {
                        entidad.ClaveProp = original.ClaveProp;
                    }
                    else
                    {
                        entidad.ClaveProp = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: entidad.ClaveProp,
                            salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
                            prf: KeyDerivationPrf.HMACSHA1,
                            iterationCount: 1000,
                            numBytesRequested: 256 / 8));
                    }
                    contexto.Propietarios.Update(entidad);
                    await contexto.SaveChangesAsync();
                    return Ok(entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //PUT api/<controller>
        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Editar(int id, Propietario entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var usuario = User.Identity.Name;
                    Propietario usuarioActual = contexto.Propietarios.SingleOrDefault(x => x.Mail == usuario);

                    if (entidad.Dni != "" && entidad.Dni != null) { usuarioActual.Dni = entidad.Dni; }
                    if (entidad.Nombre != "" && entidad.Nombre != null) { usuarioActual.Nombre = entidad.Nombre; }
                    if (entidad.Apellido != "" && entidad.Apellido != null) { usuarioActual.Apellido = entidad.Apellido; }
                    if (entidad.Telefono != "" && entidad.Telefono != null) { usuarioActual.Telefono = entidad.Telefono; }
                    if (entidad.Mail != "" && entidad.Mail != null) { usuarioActual.Mail = entidad.Mail; }
                    if (entidad.ClaveProp != "" && entidad.ClaveProp != null) { usuarioActual.ClaveProp = entidad.ClaveProp; }


                    contexto.Propietarios.Update(usuarioActual);
                    contexto.SaveChanges();
                    return Ok(usuarioActual);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // PUT api/<controller>
        [HttpPut("editar")]
        public async Task<IActionResult> Editar([FromBody] Propietario entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var usuario = User.Identity.Name;
                    Propietario usuarioActual = contexto.Propietarios.SingleOrDefault(x => x.Mail == usuario);

                    if (entidad.Dni != "" && entidad.Dni != null) { usuarioActual.Dni = entidad.Dni; }
                    if (entidad.Nombre != "" && entidad.Nombre != null) { usuarioActual.Nombre = entidad.Nombre; }
                    if (entidad.Apellido != "" && entidad.Apellido != null) { usuarioActual.Apellido = entidad.Apellido; }
                    if (entidad.Telefono != "" && entidad.Telefono != null) { usuarioActual.Telefono = entidad.Telefono; }
                    if (entidad.Mail != "" && entidad.Mail != null) { usuarioActual.Mail = entidad.Mail; }
                    if (entidad.ClaveProp != "" && entidad.ClaveProp != null) { usuarioActual.ClaveProp = entidad.ClaveProp; }


                    contexto.Propietarios.Update(usuarioActual);
                    contexto.SaveChanges();
                    return Ok(usuarioActual);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<PropietariosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var p = contexto.Propietarios.Find(id);
                    if (p == null)
                        return NotFound();
                    contexto.Propietarios.Remove(p);
                    contexto.SaveChanges();
                    return Ok(p);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
