using Domain.Entities.AggregationPedido;
using Domain.Entities.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Cliente : Pessoa
    {

        public int Id { get; set; }


        //Propriedades Navegacao...
        public virtual ICollection<Pedido> Pedidos { get; set; }


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
