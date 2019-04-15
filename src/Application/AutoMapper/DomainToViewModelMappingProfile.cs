using Application.ViewModels;
using AutoMapper;
using CrossCutting.Extensions;
using Domain.Entities;
using Domain.Entities.AggregationPedido;

namespace Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {

            //Apenas informo os campos quer requerem algum tratamento especial (ex. ValueObjects)
            //Campos simples (Ex. Nome, Apelido) nao ha necessidade de setup

            //Uso ForPath para objetos complexos (ex. ValueObjects)
            //Uso ForMember para transformacoes simples

            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(to => to.CpfCnpj, opt => opt.MapFrom(from => from.CpfCnpj.Numero.FormatCpfCnpj()))
                .ForMember(to => to.Email, opt => opt.MapFrom(from => from.Email.EnderecoEmail))
                .ForMember(to => to.Endereco, opt => opt.MapFrom(from => from.Endereco.Logradouro))
                .ForMember(to => to.Bairro, opt => opt.MapFrom(from => from.Endereco.Bairro))
                .ForMember(to => to.Cidade, opt => opt.MapFrom(from => from.Endereco.Cidade))
                .ForMember(to => to.UF, opt => opt.MapFrom(from => from.Endereco.UF))
                .ForMember(to => to.CEP, opt => opt.MapFrom(from => from.Endereco.CEP));

            CreateMap<Fornecedor, FornecedorViewModel>()
                .ForMember(to => to.CpfCnpj, opt => opt.MapFrom(from => from.CpfCnpj.Numero.FormatCpfCnpj()))
                .ForMember(to => to.Email, opt => opt.MapFrom(from => from.Email.EnderecoEmail))
                .ForMember(to => to.Endereco, opt => opt.MapFrom(from => from.Endereco.Logradouro))
                .ForMember(to => to.Bairro, opt => opt.MapFrom(from => from.Endereco.Bairro))
                .ForMember(to => to.Cidade, opt => opt.MapFrom(from => from.Endereco.Cidade))
                .ForMember(to => to.UF, opt => opt.MapFrom(from => from.Endereco.UF))
                .ForMember(to => to.CEP, opt => opt.MapFrom(from => from.Endereco.CEP));

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(to => to.Valor, opt => opt.MapFrom(from => from.Valor.Formatado("{0:#,###,##0.00}")));

            CreateMap<Pedido, PedidoViewModel>()
                .ForMember(to => to.TotalProdutos, opt => opt.MapFrom(from => from.ValorTotalProdutos.Formatado("{0:#,###,##0.00}")))
                .ForMember(to => to.DataPedido, opt => opt.MapFrom(from => from.DataPedido.Formatado("{0:dd/MM/yyyy}")))
                .ForMember(to => to.DataEntrega, opt => opt.MapFrom(from => from.DataEntrega.Formatado("{0:dd/MM/yyyy}")));


            CreateMap<ItemPedido, ItemPedidoViewModel>();


        } //DomainToViewModelMappingProfile

    } //class
} //namespace
