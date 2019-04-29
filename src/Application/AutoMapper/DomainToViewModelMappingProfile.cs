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
                .ConvertUsing((src, dest) =>
                {
                    return new ClienteViewModel
                    {
                        Id = src.Id,
                        Apelido = src.Apelido,
                        Nome = src.Nome,
                        CpfCnpj = src.CpfCnpj.Numero.FormatCpfCnpj(),
                        Email = src.Email.EnderecoEmail,
                        Endereco = src.Endereco.Logradouro,
                        Bairro = src.Endereco.Bairro,
                        Cidade = src.Endereco.Cidade,
                        UF = src.Endereco.UF.UF,
                        CEP = src.Endereco.CEP
                    };

                });

            CreateMap<Fornecedor, FornecedorViewModel>()
                .ConvertUsing((src, dest) =>
                {
                    return new FornecedorViewModel
                    {
                        Id = src.Id,
                        Apelido = src.Apelido,
                        Nome = src.Nome,
                        CpfCnpj = src.CpfCnpj.Numero.FormatCpfCnpj(),
                        Email = src.Email.EnderecoEmail,
                        Endereco = src.Endereco.Logradouro,
                        Bairro = src.Endereco.Bairro,
                        Cidade = src.Endereco.Cidade,
                        UF = src.Endereco.UF.UF,
                        CEP = src.Endereco.CEP
                    };

                });

            CreateMap<Produto, ProdutoViewModel>()
                .ConvertUsing((src, dst) => {
                    return new ProdutoViewModel
                    {
                        Id = src.Id,
                        Apelido = src.Apelido,
                        Nome = src.Nome,
                        Valor = src.Valor.Formatado("{0:#,###,##0.00}"),
                        Unidade = src.Unidade,
                        IdFornecedor = src.idFornecedor,
                        NomeFornecedor = src.Fornecedor.Nome
                    };
                });

            CreateMap<Pedido, PedidoViewModel>()
                .ForMember(to => to.TotalProdutos, opt => opt.MapFrom(from => from.ValorTotalProdutos.Formatado("{0:#,###,##0.00}")))
                .ForMember(to => to.DataPedido, opt => opt.MapFrom(from => from.DataPedido.Formatado("{0:dd/MM/yyyy}")))
                .ForMember(to => to.DataEntrega, opt => opt.MapFrom(from => from.DataEntrega.Formatado("{0:dd/MM/yyyy}")));


            CreateMap<ItemPedido, ItemPedidoViewModel>();


        } //DomainToViewModelMappingProfile

    } //class
} //namespace
