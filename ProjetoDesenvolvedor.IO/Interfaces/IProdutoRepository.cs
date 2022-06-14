using ProjetoDesenvolvedor.IO.Data.Dtos.Produto;
using ProjetoDesenvolvedor.IO.Entities;

namespace ProjetoDesenvolvedor.IO.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Produto, ReadProdutoDto, CreateProdutoDto, UpdateProdutoDto, BaseProdutoDto>
    {
    }
}
