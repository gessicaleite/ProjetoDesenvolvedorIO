using AutoMapper;
using ProjetoDesenvolvedor.IO.Data;
using ProjetoDesenvolvedor.IO.Data.Dtos.Endereco;
using ProjetoDesenvolvedor.IO.Entities;
using ProjetoDesenvolvedor.IO.Interfaces;

namespace ProjetoDesenvolvedor.IO.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco, ReadEnderecoDto, CreateEnderecoDto, UpdateEnderecoDto, BaseEnderecoDto>, IEnderecoRepository
    {
        public EnderecoRepository(ProjetoContext enderecoContext, IMapper mapper) : base(enderecoContext, mapper)
        {

        }
    }
}
