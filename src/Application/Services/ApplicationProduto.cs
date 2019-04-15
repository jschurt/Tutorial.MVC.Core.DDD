using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Services
{
    public class ApplicationProduto : IApplicationProduto
    {

        protected readonly IServiceProduto _serviceProduto;
        protected readonly IMapper _mapper;

        public ApplicationProduto(IServiceProduto serviceProduto, IMapper mapper)
        {
            _serviceProduto = serviceProduto;
            _mapper = mapper;
        } //constructor

        public ProdutoViewModel Add(ProdutoViewModel obj)
        {

            var produtoDomain = _mapper.Map<Produto>(obj);
            produtoDomain = _serviceProduto.Add(produtoDomain);

            return _mapper.Map<ProdutoViewModel>(produtoDomain);

        } //Add

        public ProdutoViewModel Update(ProdutoViewModel obj)
        {

            var produtoDomain = _mapper.Map<Produto>(obj);
            produtoDomain = _serviceProduto.Update(produtoDomain);

            return _mapper.Map<ProdutoViewModel>(produtoDomain);

        } //Update

        public ProdutoViewModel Remove(ProdutoViewModel obj)
        {

            var produtoDomain = _mapper.Map<Produto>(obj);
            produtoDomain = _serviceProduto.Remove(produtoDomain);

            return _mapper.Map<ProdutoViewModel>(produtoDomain);

        } //Remove

        public ProdutoViewModel GetByNome(string nome)
        {

            var produtoDomain = _serviceProduto.GetByNome(nome);

            return _mapper.Map<ProdutoViewModel>(produtoDomain);

        } //GetByNome

        public ProdutoViewModel GetByApelido(string apelido)
        {

            var produtoDomain = _serviceProduto.GetByApelido(apelido);

            return _mapper.Map<ProdutoViewModel>(produtoDomain);

        } //GetByApelido

        public IEnumerable<ProdutoViewModel> GetAll()
        {

            var produtosDomain = _serviceProduto.GetAll();

            return _mapper.Map<IEnumerable<ProdutoViewModel>>(produtosDomain);

        } //GetAll

        public ProdutoViewModel GetById(int id)
        {
            var produtoDomain = _serviceProduto.GetById(id);

            return _mapper.Map<ProdutoViewModel>(produtoDomain);

        } //GetById

        public IEnumerable<ProdutoViewModel> Search(Expression<Func<ProdutoViewModel, bool>> predicate)
        {
            throw new NotImplementedException();
        } //Search

        public void Dispose()
        {
            _serviceProduto.Dispose();
        } //Dispose

    } //class

} //namespace
