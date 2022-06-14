using AutoMapper;
using ProjetoDesenvolvedor.IO.Data;
using ProjetoDesenvolvedor.IO.Data.Dtos.Produto;
using ProjetoDesenvolvedor.IO.Entities;
using ProjetoDesenvolvedor.IO.Interfaces;

namespace ProjetoDesenvolvedor.IO.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto, ReadProdutoDto, CreateProdutoDto, UpdateProdutoDto, BaseProdutoDto>, IProdutoRepository
    {
        public ProdutoRepository(ProjetoContext produtoContext, IMapper mapper) : base(produtoContext, mapper)
        {

        }
    }
}
