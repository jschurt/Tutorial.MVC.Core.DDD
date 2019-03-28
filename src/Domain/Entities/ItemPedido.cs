namespace Domain.Entities
{
    public class ItemPedido : EntidadeBase  
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int idPedido { get; set; }
        public int idProduto { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }

        public override bool EstaConsistente()
        {
            throw new System.NotImplementedException();
        }
    } //class
} //namespace
