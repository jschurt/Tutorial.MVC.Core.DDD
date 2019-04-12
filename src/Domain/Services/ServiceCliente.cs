using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository.Aggregation;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class ServiceCliente : IServiceCliente
    {

        protected readonly IRepositoryCliente _repositoryCliente;
        protected readonly IServicePedido _servicePedido;

        public ServiceCliente(IRepositoryCliente repositoryCliente, IServicePedido servicePedido)
        {
            _repositoryCliente = repositoryCliente;
            _servicePedido = servicePedido;
        } //constructor

        #region Add...

        public Cliente Add(Cliente cliente)
        {

            cliente = CheckIfReadyToAdd(cliente);
            if (cliente.ListaErros.Count != 0)
                return cliente;

            _repositoryCliente.Add(cliente);
            return cliente;

        } //Add

        private Cliente CheckIfReadyToAdd(Cliente cliente)
        {
            if (!cliente.EstaConsistente())
                return cliente;

            cliente = CheckApelidoExistInsert(cliente);
            cliente = CheckCpfCnpjExistInsert(cliente);

            return cliente;

        } //CheckIfReadyToAdd

        private Cliente CheckApelidoExistInsert(Cliente cliente)
        {

            if (this.GetByApelido(cliente.Apelido) != null)
                cliente.ListaErros.Add("Apelido ja existente.");

            return cliente;

        } //CheckApelidoExistInsert

        private Cliente CheckCpfCnpjExistInsert(Cliente cliente)
        {

            if (this.GetByCpfCnpj(cliente.CpfCnpj.Numero) != null)
                cliente.ListaErros.Add("CPF/CNPJ ja existente.");

            return cliente;

        } //CheckCpfCnpjExistInsert

        #endregion

        #region Update...

        public Cliente Update(Cliente cliente)
        {

            cliente = CheckIfReadyToUpdate(cliente);
            if (cliente.ListaErros.Count != 0)
                return cliente;

            _repositoryCliente.Update(cliente);
            return cliente;

        } //Update

        private Cliente CheckIfReadyToUpdate(Cliente cliente)
        {
            if (!cliente.EstaConsistente())
                return cliente;

            cliente = CheckApelidoExistUpdate(cliente);
            cliente = CheckCpfCnpjExistUpdate(cliente);

            return cliente;

        } //CheckIfReadyToUpdate

        private Cliente CheckApelidoExistUpdate(Cliente cliente)
        {
            var result = GetByApelido(cliente.Apelido);
            if (result  != null && result.Id != cliente.Id)
                cliente.ListaErros.Add("Apelido ja existente.");

            return cliente;

        } //CheckApelidoExistUpdate

        private Cliente CheckCpfCnpjExistUpdate(Cliente cliente)
        {
            var result = GetByCpfCnpj(cliente.CpfCnpj.Numero);
            if (result != null && result.Id != cliente.Id)
                cliente.ListaErros.Add("CPF/CNPJ ja existente.");

            return cliente;

        } //CheckCpfCnpjExistUpdate

        #endregion

        #region Remove...

        public Cliente Remove(Cliente cliente)
        {

            cliente = CheckIfReadyToRemove(cliente);
            if (cliente.ListaErros.Count != 0)
                return cliente;

            _repositoryCliente.Remove(cliente);
            return cliente;

        } //Remove

        private Cliente CheckIfReadyToRemove(Cliente cliente)
        {

            cliente = CheckIfClienteInUse(cliente);

            return cliente;

        } //CheckIfReadyToRemove


        private Cliente CheckIfClienteInUse(Cliente cliente)
        {
            var pedidos = _servicePedido.Search(p => p.idCliente == cliente.Id);
            if (pedidos.Any())
                cliente.ListaErros.Add("Exist(m) pedido(s) associado(s) a este cliente. Exclusao nao permitida.");

            return cliente;

        } //CheckIfClienteInUse

        #endregion

        #region Get...

        public IEnumerable<Cliente> GetAll()
        {
            return _repositoryCliente.GetAll();
        } //GetAll

        public Cliente GetById(int id)
        {
            return _repositoryCliente.GetById(id);
        } //GetById

        public Cliente GetByApelido(string apelido)
        {
            return _repositoryCliente.GetByApelido(apelido);
        } //GetByApelido

        public Cliente GetByCpfCnpj(string cpfcnpj)
        {
            return _repositoryCliente.GetByCnpjCpf(cpfcnpj);
        } //GetByCpfCnpj

        public IEnumerable<Cliente> Search(Expression<Func<Cliente, bool>> predicate)
        {
            return _repositoryCliente.Search(predicate);
        } //Search

        #endregion

        public void Dispose()
        {
            _repositoryCliente.Dispose();
            _servicePedido.Dispose();
            GC.SuppressFinalize(this);
        } //Dispose


    } //class
}
