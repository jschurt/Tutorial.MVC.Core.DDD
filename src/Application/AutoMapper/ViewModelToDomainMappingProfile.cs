using Application.ViewModels;
using AutoMapper;
using CrossCutting.Extensions;
using Domain.Entities;
using Domain.Entities.AggregationPedido;
using System;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile()
        {
            //Apenas informo os campos que requerem algum tratamento especial (ex. ValueObjects)
            //Campos simples (Ex. Nome, Apelido) nao ha necessidade de setup

            //Uso ForPath para objetos complexos (ex. ValueObjects)
            //Uso ForMember para transformacoes simples

            CreateMap<ClienteViewModel, Cliente>()
                .ForPath(to => to.CpfCnpj.Numero.SomenteNumeros(), opt => opt.MapFrom(from => from.CpfCnpj))
                .ForPath(to => to.Email.EnderecoEmail, opt => opt.MapFrom(from => from.Email))
                .ForPath(to => to.Endereco.Logradouro, opt => opt.MapFrom(from => from.Endereco))
                .ForPath(to => to.Endereco.Bairro, opt => opt.MapFrom(from => from.Bairro))
                .ForPath(to => to.Endereco.Cidade, opt => opt.MapFrom(from => from.Cidade))
                .ForPath(to => to.Endereco.UF, opt => opt.MapFrom(from => from.UF))
                .ForPath(to => to.Endereco.CEP.SomenteNumeros(), opt => opt.MapFrom(from => from.CEP));

            CreateMap<FornecedorViewModel, Fornecedor>()
                .ForPath(to => to.CpfCnpj.Numero.SomenteNumeros(), opt => opt.MapFrom(from => from.CpfCnpj))
                .ForPath(to => to.Email.EnderecoEmail, opt => opt.MapFrom(from => from.Email))
                .ForPath(to => to.Endereco.Logradouro, opt => opt.MapFrom(from => from.Endereco))
                .ForPath(to => to.Endereco.Bairro, opt => opt.MapFrom(from => from.Bairro))
                .ForPath(to => to.Endereco.Cidade, opt => opt.MapFrom(from => from.Cidade))
                .ForPath(to => to.Endereco.UF, opt => opt.MapFrom(from => from.UF))
                .ForPath(to => to.Endereco.CEP.SomenteNumeros(), opt => opt.MapFrom(from => from.CEP));

            CreateMap<ProdutoViewModel, Produto>()
                .ForMember(to => to.Valor, opt => opt.MapFrom(from => from.Valor.ConvertDecimal("{0:#,###,##0.00}")));

            CreateMap<PedidoViewModel, Pedido>()
                .ForMember(to => to.ValorTotalProdutos, opt => opt.MapFrom(from => from.TotalProdutos.ConvertDecimal("{0:#,###,##0.00}")))
                .ForMember(to => to.DataPedido, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataPedido)))
                .ForMember(to => to.DataEntrega, opt => opt.MapFrom(from => Convert.ToDateTime(from.DataEntrega)));


            CreateMap<ItemPedidoViewModel, ItemPedido>();

        } //constructor

    } //class
} //namespace
