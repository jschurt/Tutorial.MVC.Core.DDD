using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            return View();
        } //Index


        public JsonResult ListagemClientesJson()
        {
            var lista = _applicationCliente.GetAll();
            //var lista = new { { email = "teste@teste.com"} };
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        } //ListagemClientesJson

    } //class

} //namespace