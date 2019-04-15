using Application.ViewModels;
using System;

namespace Application.Interfaces
{
    public interface IApplicationProduto : IApplicationGenericCrud<ProdutoViewModel>, IDisposable
    {

        ProdutoViewModel GetByNome(string nome);
        ProdutoViewModel GetByApelido(string apelido);

    } //interface
} //namespace
