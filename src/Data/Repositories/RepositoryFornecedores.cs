using Dapper;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class RepositoryFornecedores : Repository<Fornecedor>, IRepositoryFornecedor
    {

        public RepositoryFornecedores(ContextEF _context) : base(_context)
        { } //constructor

        public override IEnumerable<Fornecedor> GetAll()
        {
            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Fornecedores ORDER BY id DESC");

            return _context
                .Database
                .GetDbConnection()
                .Query<Fornecedor>(query.ToString());

        } //GetAll

        public override Fornecedor GetById(int id)
        {
            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Fornecedores WHERE id=@prmId");

            var fornecedor = _context
                .Database
                .GetDbConnection()
                .Query<Fornecedor>(query.ToString(), new { prmId = id })
                .FirstOrDefault();

            return fornecedor;

        } //GetById

        public Fornecedor GetByApelido(string apelido)
        {
            //Via EF (menos performatico)
            //return _context.Set<Fornecedor>().AsNoTracking().Where(c => c.Apelido == apelido).FirstOrDefault();

            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Fornecedores WHERE Apelido=@prmApelido");

            var fornecedor = _context
                .Database
                .GetDbConnection()
                .Query<Fornecedor>(query.ToString(), new { prmApelido = apelido })
                .FirstOrDefault();

            return fornecedor;

        } //GetByApelido

        public Fornecedor GetByCnpjCpf(string cpfcnpj)
        {
            //Via EF (menos performatico)
            //return _context.Set<Fornecedor>().AsNoTracking().Where(c => c.CpfCnpj.Numero == cpfcnpj).FirstOrDefault();

            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Fornecedores WHERE CpfCnpj=@prmCpfCnpj");

            var fornecedor = _context
                .Database
                .GetDbConnection()
                .Query<Fornecedor>(query.ToString(), new { prmCpfCnpj = cpfcnpj })
                .FirstOrDefault();

            return fornecedor;

        } //GetByCnpjCpf

    } //class
} //namespace
