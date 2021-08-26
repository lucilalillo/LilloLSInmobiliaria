using LilloLSInmobiliaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {
         RepositorioInmueble repo;
         RepositorioPropietario repoProp;

        public InmueblesController()
        {
            repo = new RepositorioInmueble();
            repoProp = new RepositorioPropietario();
        }

        // GET: InmueblesController
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
    public ActionResult Details(int id)
        {
        Inmueble inmu = new Inmueble();
        inmu = repo.ObtenerPorId(id);
        return View(inmu);

    }

    // GET: InmueblesController/Create
    public ActionResult Create()
        {
            return View();
        }

        // POST: InmueblesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Edit(int id)
        {
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
                    ViewBag.Error = "No se puede eliminar el inmueble porque tiene contratos vigentes";
                }
                else
                {
                    ViewBag.Error = ex.Message;
                    ViewBag.StackTrate = ex.StackTrace;
                }
                return View(inmu);
            }

        }
    }
}
