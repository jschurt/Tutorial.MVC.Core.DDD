using Domain.Entities.AggregationPedido;
using Domain.Interfaces.Repository.Aggregation;
using Domain.Interfaces.Services.Aggregation;
using System;
using System.Collections.Generic;
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

        #region CRUD...

        public ItemPedido AddItemPedido(ItemPedido itemPedido)
        {
            _repositoryPedido.AddItemPedido(itemPedido);
            return itemPedido;

        } //AddItemPedido

        public ItemPedido UpdateItemPedido(ItemPedido itemPedido)
        {
            _repositoryPedido.UpdateItemPedido(itemPedido);
            return itemPedido;

        } //UpdateItemPedido

        public ItemPedido RemoveItemPedido(ItemPedido itemPedido)
        {
            _repositoryPedido.RemoveItemPedido(itemPedido);
            return itemPedido;

        } //RemovetemPedido

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
