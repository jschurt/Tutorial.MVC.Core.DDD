using Domain.Entities.Shared;
using System;
using System.Collections.Generic;

namespace Domain.Entities.AggregationPedido
{
    public class Pedido : EntidadeBase
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime? DataEntrega { get; set; }
        public int idCliente { get; set; }
        public string Observacao { get; set; }

        //Campos que nao serao persistidos (ignorados em FluentAPI)
        public int QuantidadeTotalProdutos { get; set; }
        public decimal ValorTotalProdutos { get; set; }

        //Propriedade Navegacao...
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }


        //Observe que estamos implementando aqui um padrao facade
        public override bool EstaConsistente()
        {
            DataPedidoDeveSerPreenchida();
            DataPedidoDeveSerMenorOuIgualDataAtual();
            DataEntregaDeveSerSuperiorOuIgualDataPedido();
            ClienteDeveSerPreenchido();
            ObservacaoDeveTerUmTamanhoLimite(4000);

            return (ListaErros.Count == 0);

        } //EstaConsistente

        #region Validation Methods...

        private void DataPedidoDeveSerPreenchida()
        {
            if (DataPedido == null)
                ListaErros.Add("O campo Data Pedido deve ser preenchido.");
        } //DataPedidoDeveSerPreenchida

        private void DataPedidoDeveSerMenorOuIgualDataAtual()
        {
            if (DataPedido <= DateTime.Today)
                ListaErros.Add("O campo Data Pedido deve ser inferior ou igual a data atual.");
        } //DataPedidoDeveSerMenorDataAtual

        private void DataEntregaDeveSerSuperiorOuIgualDataPedido()
        {
            if (DataEntrega != null && DataEntrega <= DataPedido)
                ListaErros.Add("O campo Data Entrega deve ser superior ou igual a data do pedido.");
        } //DataEntregaDeveSerSuperiorOuIgualDataPedido

        private void ClienteDeveSerPreenchido()
        {
            if(idCliente == 0)
                ListaErros.Add("O campo Cliente deve ser fornecido.");
        } //ClienteDeveSerPreenchido

        protected void ObservacaoDeveTerUmTamanhoLimite(int tamanho)
        {

            if (!string.IsNullOrEmpty(Observacao) && Observacao.Length > tamanho)
                ListaErros.Add("O campo Observacao deve ter no maximo " + tamanho + " caracteres");

        } //ApelidoDeveTerUmTamanhoLimite

        #endregion

        public Pedido VerificarSePedidoEstaEntregue(Pedido pedido)
        {

            if (pedido != null && pedido.DataEntrega != null)
                pedido.ListaErros.Add("Pedido ja foi entregue! ");

            return pedido;

        } //VerificarSePedidoEstaEntregue


    } //class
} //namespace
