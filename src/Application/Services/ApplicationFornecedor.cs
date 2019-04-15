using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using CrossCutting.Extensions;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Services
{
    public class ApplicationFornecedor : IApplicationFornecedor
    {

        protected readonly IServiceFornecedor _serviceFornecedor;
        protected readonly IMapper _mapper;

        public ApplicationFornecedor(IServiceFornecedor serviceFornecedor, IMapper mapper)
        {
            _serviceFornecedor = serviceFornecedor;
            _mapper = mapper;
        } //constructor

        public FornecedorViewModel Add(FornecedorViewModel obj)
        {

            var FornecedorDomain = _mapper.Map<Fornecedor>(obj);
            FornecedorDomain = _serviceFornecedor.Add(FornecedorDomain);

            return _mapper.Map<FornecedorViewModel>(FornecedorDomain);

        } //Add

        public FornecedorViewModel Update(FornecedorViewModel obj)
        {

            var FornecedorDomain = _mapper.Map<Fornecedor>(obj);
            FornecedorDomain = _serviceFornecedor.Update(FornecedorDomain);

            return _mapper.Map<FornecedorViewModel>(FornecedorDomain);

        } //Update

        public FornecedorViewModel Remove(FornecedorViewModel obj)
        {

            var FornecedorDomain = _mapper.Map<Fornecedor>(obj);
            FornecedorDomain = _serviceFornecedor.Remove(FornecedorDomain);

            return _mapper.Map<FornecedorViewModel>(FornecedorDomain);

        } //Remove


        public IEnumerable<FornecedorViewModel> GetAll()
        {

            var FornecedorsDomain = _serviceFornecedor.GetAll();

            return _mapper.Map<IEnumerable<FornecedorViewModel>>(FornecedorsDomain);

        } //GetAll

        public FornecedorViewModel GetByApelido(string apelido)
        {

            var FornecedorDomain = _serviceFornecedor.GetByApelido(apelido);

            return _mapper.Map<FornecedorViewModel>(FornecedorDomain);

        } //GetByApelido

        public FornecedorViewModel GetByCpfCnpj(string cpfcnpj)
        {

            var FornecedorDomain = _serviceFornecedor.GetByCpfCnpj(cpfcnpj.SomenteNumeros());

            return _mapper.Map<FornecedorViewModel>(FornecedorDomain);

        } //GetByCpfCnpj

        public FornecedorViewModel GetById(int id)
        {

            var FornecedorDomain = _serviceFornecedor.GetById(id);

            return _mapper.Map<FornecedorViewModel>(FornecedorDomain);

        } //GetById

        public IEnumerable<FornecedorViewModel> Search(Expression<Func<FornecedorViewModel, bool>> predicate)
        {

            throw new NotImplementedException();

        } //Search

        public void Dispose()
        {

            _serviceFornecedor.Dispose();

        } //Dispose

    } //class

} //namespace
