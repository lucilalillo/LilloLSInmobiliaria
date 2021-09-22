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
    public class ContratosController : Controller
    {
        IRepositorioContrato repo;
        IRepositorioInmueble repoInmueble;
        IRepositorioInquilino repoInq;
        IRepositorioGarante repoGar;
        protected readonly IConfiguration config;

        public ContratosController(IRepositorioContrato repo, IRepositorioInmueble repoInmueble, IRepositorioInquilino repoInq, IRepositorioGarante repoGar, IConfiguration config)
        {
            this.config = config;
            this.repo = repo;
            this.repoInmueble = repoInmueble;
            this.repoInq = repoInq;
            this.repoGar = repoGar;
        }


        // GET: ContratosController
        [Authorize(Policy = "Empleado")]
        public ActionResult Index()
        {
            var lista = repo.ObtenerTodos();
            if (TempData.ContainsKey("Id"))
                ViewBag.Id = TempData["Id"];
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(lista);

        }

        // GET: ContratosController/Details/5
        [Authorize(Policy = "Empleado")]
        public ActionResult Details(int id)
        {
            Contrato c = new Contrato();
            c = repo.ObtenerPorId(id);
            return View(c);
        }

        // GET: ContratosController/Create
        [Authorize(Policy = "Empleado")]
        public ActionResult Create()
        {
            ViewBag.Inmueble = repoInmueble.ObtenerTodos();
            ViewBag.Inquilino = repoInq.ObtenerTodos();
            ViewBag.Garantes = repoGar.ObtenerTodos();
            return View();

        }

        // POST: ContratosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Empleado")]
        public ActionResult Create(Contrato c)
        {
            var res = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    if (c.FecInicio < DateTime.Today)
                    {
                        TempData["Error"] = "La fecha de inicio del contrato no puede ser menor a la fecha actual";
                    }
                    if (c.FecFin < DateTime.Today)
                    {
                        TempData["Error"] = "La fecha de finalizacion del contrato no puede ser menor a la fecha actual";
                    }
                    if (c.FecFin < c.FecInicio)
                    {
                        TempData["Error"] = "La fecha de finalizacion del contrato no puede ser menor a la fecha de inicio";
                    }
                    repo.Alta(c);
                    TempData["Mensaje"] = "Contrato guardado satisfactoriamente";
                    return RedirectToAction(nameof(Index));
                }
                else return View(c);
            }
            catch (Exception ex) {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
             }
 }

        // GET: ContratosController/Edit/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Edit(int id)
        {
            ViewBag.Inquilino = repoInq.ObtenerTodos();
            ViewBag.Inmueble = repoInmueble.ObtenerTodos();
            ViewBag.Garantes = repoGar.ObtenerTodos();
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];

            var p = repo.ObtenerPorId(id);
            return View(p);

        }

        // POST: ContratosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Edit(int id, Contrato c)
    {
            Contrato con = null;
            try
            {
                con = repo.ObtenerPorId(id);
                con.InmuebleId = c.InmuebleId;
                con.InquilinoId = c.InquilinoId;
                con.FecInicio = c.FecInicio;
                con.FecFin = c.FecFin;
                con.Monto = c.Monto;
                con.Estado = c.Estado;
                con.GaranteId = c.GaranteId;
                repo.Modificacion(con);
                TempData["Mensaje"] = "Datos guardados correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(con);
            }

        }

        // GET: ContratosController/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var c = repo.ObtenerPorId(id);
            return View(c);
        }

        // POST: ContratosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Contrato c)
        {
            try
            {
                /*var lista = repoPago.ObtenerTodosPorIdContrato(id);
                foreach (var item in lista)
                {
                    repoPago.Baja(item.IdPago);
                }*/
                repo.Baja(id);

                TempData["Mensaje"] = "Eliminación realizada correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(c);
            }

        }
    }
}
