using Domain.Entities;
using System;

namespace Domain.Interfaces.Services
{
    public interface IServiceCliente : IServiceGenericCrud<Cliente>, IDisposable
    {
        Cliente GetByCpfCnpj(string cpfcnpj);
        Cliente GetByApelido(string apelido);

    } //interface
} //namespace
