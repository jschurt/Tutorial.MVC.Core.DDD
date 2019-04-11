using Domain.Entities;

namespace Domain.Interfaces.Repository
{
    public interface IRepositoryFornecedor : IRepository<Fornecedor>
    {

        Fornecedor GetByApelido(string apelido);

        Fornecedor GetByCnpjCpf(string cpfcnpj);


    } //interface
} //namespace
