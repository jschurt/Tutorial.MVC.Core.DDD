using Application.Interfaces.Aggregation;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities.AggregationPedido;
using Domain.Interfaces.Repository.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Services
{
    public class ApplicationPedido : IApplicationPedido
    {

        protected readonly IServicePedido _servicePedido;
        protected readonly IMapper _mapper;

        public ApplicationPedido(IServicePedido servicePedido, IMapper mapper)
        {
            _servicePedido = servicePedido;
            _mapper = mapper;
        } //constructor

        public PedidoViewModel Add(PedidoViewModel obj)
        {

            var pedidoDomain = _mapper.Map<Pedido>(obj);
            pedidoDomain = _servicePedido.Add(pedidoDomain);

            return _mapper.Map<PedidoViewModel>(pedidoDomain);

        } //Add

        public PedidoViewModel Update(PedidoViewModel obj)
        {

            var pedidoDomain = _mapper.Map<Pedido>(obj);
            pedidoDomain = _servicePedido.Update(pedidoDomain);

            return _mapper.Map<PedidoViewModel>(pedidoDomain);

        } //Update

        public PedidoViewModel Remove(PedidoViewModel obj)
        {

            var pedidoDomain = _mapper.Map<Pedido>(obj);
            pedidoDomain = _servicePedido.Remove(pedidoDomain);

            return _mapper.Map<PedidoViewModel>(pedidoDomain);

        } //Remove


        public IEnumerable<PedidoViewModel> GetAll()
        {

            var pedidosDomain = _servicePedido.GetAll();

            return _mapper.Map<IEnumerable<PedidoViewModel>>(pedidosDomain);

        } //GetAll

        public PedidoViewModel GetById(int id)
        {

            var pedidoDomain = _servicePedido.GetById(id);

            return _mapper.Map<PedidoViewModel>(pedidoDomain);

        } //GetByOd

        public IEnumerable<PedidoViewModel> Search(Expression<Func<PedidoViewModel, bool>> predicate)
        {
            throw new NotImplementedException();
        } //Search

        public void Dispose()
        {

            _servicePedido.Dispose();

        } //Dispose


    } //class
} //namespace
