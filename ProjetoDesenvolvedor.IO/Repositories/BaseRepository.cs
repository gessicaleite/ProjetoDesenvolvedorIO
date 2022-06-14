using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using ProjetoDesenvolvedor.IO.Data;
using ProjetoDesenvolvedor.IO.Entities;
using ProjetoDesenvolvedor.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Repositories
{
    public class BaseRepository<TEntity, TReadDto, TCreateDto, TUpdateDto, TBaseDto> : IBaseRepository<TEntity, TReadDto, TCreateDto, TUpdateDto, TBaseDto>
        where TEntity : BaseEntity
        where TReadDto : class
        where TCreateDto : class
        where TUpdateDto : class
        where TBaseDto : class

    {
        protected ProjetoContext _context;

        protected DbSet<TEntity> _dbSet;
        private IMapper _mapper { get; set; }

        public BaseRepository(ProjetoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<List<TReadDto>> ObterTodos()
        {
            try
            {
                var resultado = await _dbSet.ToListAsync();
                if (resultado is null) return null;
                _mapper.Map<List<TBaseDto>>(resultado);
                return _mapper.Map<List<TReadDto>>(resultado);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public virtual async Task<TReadDto> ObterPorId(int id)
        {
            try
            {
                var resultado = await _dbSet.FirstOrDefaultAsync(item => item.Id == id);
                if (resultado is null)
                {
                    return null;
                }
                _mapper.Map<TBaseDto>(resultado);
                return _mapper.Map<TReadDto>(resultado);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<TEntity> ObterEntidadePorId(int id)
        {
            try
            {
                var resultado = await _dbSet.FirstOrDefaultAsync(item => item.Id == id);
                if (resultado is null) return null;
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<TReadDto> Adicionar(TEntity dados)
        {
            try
            {
                await _dbSet.AddAsync(dados);
                await SalvarAlteracoes();
                _mapper.Map<TBaseDto>(dados);
                return _mapper.Map<TReadDto>(dados);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public virtual async Task<Result> Deletar(int id)
        {
            try
            {
                var dados = await _dbSet.FirstOrDefaultAsync(item => item.Id == id);
                if (dados is null)
                {
                    return Result.Fail("Não foi possível deletar os dados");
                }
                _dbSet.Remove(dados);
                await SalvarAlteracoes();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public virtual async Task<Result> Atualizar(TEntity dados)
        {
            try
            {
                _dbSet.Update(dados);
                await SalvarAlteracoes();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<int> SalvarAlteracoes()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
