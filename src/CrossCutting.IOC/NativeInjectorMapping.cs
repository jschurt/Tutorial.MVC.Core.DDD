using Application.Interfaces;
using Application.Interfaces.Aggregation;
using Application.Services;
using AutoMapper;
using Data.Repositories;
using Data.Repositories.AggregationPedido;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository.Aggregation;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Aggregation;
using Domain.Services;
using Domain.Services.Aggregation;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IOC
{
    public static class NativeInjectorMapping
    {

        public static void RegisterServices(IServiceCollection service)
        {
            //service.AddSingleton(Mapper.Configuration);
            //service.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            service.AddScoped<IApplicationCliente, ApplicationCliente>();
            service.AddScoped<IApplicationFornecedor, ApplicationFornecedor>();
            service.AddScoped<IApplicationProduto, ApplicationProduto>();
            service.AddScoped<IApplicationPedido, ApplicationPedido>();
            service.AddScoped<IApplicationItemPedido, ApplicationItemPedido>();

            service.AddScoped<IServiceCliente, ServiceCliente>();
            service.AddScoped<IServiceFornecedor, ServiceFornecedor>();
            service.AddScoped<IServiceProduto, ServiceProduto>();
            service.AddScoped<IServicePedido, ServicePedido>();
            service.AddScoped<IServiceItemPedido, ServiceItemPedido>();

            service.AddScoped<IRepositoryCliente, RepositoryClientes>();
            service.AddScoped<IRepositoryFornecedor, RepositoryFornecedores>();
            service.AddScoped<IRepositoryProduto, RepositoryProdutos>();
            service.AddScoped<IRepositoryPedido, RepositoryPedidos>();

            //service.AddScoped<ContextEF>();

        } //RegisterServices

    } //class
} //namespace
