using Domain.Entities.AggregationPedido;
using System.Collections.Generic;

namespace Domain.Interfaces.Repository.Aggregation
{
    public interface IRepositoryPedido : IRepository<Pedido>
    {
        void AddItemPedido(ItemPedido item);
        void UpdateItemPedido(ItemPedido item);
        void RemoveItemPedido(ItemPedido item);

        ItemPedido GetItemPedidoById(int id);
        IEnumerable<ItemPedido> GetAllItensPedido(int idPedido);

    } //interface

} //namespace
