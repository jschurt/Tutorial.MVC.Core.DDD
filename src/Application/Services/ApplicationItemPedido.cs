using Application.Interfaces.Aggregation;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities.AggregationPedido;
using Domain.Interfaces.Services.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Services
{
    public class ApplicationItemPedido : IApplicationItemPedido
    {

        protected readonly IServiceItemPedido _serviceItemPedido;
        protected readonly IMapper _mapper;

        public ApplicationItemPedido(IServiceItemPedido servicePedido, IMapper mapper)
        {
            _serviceItemPedido = servicePedido;
            _mapper = mapper;
        } //constructor

        public ItemPedidoViewModel AddItemPedido(ItemPedidoViewModel itemPedido)
        {

            var itemPedidoDomain = _mapper.Map<ItemPedido>(itemPedido);
            itemPedidoDomain = _serviceItemPedido.AddItemPedido(itemPedidoDomain);
            return _mapper.Map<ItemPedidoViewModel>(itemPedidoDomain);

        } //AddItemPedido

        public ItemPedidoViewModel UpdateItemPedido(ItemPedidoViewModel itemPedido)
        {
            var itemPedidoDomain = _mapper.Map<ItemPedido>(itemPedido);
            itemPedidoDomain = _serviceItemPedido.UpdateItemPedido(itemPedidoDomain);

            return _mapper.Map<ItemPedidoViewModel>(itemPedidoDomain);

        } //UpdateItemPedido

        public ItemPedidoViewModel RemoveItemPedido(ItemPedidoViewModel itemPedido)
        {
            var itemPedidoDomain = _mapper.Map<ItemPedido>(itemPedido);
            itemPedidoDomain = _serviceItemPedido.RemoveItemPedido(itemPedidoDomain);

            return _mapper.Map<ItemPedidoViewModel>(itemPedidoDomain);

        } //RemoveItemPedido

        public IEnumerable<ItemPedidoViewModel> GetAllItensPedido(int idPedido)
        {

            var itensPedidoDomain = _serviceItemPedido.GetAllItensPedido(idPedido);

            return _mapper.Map<IEnumerable<ItemPedidoViewModel>>(itensPedidoDomain);

        } //GetAllItensPedido

        public ItemPedidoViewModel GetItemPedidoById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemPedidoViewModel> SearchItensPedido(Expression<Func<ItemPedidoViewModel, bool>> predicate)
        {
            throw new NotImplementedException();
        } //Search

        public void Dispose()
        {

            _serviceItemPedido.Dispose();

        } //Dispose


    } //class
} //namespace
