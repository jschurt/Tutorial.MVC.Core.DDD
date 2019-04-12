using Domain.Entities.AggregationPedido;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repository.Aggregation
{
    public interface IServicePedido : IServiceGenericCrud<Pedido>, IDisposable
    {
    } //interface
} //namespace
