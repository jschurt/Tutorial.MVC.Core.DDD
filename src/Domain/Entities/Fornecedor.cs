using Domain.Entities.Shared;
using Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Fornecedor : Pessoa
    {

        public int Id { get; set; }


        //Propriedades de navegacao...
        public virtual ICollection<Produto> Produtos { get; set; }


        //Observe que estamos implementando aqui um padrao facade
        public override bool EstaConsistente()
        {

            ApelidoDeveSerPreenchido();
            ApelidoDeveTerUmTamanhoLimite(20);
            NomeDeveSerPreenchido();
            NomeDeveTerUmTamanhoLimite(100);
            CPFouCNPJDeveSerPreenchido();
            CPFouCNPJDeveSerValido();
            EmailDeveSerValido();
            EmailDeveTerUmTamanhoLimite(100);
            EnderecoDeveSerPreenchido();
            EnderecoDeveTerUmTamanhoLimite(100);
            BairroDeveTerUmTamanhoLimite(30);
            CidadeDeveSerPreenchido();
            CidadeDeveTerUmTamanhoLimite(30);
            UFDeveSerPreenchido();
            UFDeveSerValida();
            CEPDeveSerValido();

            return !ListaErros.Any();

        } //EstaConsistente

    } //class
} //namespace
