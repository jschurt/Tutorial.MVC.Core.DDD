using Dapper;
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
    public class RepositoryClientes : Repository<Cliente>, IRepositoryCliente
    {

        public RepositoryClientes(ContextEF _context) : base(_context)
        { } //constructor

        public override IEnumerable<Cliente> GetAll()
        {
            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Clientes ORDER BY id DESC");

            return _context
                .Database
                .GetDbConnection()
                .Query<Cliente>(query.ToString());

        } //GetAll

        public override Cliente GetById(int id)
        {
            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Clientes WHERE id=@prmId");

            var cliente = _context
                .Database
                .GetDbConnection()
                .Query<Cliente>(query.ToString(), new { prmId = id })
                .FirstOrDefault();

            return cliente;

        } //GetById

        public Cliente GetByApelido(string apelido)
        {
            //Via EF (menos performatico)
            //return _context.Set<Cliente>().AsNoTracking().Where(c => c.Apelido == apelido).FirstOrDefault();

            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Clientes WHERE Apelido=@prmApelido");

            var cliente = _context
                .Database
                .GetDbConnection()
                .Query<Cliente>(query.ToString(), new { prmApelido = apelido })
                .FirstOrDefault();

            return cliente;

        } //GetByApelido

        public Cliente GetByCnpjCpf(string cpfcnpj)
        {
            //Via EF (menos performatico)
            //return _context.Set<Cliente>().AsNoTracking().Where(c => c.CpfCnpj.Numero == cpfcnpj).FirstOrDefault();

            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Clientes WHERE CpfCnpj=@prmCpfCnpj");

            var cliente = _context
                .Database
                .GetDbConnection()
                .Query<Cliente>(query.ToString(), new { prmCpfCnpj = cpfcnpj })
                .FirstOrDefault();

            return cliente;


        } //GetByCnpjCpf

    } //class
} //namespace
