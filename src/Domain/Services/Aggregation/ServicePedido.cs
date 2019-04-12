using Domain.Entities.AggregationPedido;
using Domain.Interfaces.Repository.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Services.Aggregation
{
    public class ServicePedido : IServicePedido
    {

        protected readonly IRepositoryPedido _repositoryPedido;

        public ServicePedido(IRepositoryPedido repositoryPedido)
        {
            _repositoryPedido = repositoryPedido;
        } //constructor

        #region Crud...

        public Pedido Add(Pedido pedido)
        {
            _repositoryPedido.Add(pedido);
            return pedido;
        } //Add

        public Pedido Update(Pedido pedido)
        {
            _repositoryPedido.Update(pedido);
            return pedido;
        } //Update

        public Pedido Remove(Pedido pedido)
        {
            _repositoryPedido.Remove(pedido);
            return pedido;
        } //Remove

        #endregion

        #region Get...

        public IEnumerable<Pedido> GetAll()
        {
            return _repositoryPedido.GetAll();
        } //GetAll

        public Pedido GetById(int id)
        {
            return _repositoryPedido.GetById(id);
        } //GetById

        
        public IEnumerable<Pedido> Search(Expression<Func<Pedido, bool>> predicate)
        {
            return _repositoryPedido.Search(predicate);
        } //Search

        #endregion

        public void Dispose()
        {
            _repositoryPedido.Dispose();
            GC.SuppressFinalize(this);
        } //Dispose



    } //class
} //namespace
