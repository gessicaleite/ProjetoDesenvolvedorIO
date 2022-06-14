using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoDesenvolvedor.IO.Entities.Configs
{
    public class FornecedorConfig : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Nome).IsRequired();
            builder.Property(f => f.Documento).IsRequired();
            builder.HasIndex(f => f.Documento).IsUnique();
            builder.Property(f => f.Situacao).IsRequired();
            builder.Property(f => f.TipoPessoa).IsRequired();

            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor)
                .HasForeignKey<Endereco>(e => e.IdFornecedor);

            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.IdFornecedor);

            builder.ToTable("Fornecedores");

        }
    }
}
