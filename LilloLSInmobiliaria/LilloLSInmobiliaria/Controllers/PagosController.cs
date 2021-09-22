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
    public class PagosController : Controller
    {
        IRepositorioPago repo;
        IRepositorioContrato repoCon;
        private readonly IConfiguration config;

        public PagosController(IRepositorioPago repo, IRepositorioContrato repoCon, IConfiguration config)
        {
            this.config = config;
            this.repo = repo;
            this.repoCon = repoCon;
        }

        // GET: PagoController
        [Authorize(Policy = "Empleado")]
        public ActionResult Index()
        {
            try
            {
                var lista = repo.ObtenerTodos();
                ViewBag.Id = TempData["Id"];
                if (TempData.ContainsKey("Mensaje"))
                    ViewBag.Mensaje = TempData["Mensaje"];
                return View(lista);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: PagoController/Details/5
        [Authorize(Policy = "Empleado")]
        public ActionResult Details(int id)
        {
            Pago p = new Pago();
            p = repo.ObtenerPorId(id);
            return View(p);
        }

        // GET: PagoController/Create
        [Authorize(Policy = "Empleado")]
        public ActionResult Create()
        {
            ViewBag.Contratos = repoCon.ObtenerTodos();
            return View();
        }

        // POST: PagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Empleado")]
        public ActionResult Create(Pago p)
        {
            try
            {
                repo.Alta(p);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: PagoController/Edit/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Edit(int id)
        {
            ViewBag.Contratos = repoCon.ObtenerTodos();
            var i = repo.ObtenerPorId(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(i);
        }

        // POST: PagoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Edit(int id, Pago pago)
        {
            Pago p = null;
            try {
                p = repo.ObtenerPorId(id);
                p.ContratoId = pago.ContratoId;
                p.NumPago = pago.NumPago;
                p.Importe = pago.Importe;
                p.FechaPago = pago.FechaPago;
                repo.Modificacion(p);
                TempData["Mensaje"] = "Datos guardados correctamente";
                return RedirectToAction(nameof(Index));

            } catch (Exception ex) {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(p);
            }

        }

        // GET: PagoController/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
            var i = repo.ObtenerPorId(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(i);
        }

        // POST: PagoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Pago pago)
        {
            try
            {
                repo.Baja(id);
                TempData["Mensaje"] = "Eliminación realizada correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(pago);
            }
        }
    }
}
