using Domain.Entities;

namespace Domain.Interfaces.Repository
{
    public interface IRepositoryProduto : IRepository<Produto>
    {

        Produto GetByNome(string nome);
        Produto GetByApelido(string apelido);

    } //interface

} //namespace
