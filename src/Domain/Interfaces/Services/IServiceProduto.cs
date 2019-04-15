using Domain.Entities;
using System;

namespace Domain.Interfaces.Services
{
    public interface IServiceProduto : IServiceGenericCrud<Produto>, IDisposable
    {

        Produto GetByNome(string nome);
        Produto GetByApelido(string apelido);

    } //interface
} //namespace
