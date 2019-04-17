using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class ClientesController : Controller
    {

        private readonly IApplicationCliente _applicationCliente;

        public ClientesController(IApplicationCliente applicationCliente)
        {
            _applicationCliente = applicationCliente;
        } //constructor

        public IActionResult Index()
        {
            var model = _applicationCliente.GetAll();

            return View(model);
        } //Index

    } //class

} //namespace