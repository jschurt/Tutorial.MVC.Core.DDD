using Application.ViewModels;
using System;

namespace Application.Interfaces.Aggregation
{
    public interface IApplicationPedido : IApplicationGenericCrud<PedidoViewModel>, IDisposable
    {
    } //interface
} //namespace
