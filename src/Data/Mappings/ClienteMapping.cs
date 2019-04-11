using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .ToTable("Clientes");

            builder
                .Ignore(c => c.ListaErros);

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Apelido)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder
                .HasIndex(c => c.Apelido)
                .IsUnique();

            builder
                .Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            //Tratando aqui value object VOCpfCnpf
            builder
                .OwnsOne(c => c.CpfCnpj, voCpfCnpj =>
                {
                    voCpfCnpj
                        .Property(vo => vo.Numero)
                        .IsRequired()
                        .HasColumnName("CpfCnpj")
                        .HasColumnType("varchar(14)");

                    voCpfCnpj
                        .HasIndex(vo => vo.Numero)
                        .IsUnique();
                });

            //Tratando aqui value object VOEmail
            builder
                .OwnsOne(c => c.Email, voEmail =>
                {
                    voEmail
                        .Property(vo => vo.EnderecoEmail)
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(100)");
                });

            //Tratando aqui value object VOEndereco
            builder
                .OwnsOne(c => c.Endereco, voEndereco =>
                {
                    voEndereco
                        .Property(vo => vo.Logradouro)
                        .IsRequired()
                        .HasColumnName("Logradouro")
                        .HasColumnType("varchar(100)");

                    voEndereco
                        .Property(vo => vo.Bairro)
                        .HasColumnName("Bairro")
                        .HasColumnType("varchar(30)");

                    voEndereco
                        .Property(vo => vo.Cidade)
                        .IsRequired()
                        .HasColumnName("Cidade")
                        .HasColumnType("varchar(30)");

                    voEndereco
                        .Property(vo => vo.CEP)
                        .IsRequired()
                        .HasColumnName("CEP")
                        .HasColumnType("varchar(30)");
                });

            //Tratando aqui value object VOUF que esta dentro de VOEndereco
            builder
                .OwnsOne(c => c.Endereco)
                    .OwnsOne(e => e.UF, voUF =>
                    {
                        voUF
                            .Property(vo => vo.UF)
                            .IsRequired()
                            .HasColumnName("UF")
                            .HasColumnType("varchar(2)");
                    });

        } //Configure

    } //class

} //namespace
