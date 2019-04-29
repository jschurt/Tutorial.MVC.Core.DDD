using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ProdutoViewModel
    {

        public int Id { get; set; }
        public List<string> ListaErrors { get; set; } = new List<string>();
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public string Unidade { get; set; }
        public int IdFornecedor { get; set; }
        public string NomeFornecedor { get; set; }

    } //class

} //namespace
