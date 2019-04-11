﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ContextEF))]
    [Migration("20190411185434_Inicio")]
    partial class Inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Apelido")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Domain.Entities.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Apelido")
                        .IsUnique();

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Domain.Entities.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPedido");

                    b.Property<int>("IdProduto");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdProduto");

                    b.ToTable("ItemPedido");
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataEntrega")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("DateTime");

                    b.Property<int>("idCliente");

                    b.HasKey("Id");

                    b.HasIndex("idCliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Unidade")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("idFornecedor");

                    b.HasKey("Id");

                    b.HasIndex("idFornecedor");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.VOCpfCnpj", "CpfCnpj", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("CpfCnpj")
                                .HasColumnType("varchar(14)");

                            b1.HasKey("ClienteId");

                            b1.HasIndex("Numero")
                                .IsUnique();

                            b1.ToTable("Clientes");

                            b1.HasOne("Domain.Entities.Cliente")
                                .WithOne("CpfCnpj")
                                .HasForeignKey("Domain.ValueObjects.VOCpfCnpj", "ClienteId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Domain.ValueObjects.VOEmail", "Email", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("EnderecoEmail")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(100)");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.HasOne("Domain.Entities.Cliente")
                                .WithOne("Email")
                                .HasForeignKey("Domain.ValueObjects.VOEmail", "ClienteId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Domain.ValueObjects.VOEndereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Bairro")
                                .HasColumnName("Bairro")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasColumnName("CEP")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnName("Cidade")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnName("Logradouro")
                                .HasColumnType("varchar(100)");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.HasOne("Domain.Entities.Cliente")
                                .WithOne("Endereco")
                                .HasForeignKey("Domain.ValueObjects.VOEndereco", "ClienteId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("Domain.ValueObjects.VOUF", "UF", b2 =>
                                {
                                    b2.Property<int>("VOEnderecoClienteId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("UF")
                                        .IsRequired()
                                        .HasColumnName("UF")
                                        .HasColumnType("varchar(2)");

                                    b2.HasKey("VOEnderecoClienteId");

                                    b2.ToTable("Clientes");

                                    b2.HasOne("Domain.ValueObjects.VOEndereco")
                                        .WithOne("UF")
                                        .HasForeignKey("Domain.ValueObjects.VOUF", "VOEnderecoClienteId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });

            modelBuilder.Entity("Domain.Entities.Fornecedor", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.VOCpfCnpj", "CpfCnpj", b1 =>
                        {
                            b1.Property<int>("FornecedorId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("CpfCnpj")
                                .HasColumnType("varchar(14)");

                            b1.HasKey("FornecedorId");

                            b1.HasIndex("Numero")
                                .IsUnique();

                            b1.ToTable("Fornecedores");

                            b1.HasOne("Domain.Entities.Fornecedor")
                                .WithOne("CpfCnpj")
                                .HasForeignKey("Domain.ValueObjects.VOCpfCnpj", "FornecedorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Domain.ValueObjects.VOEmail", "Email", b1 =>
                        {
                            b1.Property<int>("FornecedorId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("EnderecoEmail")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(100)");

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedores");

                            b1.HasOne("Domain.Entities.Fornecedor")
                                .WithOne("Email")
                                .HasForeignKey("Domain.ValueObjects.VOEmail", "FornecedorId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Domain.ValueObjects.VOEndereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("FornecedorId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Bairro")
                                .HasColumnName("Bairro")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasColumnName("CEP")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnName("Cidade")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnName("Logradouro")
                                .HasColumnType("varchar(100)");

                            b1.HasKey("FornecedorId");

                            b1.ToTable("Fornecedores");

                            b1.HasOne("Domain.Entities.Fornecedor")
                                .WithOne("Endereco")
                                .HasForeignKey("Domain.ValueObjects.VOEndereco", "FornecedorId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("Domain.ValueObjects.VOUF", "UF", b2 =>
                                {
                                    b2.Property<int>("VOEnderecoFornecedorId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("UF")
                                        .IsRequired()
                                        .HasColumnName("UF")
                                        .HasColumnType("varchar(2)");

                                    b2.HasKey("VOEnderecoFornecedorId");

                                    b2.ToTable("Fornecedores");

                                    b2.HasOne("Domain.ValueObjects.VOEndereco")
                                        .WithOne("UF")
                                        .HasForeignKey("Domain.ValueObjects.VOUF", "VOEnderecoFornecedorId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });

            modelBuilder.Entity("Domain.Entities.ItemPedido", b =>
                {
                    b.HasOne("Domain.Entities.Pedido", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Produto", "Produto")
                        .WithMany("ItensPedido")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("idCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Produto", b =>
                {
                    b.HasOne("Domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("idFornecedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
