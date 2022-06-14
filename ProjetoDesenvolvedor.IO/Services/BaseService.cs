using AutoMapper;
using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using ProjetoDesenvolvedor.IO.Entities;
using ProjetoDesenvolvedor.IO.Interfaces;
using ProjetoDesenvolvedor.IO.Notificacoes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Services
{
    public class BaseService<TEntity, TReadDto, TCreateDto, TUpdateDto, TBaseDto>
        where TEntity : BaseEntity
        where TReadDto : class
        where TCreateDto : class
        where TUpdateDto : class

    {
        protected INotificador _notificador { get; set; }
        protected IMapper _mapper { get; set; }

        protected IBaseRepository<TEntity, TReadDto, TCreateDto, TUpdateDto, TBaseDto> _baseRepository;

        public BaseService(IBaseRepository<TEntity, TReadDto, TCreateDto, TUpdateDto, TBaseDto> baseRepository, IMapper mapper, INotificador notificador)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _notificador = notificador;
        }

        public async Task<List<TReadDto>> ObterTodos()
        {
            var dados = await _baseRepository.ObterTodos();
            if (dados is not null)
            {
                return _mapper.Map<List<TReadDto>>(dados);
            }
            return null;
        }

        public async Task<TReadDto> ObterPorId(int id)
        {
            var dado = await _baseRepository.ObterPorId(id);
            if (dado is null)
            {
                Notificar($"Id {id} não encontrado na base de dados");
                return null;
            }
            return dado;
        }

        public virtual async Task<TReadDto> Adicionar(TCreateDto dadosDto)
        {
            var dados = _mapper.Map<TEntity>(dadosDto);
            if (dados is not null)
            {
                return await _baseRepository.Adicionar(dados);
            }
            return null;
        }

        public async Task<Result> Deletar(int id)
        {
            var dados = await _baseRepository.ObterPorId(id);
            if (dados is null)
            {
                Notificar($"Id {id} não encontrado na base de dados");
                return Result.Fail("Id não encontrado.");
            }
            await _baseRepository.Deletar(id);
            return Result.Ok();
        }

        public void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));

        }

        public void Notificar(ValidationResult validator)
        {
            foreach (var erro in validator.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }

        protected bool ExecutarValidacao<TValidator, TEntityValidator>(TValidator validacao, TEntityValidator entidade) where TValidator : AbstractValidator<TEntityValidator> where TEntityValidator : BaseEntity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;
            Notificar(validator);
            return false;
        }
    }
}
