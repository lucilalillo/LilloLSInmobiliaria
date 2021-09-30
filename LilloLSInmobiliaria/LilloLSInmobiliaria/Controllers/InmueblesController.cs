using LilloLSInmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {
        IRepositorioInmueble repo;
        IRepositorioPropietario repoProp;
        //RepositorioContrato repoCon;
        protected readonly IConfiguration config;

        public InmueblesController(IRepositorioInmueble repo, IRepositorioPropietario repoProp, IConfiguration config)
        {
            this.config = config;
            this.repo = repo;
            this.repoProp = repoProp;
            //repoCon = new RepositorioContrato(config);
        }

        // GET: InmueblesController
        [Authorize]
        public ActionResult Index()
        {
            var lista = repo.ObtenerTodos();
            if (TempData.ContainsKey("Id")) {
                ViewBag.Id = TempData["Id"];
            }
            if (TempData.ContainsKey("Mensaje"))
            {
                ViewBag.Mensaje = TempData["Mensaje"];
            }
            return View(lista);
        }

        // GET: InmueblesController/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            Inmueble inmu = new Inmueble();
            inmu = repo.ObtenerPorId(id);
            return View(inmu);

        }

        // GET: InmueblesController/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Propietarios = repoProp.ObtenerTodos();
            return View();
        }

        // POST: InmueblesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Inmueble inmueble)
        {
            try
            {
                repo.Alta(inmueble);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }

        }

        // GET: InmueblesController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Propietarios = repoProp.ObtenerTodos();
            var i = repo.ObtenerPorId(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(i);

        }

        // POST: InmueblesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, Inmueble inmu)
        {
            try
            {
                inmu.Id = id;
                repo.Modificacion(inmu);
                TempData["id"] = "Se actualizo el inmueble";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }

        }

        // GET: InmueblesController/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var p = repo.ObtenerPorId(id);
            return View(p);

        }

        // POST: InmueblesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inmueble inmu)
        {
            try
            {
                repo.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("The DELETE statement conflicted with the REFERENCE"))
                {
                    Inmueble p = repo.ObtenerPorId(id);
                    ViewBag.lugar = p.Prop.Nombre + " " + p.Prop.Apellido + " en " + p.Direccion;
                    TempData["Error"] = "No se puede eliminar el inmueble porque tiene contratos vigentes";
                }
                else
                {
                    ViewBag.Error = ex.Message;
                    ViewBag.StackTrate = ex.StackTrace;
                }
                return View(inmu);
            }

        }

        /*[Authorize]
        public IActionResult verContratos(int id) {
            ViewBag.Contratos = repoCon.ObtenerPorId(id);
            var lista = repoCon.mostrarContratosDelInmueble(id);
            ViewData[nameof(Contrato)] = lista;
            return View();
        }*/
    }
}
