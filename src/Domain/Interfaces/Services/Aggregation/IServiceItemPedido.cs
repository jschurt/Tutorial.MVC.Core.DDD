using Domain.Entities.AggregationPedido;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Services.Aggregation
{
    public interface IServiceItemPedido : IDisposable
    {
        ItemPedido AddItemPedido(ItemPedido itemPedido);
        ItemPedido UpdateItemPedido(ItemPedido itemPedido);
        ItemPedido RemoveItemPedido(ItemPedido itemPedido);

        ItemPedido GetItemPedidoById(int id);
        IEnumerable<ItemPedido> GetAllItensPedido(int idPedido);

    } //interface
} //namespace
