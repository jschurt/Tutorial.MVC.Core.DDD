using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Cadastros.Controllers
{

    [Area("Cadastros")]
    public class ProdutosController : Controller
    {
        private readonly IApplicationProduto _applicationProduto;

        public ProdutosController(IApplicationProduto applicationProduto)
        {
            _applicationProduto = applicationProduto;
        } //constructor

        public IActionResult Index()
        {
            return View();
        } //Index

        public JsonResult ListagemProdutosJson()
        {
            var lista = _applicationProduto.GetAll();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        } //ListagemProdutosJson

    } //class

} //namespace