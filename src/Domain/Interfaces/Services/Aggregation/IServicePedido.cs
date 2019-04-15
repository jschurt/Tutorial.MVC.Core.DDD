using Domain.Entities.AggregationPedido;
using Domain.Interfaces.Services;
using System;

namespace Domain.Interfaces.Repository.Aggregation
{
    public interface IServicePedido : IServiceGenericCrud<Pedido>, IDisposable
    {
    } //interface
} //namespace
