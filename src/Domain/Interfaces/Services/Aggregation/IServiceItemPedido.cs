using Domain.Entities.AggregationPedido;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Services.Aggregation
{
    public interface IServiceItemPedido : IDisposable
    {
        ItemPedido AddItemPedido(ItemPedido itemPedido);
        ItemPedido UpdateItemPedido(ItemPedido itemPedido);
        ItemPedido RemoveItemPedido(ItemPedido itemPedido);

        ItemPedido GetItemPedidoById(int id);
        IEnumerable<ItemPedido> GetAllItensPedido(int idPedido);
        IEnumerable<ItemPedido> SearchItensPedido(Expression<Func<ItemPedido, bool>> predicate);

    } //interface
} //namespace
