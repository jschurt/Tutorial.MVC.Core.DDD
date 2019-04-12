using Domain.Entities.AggregationPedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {

            builder
                .ToTable("Pedidos");

            #region Ignore fields...

            builder
                .Ignore(p => p.ListaErros);

            builder
                .Ignore(p => p.QuantidadeTotalProdutos);

            builder
                .Ignore(p => p.ValorTotalProdutos);

            #endregion

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.DataPedido)
                .HasColumnType("DateTime")
                .IsRequired();

            builder
                .Property(p => p.DataEntrega)
                .HasColumnType("DateTime");

            builder
                .Property(p => p.Observacao)
                .HasColumnType("varchar(4000)");

            builder
                .HasOne(p => p.Cliente)
                    .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.idCliente);

        } //Configure

    } //class

} //namespace
