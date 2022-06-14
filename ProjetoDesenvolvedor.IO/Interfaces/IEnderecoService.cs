using ProjetoDesenvolvedor.IO.Data.Dtos.Endereco;
using ProjetoDesenvolvedor.IO.Entities;

namespace ProjetoDesenvolvedor.IO.Interfaces
{
    public interface IEnderecoService : IBaseService<Endereco, ReadEnderecoDto, CreateEnderecoDto, UpdateEnderecoDto, BaseEnderecoDto>
    {
    }
}
