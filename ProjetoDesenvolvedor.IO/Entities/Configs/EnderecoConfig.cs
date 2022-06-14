using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoDesenvolvedor.IO.Entities.Configs
{
    public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Rua)
                .IsRequired();
            builder.Property(e => e.Numero)
                .IsRequired();
            builder.Property(e => e.Cidade)
                .IsRequired();
            builder.Property(e => e.Estado)
                .IsRequired();
            builder.Property(e => e.IdFornecedor)
                .IsRequired();

            builder.ToTable("Enderecos");


            //builder.HasOne(endereco => endereco.Fornecedor)
            //    .WithOne(fornecedor => fornecedor.Endereco)
            //    .HasForeignKey<Endereco>(endereco => endereco.IdFornecedor);
        }
    }
}
