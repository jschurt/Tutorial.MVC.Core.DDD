using Application.ViewModels;
using AutoMapper;
using CrossCutting.Extensions;
using Domain.Entities;
using Domain.Entities.AggregationPedido;
using Domain.Entities.ValueObjects;
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
                .ConvertUsing((src, dest) =>
                {
                    return new Cliente
                    {
                        Id = src.Id,
                        Apelido = src.Apelido,
                        Nome = src.Nome,
                        CpfCnpj = new VOCpfCnpj {  Numero = src.CpfCnpj.SomenteNumeros() },
                        Email = new VOEmail { EnderecoEmail = src.Email },
                        Endereco = new VOEndereco
                        {
                            Logradouro = src.Endereco,
                            Bairro = src.Bairro,
                            Cidade = src.Cidade,
                            UF = new VOUF { UF = src.UF },
                            CEP = src.CEP
                        }
                    };
                });

            CreateMap<FornecedorViewModel, Fornecedor>()
                .ConvertUsing((src, dest) =>
                {
                    return new Fornecedor
                    {
                        Id = src.Id,
                        Apelido = src.Apelido,
                        Nome = src.Nome,
                        CpfCnpj = new VOCpfCnpj { Numero = src.CpfCnpj.SomenteNumeros() },
                        Email = new VOEmail { EnderecoEmail = src.Email },
                        Endereco = new VOEndereco
                        {
                            Logradouro = src.Endereco,
                            Bairro = src.Bairro,
                            Cidade = src.Cidade,
                            UF = new VOUF { UF = src.UF },
                            CEP = src.CEP
                        }
                    };
                });

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
