using Domain.Entities.AggregationPedido;
using Domain.Interfaces.Repository.Aggregation;
using Domain.Interfaces.Services.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Services.Aggregation
{
    public class ServiceItemPedido : IServiceItemPedido
    {

        protected readonly IRepositoryPedido _repositoryPedido;

        public ServiceItemPedido(IRepositoryPedido repositoryPedido)
        {
            _repositoryPedido = repositoryPedido;
        } //constructor

        #region Add...

        public ItemPedido AddItemPedido(ItemPedido itemPedido)
        {
            itemPedido = CheckIfReadyToAdd(itemPedido);
            if (itemPedido.ListaErros.Count > 0)
                return itemPedido;

            _repositoryPedido.AddItemPedido(itemPedido);
            return itemPedido;

        } //AddItemPedido

        private ItemPedido CheckIfReadyToAdd(ItemPedido itemPedido)
        {
            if (!itemPedido.EstaConsistente())
                return itemPedido;

            itemPedido = VerifyIfProductAlreadyExistInOrderInsert(itemPedido);

            return itemPedido;

        } //CheckIfReadyToAdd

        private ItemPedido VerifyIfProductAlreadyExistInOrderInsert(ItemPedido itemPedido)
        {

            var itemPedidos = SearchItensPedido(it => it.IdPedido == itemPedido.IdPedido && it.IdProduto == itemPedido.IdProduto).FirstOrDefault();
            if (itemPedidos != null)
                itemPedido.ListaErros.Add("Produto ja existe neste pedido.");

            return itemPedido;

        } //VerifyIfProductAlreadyExistInOrderInsert

        #endregion

        #region Update...

        public ItemPedido UpdateItemPedido(ItemPedido itemPedido)
        {

            itemPedido = CheckIfReadyToUpdate(itemPedido);
            if (itemPedido.ListaErros.Count > 0)
                return itemPedido;

            _repositoryPedido.UpdateItemPedido(itemPedido);
            return itemPedido;

        } //UpdateItemPedido

        private ItemPedido CheckIfReadyToUpdate(ItemPedido itemPedido)
        {
            if (!itemPedido.EstaConsistente())
                return itemPedido;

            itemPedido = VerifyIfProductAlreadyExistInOrderUpdate(itemPedido);

            return itemPedido;

        } //CheckIfReadyToUpdate

        private ItemPedido VerifyIfProductAlreadyExistInOrderUpdate(ItemPedido itemPedido)
        {

            var itensPedido = SearchItensPedido(it => it.IdPedido == itemPedido.IdPedido && it.IdProduto == itemPedido.IdProduto && it.Id != itemPedido.Id).FirstOrDefault();
            if (itensPedido != null)
                itemPedido.ListaErros.Add("Produto ja existe neste pedido.");

            return itemPedido;

        } //VerifyIfProductAlreadyExistInOrderUpdate


        #endregion

        #region Remove...

        public ItemPedido RemoveItemPedido(ItemPedido itemPedido)
        {
            itemPedido = CheckIfReadyToRemove(itemPedido);
            if (itemPedido.ListaErros.Count > 0)
                return itemPedido;

            var totalItensNoPedido = itemPedido.Pedido.ItensPedido.Count;

            if(totalItensNoPedido > 1)
                _repositoryPedido.RemoveItemPedido(itemPedido);
            else
            {
                _repositoryPedido.Remove(itemPedido.Pedido);
            }

            return itemPedido;

        } //RemoveItemPedido

        private ItemPedido CheckIfReadyToRemove(ItemPedido itemPedido)
        {

            return itemPedido;

        } //CheckIfReadyToRemove




        #endregion

        #region Get...


        public ItemPedido GetItemPedidoById(int id)
        {
            return _repositoryPedido.GetItemPedidoById(id);
        } //GetItemPedidoById

        public IEnumerable<ItemPedido> GetAllItensPedido(int idPedido)
        {
            return _repositoryPedido.GetAllItensPedido(idPedido);
        } //GetItensPedido

        public IEnumerable<ItemPedido> SearchItensPedido(Expression<Func<ItemPedido, bool>> predicate)
        {
            return _repositoryPedido.SearchItensPedido(predicate);
        } //SearchItensPedido


        #endregion

        public void Dispose()
        {
            _repositoryPedido.Dispose();
            GC.SuppressFinalize(this);
        } //Dispose

    } //class
} //namespace
