using Application.ViewModels;
using System;

namespace Application.Interfaces
{
    public interface IApplicationCliente : IApplicationGenericCrud<ClienteViewModel>, IDisposable
    {

        ClienteViewModel GetByCpfCnpj(string cpfcnpj);
        ClienteViewModel GetByApelido(string apelido);

    } //interface

} //namespace
