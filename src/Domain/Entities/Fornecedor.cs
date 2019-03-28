using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Fornecedor : EntidadeBase
    {

        public int Id { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public string CPFCNPJ { get; set; }
        public string Email { get; set; }
        public VOEndereco Endereco { get; set; }

        public override bool EstaConsistente()
        {
            throw new System.NotImplementedException();
        }
    } //class
} //namespace
