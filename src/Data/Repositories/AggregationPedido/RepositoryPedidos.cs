using Dapper;
using Data.Context;
using Domain.Entities;
using Domain.Entities.AggregationPedido;
using Domain.Interfaces.Repository.AggregationPedido;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories.AggregationPedido
{
    public class RepositoryPedidos : Repository<Pedido>, IRepositoryPedido
    {

        public RepositoryPedidos(ContextEF _context) : base(_context)
        { } //constructor

        #region ItensPedido...

        public void AddItemPedido(ItemPedido item)
        {
            _context.Set<ItemPedido>().Add(item);
        } //AddItemPedido

        public void UpdateItemPedido(ItemPedido item)
        {
            _context.Set<ItemPedido>().Update(item);
        } //UpdateItemPedido


        public void RemoveItemPedido(ItemPedido item)
        {
            _context.Set<ItemPedido>().Remove(item);
        } //RemoveItemPedido

        public ItemPedido GetItemPedidoById(int id)
        {
            //return _context.Set<ItemPedido>().AsNoTracking().FirstOrDefault(ip => ip.Id == id);

            StringBuilder query = new StringBuilder();
            query.AppendLine(@"
                SELECT *
                FROM
                  Pedidos
                INNER JOIN Clientes
                  ON Clientes.Id = Pedidos.IdCliente
                INNER JOIN ItensPedido
                  ON ItensPedido.IdPedido = Pedidos.Id
                INNER JOIN Produtos
                  ON Produtos.Id = ItensPedido.IdProduto
               INNER JOIN Fornecedores
                 ON Fornecedores.Id = Produtos.IdFornecedor
               WHERE
                  ItensPedido.Id = @prmId
                ");

            var itemPedido = _context
                .Database
                .GetDbConnection()
                .Query<Pedido, Cliente, ItemPedido, Produto, Fornecedor, ItemPedido>(
                    query.ToString(),
                    (pedido, cliente, itempedido, produto, fornecedor) => {

                        pedido.Cliente = cliente;
                        itempedido.Pedido = pedido;
                        produto.Fornecedor = fornecedor;
                        itempedido.Produto = produto;
                        return itempedido;

                    },
                    new { prmId = id }
                ).FirstOrDefault();

            return itemPedido;

        } //GetItemPedidoById

        public IEnumerable<ItemPedido> GetAllItensPedido(int idPedido)
        {
            //return _context.Set<ItemPedido>().Include(ip => ip.Produto).Where(ip => ip.IdPedido == idPedido).OrderBy(ip => ip.Produto.Apelido);

            StringBuilder query = new StringBuilder();
            query.AppendLine(@"
                SELECT *
                FROM
                  Pedidos
                INNER JOIN Clientes
                  ON Clientes.Id = Pedidos.IdCliente
                INNER JOIN ItensPedido
                  ON ItensPedido.IdPedido = Pedidos.Id
                INNER JOIN Produtos
                  ON Produtos.Id = ItensPedido.IdProduto
               INNER JOIN Fornecedores
                 ON Fornecedores.Id = Produtos.IdFornecedor
               WHERE
                  ItensPedido.IdPedido = @prmIdPedido
                ");

            var itensPedido = _context
                .Database
                .GetDbConnection()
                .Query<Pedido, Cliente, ItemPedido, Produto, Fornecedor, ItemPedido>(
                    query.ToString(),
                    (pedido, cliente, itempedido, produto, fornecedor) => {

                        pedido.Cliente = cliente;
                        itempedido.Pedido = pedido;
                        produto.Fornecedor = fornecedor;
                        itempedido.Produto = produto;
                        return itempedido;

                    },
                    new { prmIdPedido = idPedido}
                );

            return itensPedido;

        } //GetAllItensPedido

        #endregion

        #region Pedido...

        public override IEnumerable<Pedido> GetAll()
        {

            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * 
                           FROM
                             Pedidos
                           JOIN
                             Clientes
                            ON Pedidos.idCliente = Clientes.id 
                            ORDER BY Pedidos.Id DESC");

            var pedidos = _context
                .Database
                .GetDbConnection()
                .Query<Pedido, Cliente, Pedido>(
                    query.ToString(),
                    (p, c) => {
                        p.Cliente = c;
                        return p;
                    });

            foreach (var item in pedidos)
            {
                var itens = this.GetAllItensPedido(item.Id);
                item.QuantidadeTotalProdutos = itens.Count();
                item.ValorTotalProdutos = itens.Sum(x => x.Produto.Valor);
            } //foreach


            return pedidos;

        } //GetAll

        public override Pedido GetById(int id)
        {

            //Adapting to use Dapper (muito mais performatico do que o EF)
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM Pedidos INNER JOIN Clientes ON Pedidos.idCliente = Clientes.idCliente WHERE Pedidos.id = @prmId ");

            var pedidos = _context
                .Database
                .GetDbConnection()
                //Em .Query<Classe1, Classe2, ClasseRetorno>
                .Query<Pedido, Cliente, Pedido>(query.ToString(),
                (p, c) => {

                    //Aqui estou dizendo que o objeto Cliente da classe Pedido
                    //ira receber o Cliente
                    p.Cliente = c;
                    return p;
                },
                new { prmId = id }
                ).FirstOrDefault();

            return pedidos;

        } //GetById

        #endregion

    } //class
} //namespace
