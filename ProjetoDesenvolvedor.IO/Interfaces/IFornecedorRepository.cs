using ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor;
using ProjetoDesenvolvedor.IO.Entities;

namespace ProjetoDesenvolvedor.IO.Interfaces
{
    public interface IFornecedorRepository : IBaseRepository<Fornecedor, ReadFornecedorDto, CreateFornecedorDto, UpdateFornecedorDto, BaseFornecedorDto>
    {
    }
}
