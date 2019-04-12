using Domain.Entities;
using System;

namespace Domain.Interfaces.Services
{
    public interface IServiceFornecedor : IServiceGenericCrud<Fornecedor>, IDisposable
    {

        Fornecedor GetByCpfCnpj(string cpfcnpj);
        Fornecedor GetByApelido(string apelido);

    } //interface
} //namespace
