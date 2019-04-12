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
    public class RepositoryProdutos : Repository<Produto>, IRepositoryProduto
    {

        public RepositoryProdutos(ContextEF _context) : base(_context)
        { } //constructor

        public override IEnumerable<Produto> GetAll()
        {
            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Produtos JOIN Fornecedores ON Produtos.idFornecedor = Fornecedores.idFornecedor ORDER BY Produto.id DESC");

            var produtos = _context
                .Database
                .GetDbConnection()
                //Em .Query<Classe1, Classe2, ClasseRetorno>
                .Query<Produto, Fornecedor, Produto>(query.ToString(),
                (P, F) => {

                    //Aqui estou dizendo que o objeto Fornecedor da classe Produto
                    //ira receber o Fornecedor
                    P.Fornecedor = F;
                    return P;
                });

            return produtos;

        } //GetAll

        public override Produto GetById(int id)
        {

            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Produtos JOIN Fornecedores ON Produtos.idFornecedor = Fornecedores.idFornecedor WHERE Produtos.id = @prmId ");

            var produtos = _context
                .Database
                .GetDbConnection()
                //Em .Query<Classe1, Classe2, ClasseRetorno>
                .Query<Produto, Fornecedor, Produto>(query.ToString(),
                (P, F) => {

                    //Aqui estou dizendo que o objeto Fornecedor da classe Produto
                    //ira receber o Fornecedor
                    P.Fornecedor = F;
                    return P;
                }, 
                new { prmId = id }
                ).FirstOrDefault();

            return produtos;

        } //GetById


        public Produto GetByApelido(string apelido)
        {
            //return _context.Set<Produto>().Include(p => p.Fornecedor).AsNoTracking().Where(p => p.Apelido == apelido).FirstOrDefault();

            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Produtos JOIN Fornecedores ON Produtos.idFornecedor = Fornecedores.idFornecedor WHERE Produtos.Apelido = @prmApelido ");

            var produtos = _context
                .Database
                .GetDbConnection()
                //Em .Query<Classe1, Classe2, ClasseRetorno>
                .Query<Produto, Fornecedor, Produto>(query.ToString(),
                (P, F) => {

                    //Aqui estou dizendo que o objeto Fornecedor da classe Produto
                    //ira receber o Fornecedor
                    P.Fornecedor = F;
                    return P;
                },
                new { prmApelido = apelido }
                ).FirstOrDefault();

            return produtos;

        } //GetByApelido

        public Produto GetByNome(string nome)
        {
            //return _context.Set<Produto>().Include(p => p.Fornecedor).AsNoTracking().Where(p => p.Nome == nome).FirstOrDefault();

            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Produtos JOIN Fornecedores ON Produtos.idFornecedor = Fornecedores.idFornecedor WHERE Produtos.Nome = @prmNome ");

            var produtos = _context
                .Database
                .GetDbConnection()
                //Em .Query<Classe1, Classe2, ClasseRetorno>
                .Query<Produto, Fornecedor, Produto>(query.ToString(),
                (P, F) => {

                    //Aqui estou dizendo que o objeto Fornecedor da classe Produto
                    //ira receber o Fornecedor
                    P.Fornecedor = F;
                    return P;
                },
                new { prmNome = nome }
                ).FirstOrDefault();

            return produtos;

        } //GetByNome

    } //class

} //namespace
