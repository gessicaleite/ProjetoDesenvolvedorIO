using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Interfaces
{
    public interface IBaseRepository<TEntity, TReadDto, TCreateDto, TUpdateDto, TBaseDto>
    {
        public Task<List<TReadDto>> ObterTodos();

        public Task<TReadDto> ObterPorId(int id);

        public Task<TEntity> ObterEntidadePorId(int id);


        public Task<TReadDto> Adicionar(TEntity dados);

        public Task<Result> Deletar(int id);

        public Task<Result> Atualizar(TEntity dados);

        public Task<int> SalvarAlteracoes();

        public void Dispose();

    }
}
