using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder
                .ToTable("Produtos");

            builder
                .Ignore(p => p.ListaErros);

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Apelido)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder
                .Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(p => p.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .Property(p => p.Unidade)
                .HasColumnType("varchar(2)")
                .IsRequired();

            builder
                .HasOne(p => p.Fornecedor)
                    .WithMany(f => f.Produtos)
                .HasForeignKey(p => p.idFornecedor);

        } //Configure

    } //class

} //namespace
