using LilloLSInmobiliaria.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IRepositorioInmueble repoInmu;
        private readonly IRepositorioPropietario repoProp;

        public HomeController(IRepositorioPropietario propietarios, IRepositorioInmueble inmueble, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.repoProp = propietarios;
            this.repoInmu = inmueble;
        }
        public IActionResult Index()
        {
            if (User.IsInRole("SuperAdministrador"))
            {
                return RedirectToAction(nameof(Seguro));
            }
            else if (User.IsInRole("Administrador"))
            {
                return RedirectToAction(nameof(AlgoRestringido));
            }
            else if (User.IsInRole("Empleado"))
            {
                return RedirectToAction(nameof(Privado));
            }
            else
            {
                return View();
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Policy = "SuperAdministrador")]
        public IActionResult Seguro()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            return View(claims);

        }

        [Authorize(Policy = "Empleado")]
        public IActionResult Privado()
        {

            return View();


        }

        [Authorize(Policy = "Administrador")]
        public IActionResult AlgoRestringido()
        {
            return View();
        }
        public IActionResult Restringido()
        {
            return View();
        }
    }
}
