using Domain.Entities.AggregationPedido;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repository.Aggregation
{
    public interface IRepositoryPedido : IRepository<Pedido>
    {
        void AddItemPedido(ItemPedido item);
        void UpdateItemPedido(ItemPedido item);
        void RemoveItemPedido(ItemPedido item);


        ItemPedido GetItemPedidoById(int id);
        IEnumerable<ItemPedido> GetAllItensPedido(int idPedido);
        IEnumerable<ItemPedido> SearchItensPedido(Expression<Func<ItemPedido, bool>> predicate);

    } //interface

} //namespace
