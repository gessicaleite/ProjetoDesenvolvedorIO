using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoDesenvolvedor.IO.Entities.Configs
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Valor).IsRequired();
            builder.Property(p => p.Situacao).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.DataCadastro);
            builder.Property(p => p.Imagem);
            builder.Property(p => p.IdFornecedor).IsRequired();

            builder.ToTable("Produtos");

            //builder.HasOne(produto => produto.Fornecedor)
            //    .WithMany(fornecedor => fornecedor.Produtos)
            //    .HasForeignKey(produto => produto.IdFornecedor);
        }
    }
}
