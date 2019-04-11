using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class RepositoryProdutos : Repository<Produto>, IRepositoryProduto
    {

        public RepositoryProdutos(ContextEF _context) : base(_context)
        { } //constructor

        public Produto GetByApelido(string apelido)
        {
            return _context.Set<Produto>().AsNoTracking().Where(p => p.Apelido == apelido).FirstOrDefault();
        } //GetByApelido

        public Produto GetByNome(string nome)
        {
            return _context.Set<Produto>().AsNoTracking().Where(p => p.Nome == nome).FirstOrDefault();
        } //GetByNome

    } //class

} //namespace
