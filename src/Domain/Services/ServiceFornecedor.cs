using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Services
{
    public class ServiceFornecedor : IServiceGenericCrud<Fornecedor>
    {

        protected readonly IRepositoryFornecedor _repositoryFornecedor;

        public ServiceFornecedor(IRepositoryFornecedor repositoryFornecedor)
        {
            _repositoryFornecedor = repositoryFornecedor;
        } //constructor

        #region Crud...

        public Fornecedor Add(Fornecedor fornecedor)
        {
            _repositoryFornecedor.Add(fornecedor);
            return fornecedor;
        } //Add

        public Fornecedor Update(Fornecedor fornecedor)
        {
            _repositoryFornecedor.Update(fornecedor);
            return fornecedor;
        } //Update

        public Fornecedor Remove(Fornecedor fornecedor)
        {
            _repositoryFornecedor.Remove(fornecedor);
            return fornecedor;
        } //Remove

        #endregion

        #region Get...

        public IEnumerable<Fornecedor> GetAll()
        {
            return _repositoryFornecedor.GetAll();
        } //GetAll

        public Fornecedor GetById(int id)
        {
            return _repositoryFornecedor.GetById(id);
        } //GetById

        public Fornecedor GetByApelido(string apelido)
        {
            return _repositoryFornecedor.GetByApelido(apelido);
        } //GetByApelido

        public Fornecedor GetByCpfCnpj(string cpfcnpj)
        {
            return _repositoryFornecedor.GetByCnpjCpf(cpfcnpj);
        } //GetByCpfCnpj

        public IEnumerable<Fornecedor> Search(Expression<Func<Fornecedor, bool>> predicate)
        {
            return _repositoryFornecedor.Search(predicate);
        } //Search

        #endregion

        public void Dispose()
        {
            _repositoryFornecedor.Dispose();
            GC.SuppressFinalize(this);
        } //Dispose

    } //class
} //namespace
