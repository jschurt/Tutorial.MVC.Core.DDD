using Domain.Entities.AggregationPedido;
using Domain.Interfaces.Repository.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Services.Aggregation
{
    public class ServicePedido : IServicePedido
    {

        protected readonly IRepositoryPedido _repositoryPedido;

        public ServicePedido(IRepositoryPedido repositoryPedido)
        {
            _repositoryPedido = repositoryPedido;
        } //constructor

        #region Add...

        public Pedido Add(Pedido pedido)
        {

            pedido = CheckIfReadyToAdd(pedido);
            if (pedido.ListaErros.Count != 0)
                return pedido;

            _repositoryPedido.Add(pedido);
            return pedido;

        } //Add


        private Pedido CheckIfReadyToAdd(Pedido pedido)
        {
            if (!pedido.EstaConsistente())
                return pedido;

            pedido = VerifyIfExistOpenOrderInTheInsertDate(pedido);
            pedido = VeifyIfExistItemPedidoInsert(pedido);
            pedido = VerifyIfItemPedidoIsConsistentInsert(pedido);

            return pedido;

        } //CheckIfReadyToAdd


        private Pedido VerifyIfExistOpenOrderInTheInsertDate(Pedido pedido)
        {

            var pedidos = _repositoryPedido.Search(p => p.idCliente == pedido.idCliente && p.DataEntrega == null && p.DataPedido == pedido.DataPedido).FirstOrDefault();
            if (pedidos != null)
                pedido.ListaErros.Add("Existe(m) pedido(s) aberto(s) deste cliente nesta data " + pedido.DataPedido.ToShortTimeString() + "!");

            return pedido;

        } //VerifyIfExistOpenOrderInTheInsertDate


        private Pedido VeifyIfExistItemPedidoInsert(Pedido pedido)
        {
            if (pedido.ItensPedido.Count() != 1)
                pedido.ListaErros.Add("Na inclusao do pedido e preciso informar um item de pedido. ");

            return pedido;

        } //VeifyIfExistItemPedidoInsert

        private Pedido VerifyIfItemPedidoIsConsistentInsert(Pedido pedido)
        {
            if(pedido.ItensPedido.Count() == 1)
            {
                var item = pedido.ItensPedido.ToList()[0];
                if(!item.EstaConsistente(true))
                {
                    foreach(var erros in item.ListaErros)
                    {
                        pedido.ListaErros.Add(erros);
                    } //foreach

                } //if

            } //if

            return pedido;

        } //VerifyIfItemPedidoIsConsistentInsert


        #endregion

        #region Update...

        public Pedido Update(Pedido pedido)
        {

            pedido = CheckIfReadyToUpdate(pedido);
            if (pedido.ListaErros.Count() > 0)
                return pedido;

            _repositoryPedido.Update(pedido);
            return pedido;

        } //Update

        private Pedido CheckIfReadyToUpdate(Pedido pedido)
        {
            if (!pedido.EstaConsistente())
                return pedido;

            pedido = VerifyIfExistOpenOrderInTheUpdateDate(pedido);
            pedido = VerifyIfOrderAlreadyDelivered(pedido);

            return pedido;

        } //CheckIfReadyToUpdate

        private Pedido VerifyIfExistOpenOrderInTheUpdateDate(Pedido pedido)
        {

            var pedidos = _repositoryPedido.Search(p => p.idCliente == pedido.idCliente && p.DataEntrega == null && p.DataPedido == pedido.DataPedido && p.Id == pedido.Id).FirstOrDefault();
            if (pedidos != null)
                pedido.ListaErros.Add("Existe(m) pedido(s) aberto(s) deste cliente nesta data " + pedido.DataPedido.ToShortTimeString() + "!");

            return pedido;

        } //VerifyIfExistOpenOrderInTheInsertDate

        private Pedido VerifyIfOrderAlreadyDelivered(Pedido pedido)
        {

            if (pedido!=null && pedido.DataEntrega != null)
                pedido.ListaErros.Add("O pedido ja foi entregue.");

            return pedido;

        } //VerifyIfOrderAlreadyDelivered

        #endregion

        #region Remove...

        public Pedido Remove(Pedido pedido)
        {

            pedido = CheckIfReadyToRemove(pedido);
            if (pedido.ListaErros.Count > 0)
                return pedido;

            _repositoryPedido.Remove(pedido);
            return pedido;

        } //Remove

        private Pedido CheckIfReadyToRemove(Pedido pedido)
        {

            pedido = VerifyIfOrderAlreadyDelivered(pedido);

            return pedido;

        } //CheckIfReadyToRemove


        #endregion

        #region Get...

        public IEnumerable<Pedido> GetAll()
        {
            return _repositoryPedido.GetAll();
        } //GetAll

        public Pedido GetById(int id)
        {
            return _repositoryPedido.GetById(id);
        } //GetById

        
        public IEnumerable<Pedido> Search(Expression<Func<Pedido, bool>> predicate)
        {
            return _repositoryPedido.Search(predicate);
        } //Search

        #endregion

        public void Dispose()
        {
            _repositoryPedido.Dispose();
            GC.SuppressFinalize(this);
        } //Dispose



    } //class
} //namespace
