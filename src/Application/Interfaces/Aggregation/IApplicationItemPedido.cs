using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Interfaces.Aggregation
{
    public interface IApplicationItemPedido : IDisposable
    {
        ItemPedidoViewModel AddItemPedido(ItemPedidoViewModel itemPedido);
        ItemPedidoViewModel UpdateItemPedido(ItemPedidoViewModel itemPedido);
        ItemPedidoViewModel RemoveItemPedido(ItemPedidoViewModel itemPedido);

        ItemPedidoViewModel GetItemPedidoById(int id);
        IEnumerable<ItemPedidoViewModel> GetAllItensPedido(int idPedido);
        IEnumerable<ItemPedidoViewModel> SearchItensPedido(Expression<Func<ItemPedidoViewModel, bool>> predicate);

    } //interface

} //namespace
