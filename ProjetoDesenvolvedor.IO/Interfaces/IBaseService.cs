using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Interfaces
{
    public interface IBaseService<TEntity, TReadDto, TCreateDto, TUpdateDto, TBaseDto>
    {
        public Task<List<TReadDto>> ObterTodos();

        public Task<TReadDto> ObterPorId(int id);

        public Task<TReadDto> Adicionar(TCreateDto dados);

        public Task<Result> Deletar(int id);

        public Task<Result> Atualizar(TUpdateDto dados);

    }
}
