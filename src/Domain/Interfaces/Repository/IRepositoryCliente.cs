using Domain.Entities;

namespace Domain.Interfaces.Repository
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        Cliente GetByApelido(string apelido);

        Cliente GetByCnpjCpf(string cpfcnpj);

    } //interface

} //namespace
