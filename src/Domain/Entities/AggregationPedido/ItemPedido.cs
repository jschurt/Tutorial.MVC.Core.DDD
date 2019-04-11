using Domain.Entities.Shared;
using System;

namespace Domain.Entities.AggregationPedido
{
    public class ItemPedido : EntidadeBase  
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }


        //Propriedades Navegacao
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }


        //Observe que estamos implementando aqui um padrao facade
        public override bool EstaConsistente()
        {
            QuantidadeDeveSerSuperiorAZero();
            ItemDePedidoDeveSerAssociadoAUmPedido();
            ProdutoDeveSerPreenchido();

            return (ListaErros.Count == 0);

        } //EstaConsistente

        #region Validation Methods...

        private void QuantidadeDeveSerSuperiorAZero()
        {

            if (Quantidade <= 0)
                ListaErros.Add("Quantidade devera ser maior que zero.");
            
        } //QuantidadeDeveSerSuperiorAZero

        private void ItemDePedidoDeveSerAssociadoAUmPedido()
        {

            if(IdPedido <= 0)
                ListaErros.Add("Lista de Pedido invalido.");

        } //ItemDePedidoDeveSerAssociadoAUmPedido

        private void ProdutoDeveSerPreenchido()
        {

            if (IdProduto <= 0)
                ListaErros.Add("Produto deve ser informado.");

        } //ProdutoDeveSerPreenchido

        #endregion

    } //class
} //namespace
