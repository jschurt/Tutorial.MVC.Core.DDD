using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repositories
{
    public class RepositoryFornecedores : Repository<Fornecedor>, IRepositoryFornecedor
    {

        public RepositoryFornecedores(ContextEF _context) : base(_context)
        { } //constructor

        public Fornecedor GetByApelido(string apelido)
        {
            return _context.Set<Fornecedor>().AsNoTracking().Where(f => f.Apelido == apelido).FirstOrDefault();
        } //GetByApelido

        public Fornecedor GetByCnpjCpf(string cpfcnpj)
        {
            return _context.Set<Fornecedor>().AsNoTracking().Where(f => f.CpfCnpj.Numero == cpfcnpj).FirstOrDefault();
        } //GetByCnpjCpf

    } //class
} //namespace
