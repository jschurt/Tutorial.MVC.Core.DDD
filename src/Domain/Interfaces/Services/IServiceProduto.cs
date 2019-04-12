using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IServiceProduto : IServiceGenericCrud<Produto>, IDisposable
    {

        Produto GetByNome(string nome);
        Produto GetByApelido(string apelido);

    } //interface
} //namespace
