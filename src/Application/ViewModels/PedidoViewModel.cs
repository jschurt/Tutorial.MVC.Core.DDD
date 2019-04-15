using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class PedidoViewModel
    {

        public int Id { get; set; }
        public List<string> ListaErrors { get; set; } = new List<string>();
        public string DataPedido { get; set; }
        public string DataEntrega { get; set; }
        public string Observacao { get; set; }
        public int QtdProdutos { get; set; }
        public string TotalProdutos { get; set; }
        public int IdCliente { get; set; }

    } //class

} //namespace
