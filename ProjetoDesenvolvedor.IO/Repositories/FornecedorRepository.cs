using AutoMapper;
using ProjetoDesenvolvedor.IO.Data;
using ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor;
using ProjetoDesenvolvedor.IO.Entities;
using ProjetoDesenvolvedor.IO.Interfaces;

namespace ProjetoDesenvolvedor.IO.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor, ReadFornecedorDto, CreateFornecedorDto, UpdateFornecedorDto, BaseFornecedorDto>, IFornecedorRepository
    {

        public FornecedorRepository(ProjetoContext fornecedorContext, IMapper mapper) : base(fornecedorContext, mapper)
        {

        }
    }
}
