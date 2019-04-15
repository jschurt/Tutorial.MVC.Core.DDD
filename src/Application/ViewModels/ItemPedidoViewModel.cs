using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ItemPedidoViewModel
    {

        public int Id { get; set; }
        public List<string> ListaErrors { get; set; } = new List<string>();
        public int Qtd { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }

    } //class

} //namespace
