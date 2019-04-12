using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IServiceCliente : IServiceGenericCrud<Cliente>, IDisposable
    {
        Cliente GetByCpfCnpj(string cpfcnpj);
        Cliente GetByApelido(string apelido);

    } //interface
} //namespace
