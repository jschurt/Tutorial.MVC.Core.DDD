using Application.ViewModels;
using System;

namespace Application.Interfaces
{
    public interface IApplicationFornecedor : IApplicationGenericCrud<FornecedorViewModel>, IDisposable
    {

        FornecedorViewModel GetByCpfCnpj(string cpfcnpj);
        FornecedorViewModel GetByApelido(string apelido);

    } //interface

} //namespace
