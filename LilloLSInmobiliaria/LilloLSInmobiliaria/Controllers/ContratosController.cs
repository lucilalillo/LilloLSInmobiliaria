﻿using LilloLSInmobiliaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LilloLSInmobiliaria.Controllers
{
    public class ContratosController : Controller
    {
        RepositorioContrato repo;
        RepositorioInmueble repoInmueble;
        RepositorioInquilino repoInq;

        public ContratosController()
        {
            repo = new RepositorioContrato();
            repoInmueble = new RepositorioInmueble();
            repoInq = new RepositorioInquilino();
        }


        // GET: ContratosController
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
        public ActionResult Details(int id)
        {
            Contrato c = new Contrato();
            c = repo.ObtenerPorId(id);
            return View(c);
        }

        // GET: ContratosController/Create
        public ActionResult Create()
        {
            ViewBag.Inmueble = repoInmueble.ObtenerTodos();
            ViewBag.Inquilino = repoInq.ObtenerTodos();
            return View();

        }

        // POST: ContratosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contrato c)
        {
            var res = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    var contratos = repo.ObtenerPorInmuebleId(c.InmuebleId);
                    var fechFin = c.FecFin;
                    var fechIni = c.FecInicio;
                    var count = contratos.Count;

                    IList<Contrato> ctosNuevos = new List<Contrato>();
                    foreach (var item in contratos)
                    {
                        if (item.Estado)
                        {
                            if (fechIni < item.FecInicio && fechFin < item.FecInicio)
                            {
                                ctosNuevos.Add(item);
                            }
                            else if (fechIni < item.FecInicio && fechFin > item.FecInicio)
                            {
                                ViewBag.Error = "La fecha de fin de contrato solicitada, debe ser menor a " + item.FecInicio;
                            }
                            else if (fechIni > item.FecFin && fechFin > item.FecFin)
                            {
                                ctosNuevos.Add(item);
                            }
                            else if (fechIni > item.FecFin && fechFin < item.FecFin)
                            {
                                ViewBag.Error = "La fecha de fin de contrato solicitada, deber ser mayor a " + item.FecFin;
                            }
                            else
                            {
                                ViewBag.Error = "La fecha de inicio de contrato solicitada, no deberia estar entre " + item.FecInicio + "  -  " + item.FecFin;
                            }
                        }
                    }
                    if (count == ctosNuevos.Count)
                    {
                        c.Estado = true;
                        res = repo.Alta(c);
                        TempData["Id"] = c.Id;
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Inmueble = repoInmueble.ObtenerTodos();
                        ViewBag.Inquilino = repoInq.ObtenerTodos();
                        return View(c);
                    }
                }
                else
                    return View(c);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(c);
            }


        }

        // GET: ContratosController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Inquilino = repoInq.ObtenerTodos();
            ViewBag.Inmueble = repoInmueble.ObtenerTodos();
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
    public ActionResult Edit(int id, Contrato c)
    {
            try
            {
                repo.Modificacion(c);
                TempData["Mensaje"] = "Datos guardados correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(c);
            }

        }

        // GET: ContratosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContratosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
