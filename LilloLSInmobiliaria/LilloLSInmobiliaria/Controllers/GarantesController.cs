using LilloLSInmobiliaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Controllers
{
    public class GarantesController : Controller
    {
        RepositorioGarante repo;
        protected readonly IConfiguration config;

        public GarantesController(IConfiguration config)
        {
            this.config = config;
            repo = new RepositorioGarante(config);
        }


        // GET: GarantesController
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

        // GET: GarantesController/Details/5
        public ActionResult Details(int id)
        {
            Garante g = new Garante();
            g = repo.ObtenerPorId(id);
            return View(g);
        }

        // GET: GarantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GarantesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Garante g)
        {
            try
            {
                repo.Alta(g);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: GarantesController/Edit/5
        public ActionResult Edit(int id)
        {
            var i = repo.ObtenerPorId(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(i);
        }

        // POST: GarantesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Garante i = null;
            try
            {
                i = repo.ObtenerPorId(id);
                i.Nombre = collection["Nombre"];
                i.Apellido = collection["Apellido"];
                i.Dni = collection["Dni"];
                i.Mail = collection["Mail"];
                i.Telefono = collection["Telefono"];
                repo.Modificacion(i);
                TempData["Mensaje"] = "Datos guardados correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(i);
            }
        }

        // GET: GarantesController/Delete/5
        public ActionResult Delete(int id)
        {
            var i = repo.ObtenerPorId(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(i);

        }

        // POST: GarantesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Garante i)
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
                return View(i);
            }
        }
    }
}
