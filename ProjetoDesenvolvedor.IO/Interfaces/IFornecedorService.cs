using ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor;
using ProjetoDesenvolvedor.IO.Entities;

namespace ProjetoDesenvolvedor.IO.Interfaces
{
    public interface IFornecedorService : IBaseService<Fornecedor, ReadFornecedorDto, CreateFornecedorDto, UpdateFornecedorDto, BaseFornecedorDto>
    {
    }
}
