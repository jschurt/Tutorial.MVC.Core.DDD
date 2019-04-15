using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class ServiceProduto : IServiceProduto
    {

        protected readonly IRepositoryProduto _repositoryProduto;
        protected readonly IServiceItemPedido _serviceItemPedido;

        public ServiceProduto(IRepositoryProduto repositoryProduto, IServiceItemPedido serviceItemPedido)
        {
            _repositoryProduto = repositoryProduto;
            _serviceItemPedido = serviceItemPedido;
        }  //Constructor

        #region Add...

        public Produto Add(Produto produto)
        {

            produto = CheckIfReadyToAdd(produto);
            if (produto.ListaErros.Count != 0)
                return produto;

            _repositoryProduto.Add(produto);
            return produto;

        } //Add

        private Produto CheckIfReadyToAdd(Produto produto)
        {
            if (!produto.EstaConsistente())
                return produto;

            produto = CheckApelidoExistInsert(produto);
            produto = CheckNomeExistInsert(produto);

            return produto;

        } //CheckIfReadyToAdd

        private Produto CheckApelidoExistInsert(Produto produto)
        {

            if (this.GetByApelido(produto.Apelido) != null)
                produto.ListaErros.Add("Apelido ja existente.");

            return produto;

        } //CheckApelidoExistInsert

        private Produto CheckNomeExistInsert(Produto produto)
        {

            if (this.GetByNome(produto.Nome) != null)
                produto.ListaErros.Add("Nome ja existente.");

            return produto;

        } //CheckNomeExistInsert


        #endregion

        #region Update...

        public Produto Update(Produto produto)
        {

            produto = CheckIfReadyToUpdate(produto);
            if (produto.ListaErros.Count != 0)
                return produto;

            _repositoryProduto.Update(produto);
            return produto;

        } //Update

        private Produto CheckIfReadyToUpdate(Produto produto)
        {
            if (!produto.EstaConsistente())
                return produto;

            produto = CheckApelidoExistUpdate(produto);
            produto = CheckNomeExistUpdate(produto);

            return produto;

        } //CheckIfReadyToUpdate

        private Produto CheckApelidoExistUpdate(Produto produto)
        {
            var result = GetByApelido(produto.Apelido);
            if (result != null && result.Id != produto.Id)
                produto.ListaErros.Add("Apelido ja existente.");

            return produto;

        } //CheckApelidoExistUpdate

        private Produto CheckNomeExistUpdate(Produto produto)
        {
            var result = GetByNome(produto.Nome);
            if (result != null && result.Id != produto.Id)
                produto.ListaErros.Add("Nome ja existente.");

            return produto;

        } //CheckNomeExistUpdate


        #endregion

        #region Remove

        public Produto Remove(Produto produto)
        {

            produto = CheckIfProdutoReadyToRemove(produto);
            if (produto.ListaErros.Count != 0)
                return produto;

            _repositoryProduto.Remove(produto);
            return produto;

        } //Remove

        private Produto CheckIfProdutoReadyToRemove(Produto produto)
        {

            produto = CheckIfProdutoInUse(produto);

            return produto;

        } //CheckIfReadyToRemove


        private Produto CheckIfProdutoInUse(Produto produto)
        {
            var itensPedido = _serviceItemPedido.SearchItensPedido(ip => ip.IdProduto == produto.Id);
            if (itensPedido.Any())
                produto.ListaErros.Add("Exist(m) pedido(s) associado(s) a este produto. Exclusao nao permitida.");

            return produto;

        } //CheckIfProdutoInUse


        #endregion

        #region Get...

        public IEnumerable<Produto> GetAll()
        {
            return _repositoryProduto.GetAll();
        } //GetAll

        public Produto GetById(int id)
        {
            return _repositoryProduto.GetById(id);
        } //GetById

        public Produto GetByApelido(string apelido)
        {
            return _repositoryProduto.GetByApelido(apelido);
        } //GetByApelido

        public Produto GetByNome(string nome)
        {
            return _repositoryProduto.GetByNome(nome);
        } //GetByCpfCnpj

        public IEnumerable<Produto> Search(Expression<Func<Produto, bool>> predicate)
        {
            return _repositoryProduto.Search(predicate);
        } //Search

        #endregion

        public void Dispose()
        {
            _repositoryProduto.Dispose();
            GC.SuppressFinalize(this);
        } //Dispose


    } //class
} //namespace
