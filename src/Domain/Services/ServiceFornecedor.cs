using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class ServiceFornecedor : IServiceGenericCrud<Fornecedor>
    {

        protected readonly IRepositoryFornecedor _repositoryFornecedor;
        protected readonly IServiceProduto _serviceProduto;

        public ServiceFornecedor(IRepositoryFornecedor repositoryFornecedor, IServiceProduto serviceProduto)
        {
            _repositoryFornecedor = repositoryFornecedor;
            _serviceProduto = serviceProduto;
        } //constructor

        #region Add

        public Fornecedor Add(Fornecedor fornecedor)
        {

            fornecedor = CheckIfReadyToAdd(fornecedor);
            if (fornecedor.ListaErros.Count != 0)
                return fornecedor;

            _repositoryFornecedor.Add(fornecedor);
            return fornecedor;

        } //Add

        private Fornecedor CheckIfReadyToAdd(Fornecedor fornecedor)
        {
            if (!fornecedor.EstaConsistente())
                return fornecedor;

            fornecedor = CheckApelidoExistInsert(fornecedor);
            fornecedor = CheckCpfCnpjExistInsert(fornecedor);

            return fornecedor;

        } //CheckIfReadyToAdd

        private Fornecedor CheckApelidoExistInsert(Fornecedor fornecedor)
        {

            if (this.GetByApelido(fornecedor.Apelido) != null)
                fornecedor.ListaErros.Add("Apelido ja existente.");

            return fornecedor;

        } //CheckApelidoExistInsert

        private Fornecedor CheckCpfCnpjExistInsert(Fornecedor fornecedor)
        {

            if (this.GetByCpfCnpj(fornecedor.CpfCnpj.Numero) != null)
                fornecedor.ListaErros.Add("CPF/CNPJ ja existente.");

            return fornecedor;

        } //CheckCpfCnpjExistInsert

        #endregion

        #region Update

        public Fornecedor Update(Fornecedor fornecedor)
        {
            fornecedor = CheckIfReadyToUpdate(fornecedor);
            if (fornecedor.ListaErros.Count != 0)
                return fornecedor;

            _repositoryFornecedor.Update(fornecedor);
            return fornecedor;

        } //Update

        private Fornecedor CheckIfReadyToUpdate(Fornecedor fornecedor)
        {
            if (!fornecedor.EstaConsistente())
                return fornecedor;

            fornecedor = CheckApelidoExistUpdate(fornecedor);
            fornecedor = CheckCpfCnpjExistUpdate(fornecedor);

            return fornecedor;

        } //CheckIfReadyToUpdate

        private Fornecedor CheckApelidoExistUpdate(Fornecedor fornecedor)
        {
            var result = GetByApelido(fornecedor.Apelido);
            if (result != null && result.Id != fornecedor.Id)
                fornecedor.ListaErros.Add("Apelido ja existente.");

            return fornecedor;

        } //CheckApelidoExistUpdate

        private Fornecedor CheckCpfCnpjExistUpdate(Fornecedor fornecedor)
        {
            var result = GetByCpfCnpj(fornecedor.CpfCnpj.Numero);
            if (result != null && result.Id != fornecedor.Id)
                fornecedor.ListaErros.Add("CPF/CNPJ ja existente.");

            return fornecedor;

        } //CheckCpfCnpjExistUpdate


        #endregion

        #region Remove

        public Fornecedor Remove(Fornecedor fornecedor)
        {
            fornecedor = CheckIfReadyToRemove(fornecedor);
            if (fornecedor.ListaErros.Count != 0)
                return fornecedor;

            _repositoryFornecedor.Remove(fornecedor);
            return fornecedor;

        } //Remove

        private Fornecedor CheckIfReadyToRemove(Fornecedor fornecedor)
        {

            fornecedor = CheckIfFornecedorInUse(fornecedor);

            return fornecedor;

        } //CheckIfReadyToRemove


        private Fornecedor CheckIfFornecedorInUse(Fornecedor fornecedor)
        {
            var produtos = _serviceProduto.Search(p => p.idFornecedor == fornecedor.Id);
            if (produtos.Any())
                fornecedor.ListaErros.Add("Exist(m) produto(s) associado(s) a este fornecedor. Exclusao nao permitida.");

            return fornecedor;

        } //CheckIfFornecedorInUse


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
            _serviceProduto.Dispose();
            GC.SuppressFinalize(this);
        } //Dispose

    } //class
} //namespace
