using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class FornecedoresController : Controller
    {

        private readonly IApplicationFornecedor _applicationFornecedor;

        public FornecedoresController(IApplicationFornecedor applicationFornecedor)
        {
            _applicationFornecedor = applicationFornecedor;
        } //constructor

        public IActionResult Index()
        {
            return View();
        } //Index

        public JsonResult ListagemFornecedoresJson()
        {
            var lista = _applicationFornecedor.GetAll();
            var settings = new JsonSerializerSettings();
            return Json(lista, settings);
        } //ListagemFornecedorsJson

    } //class
}