using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Services
{
    public class ServiceProduto : IServiceProduto
    {

        protected readonly IRepositoryProduto _repositoryProduto;
        
        public ServiceProduto(IRepositoryProduto repositoryProduto)
        {
            _repositoryProduto = repositoryProduto;
        } //Constructor

        #region Crud...

        public Produto Add(Produto produto)
        {
            _repositoryProduto.Add(produto);
            return produto;
        } //Add

        public Produto Update(Produto produto)
        {
            _repositoryProduto.Update(produto);
            return produto;
        } //Update

        public Produto Remove(Produto produto)
        {
            _repositoryProduto.Remove(produto);
            return produto;
        } //Remove

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
