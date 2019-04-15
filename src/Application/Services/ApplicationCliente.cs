using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using CrossCutting.Extensions;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Services
{
    public class ApplicationCliente : IApplicationCliente
    {

        protected readonly IServiceCliente _serviceCliente;
        protected readonly IMapper _mapper;

        public ApplicationCliente(IServiceCliente serviceCliente, IMapper mapper)
        {
            _serviceCliente = serviceCliente;
            _mapper = mapper;
        } //constructor

        public ClienteViewModel Add(ClienteViewModel obj)
        {

            var clienteDomain = _mapper.Map<Cliente>(obj);
            clienteDomain = _serviceCliente.Add(clienteDomain);

            return _mapper.Map<ClienteViewModel>(clienteDomain);

        } //Add

        public ClienteViewModel Update(ClienteViewModel obj)
        {

            var clienteDomain = _mapper.Map<Cliente>(obj);
            clienteDomain = _serviceCliente.Update(clienteDomain);

            return _mapper.Map<ClienteViewModel>(clienteDomain);

        } //Update

        public ClienteViewModel Remove(ClienteViewModel obj)
        {

            var clienteDomain = _mapper.Map<Cliente>(obj);
            clienteDomain = _serviceCliente.Remove(clienteDomain);

            return _mapper.Map<ClienteViewModel>(clienteDomain);

        } //Remove


        public IEnumerable<ClienteViewModel> GetAll()
        {

            var clientesDomain = _serviceCliente.GetAll();

            return _mapper.Map<IEnumerable<ClienteViewModel>>(clientesDomain);

        } //GetAll

        public ClienteViewModel GetByApelido(string apelido)
        {

            var clienteDomain = _serviceCliente.GetByApelido(apelido);

            return _mapper.Map<ClienteViewModel>(clienteDomain);

        } //GetByApelido

        public ClienteViewModel GetByCpfCnpj(string cpfcnpj)
        {

            var clienteDomain = _serviceCliente.GetByCpfCnpj(cpfcnpj.SomenteNumeros());

            return _mapper.Map<ClienteViewModel>(clienteDomain);

        } //GetByCpfCnpj

        public ClienteViewModel GetById(int id)
        {

            var clienteDomain = _serviceCliente.GetById(id);

            return _mapper.Map<ClienteViewModel>(clienteDomain);

        } //GetById

        public IEnumerable<ClienteViewModel> Search(Expression<Func<ClienteViewModel, bool>> predicate)
        {

            throw new NotImplementedException();

        } //Search

        public void Dispose()
        {

            _serviceCliente.Dispose();

        } //Dispose


    } //class
} //namespace
