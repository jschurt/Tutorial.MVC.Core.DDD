using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repositories
{
    public class RepositoryClientes : Repository<Cliente>, IRepositoryCliente
    {

        public RepositoryClientes(ContextEF _context) : base(_context)
        { } //constructor


        public Cliente GetByApelido(string apelido)
        {
            //Via EF (menos performatico)
            return _context.Set<Cliente>().AsNoTracking().Where(c => c.Apelido == apelido).FirstOrDefault();
        } //GetByApelido

        public Cliente GetByCnpjCpf(string cpfcnpj)
        {
            //Via EF (menos performatico)
            return _context.Set<Cliente>().AsNoTracking().Where(c => c.CpfCnpj.Numero == cpfcnpj).FirstOrDefault();

        } //GetByCnpjCpf

    } //class
} //namespace
