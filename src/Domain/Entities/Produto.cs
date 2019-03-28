namespace Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Unidade { get; set; }
        public int idFornecedor { get; set; }

    } //class
} //namespace
