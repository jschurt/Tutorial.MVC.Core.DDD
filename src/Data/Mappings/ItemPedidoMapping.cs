using Domain.Entities.AggregationPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {

        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {

            builder
                .ToTable("ItemPedido");

            builder
                .Ignore(ip => ip.ListaErros);

            builder
                .HasKey(ip => ip.Id);

            builder
                .Property(ip => ip.Quantidade)
                .HasColumnType("int")
                .IsRequired();

            builder
                .HasOne(ip => ip.Pedido)
                    .WithMany(p => p.ItensPedido)
                .HasForeignKey(ip => ip.IdPedido);

            builder
                .HasOne(ip => ip.Produto)
                    .WithMany(p => p.ItensPedido)
                .HasForeignKey(ip => ip.IdProduto);

        } //Configure

    } //class

} //namespace
