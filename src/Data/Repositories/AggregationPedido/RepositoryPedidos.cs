using Data.Context;
using Domain.Entities.AggregationPedido;
using Domain.Interfaces.Repository.AggregationPedido;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories.AggregationPedido
{
    public class RepositoryPedidos : Repository<Pedido>, IRepositoryPedido
    {

        public RepositoryPedidos(ContextEF _context) : base(_context)
        { } //constructor


        public void AddItemPedido(ItemPedido item)
        {
            _context.Set<ItemPedido>().Add(item);
        } //AddItemPedido

        public void UpdateItemPedido(ItemPedido item)
        {
            _context.Set<ItemPedido>().Update(item);
        } //UpdateItemPedido


        public void RemoveItemPedido(ItemPedido item)
        {
            _context.Set<ItemPedido>().Remove(item);
        } //RemoveItemPedido


        public IEnumerable<ItemPedido> GetAllItensPedido(int idPedido)
        {
            return _context.Set<ItemPedido>().Include(ip => ip.Produto).Where(ip => ip.IdPedido == idPedido).OrderBy(ip => ip.Produto.Apelido);
        } //GetAllItensPedido

        public ItemPedido GetItemPedidoById(int id)
        {
            return _context.Set<ItemPedido>().AsNoTracking().FirstOrDefault(ip => ip.Id == id);
        } //GetItemPedidoById


    } //class
} //namespace
