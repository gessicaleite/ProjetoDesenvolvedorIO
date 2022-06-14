using AutoMapper;
using FluentResults;
using ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor;
using ProjetoDesenvolvedor.IO.Entities;
using ProjetoDesenvolvedor.IO.Interfaces;
using ProjetoDesenvolvedor.IO.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Services
{
    public class FornecedorService : BaseService<Fornecedor, ReadFornecedorDto, CreateFornecedorDto, UpdateFornecedorDto, BaseFornecedorDto>, IFornecedorService
    {
        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper, INotificador notificador) : base(fornecedorRepository, mapper, notificador)
        {

        }

        public async override Task<ReadFornecedorDto> Adicionar(CreateFornecedorDto dadosDto)
        {
            var fornecedor = _mapper.Map<Fornecedor>(dadosDto);

            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return null;

            var fornecedores = await _baseRepository.ObterTodos();
            var documentoFornecedor = fornecedores.Where(a => a.Documento == dadosDto.Documento);
            if (documentoFornecedor is not null)
            {
                Notificar($"Documento cadastrado para outro fornecedor.");
                return null;
            }
            return await base.Adicionar(dadosDto);
        }

        public async Task<Result> Atualizar(UpdateFornecedorDto dados)
        {
            var fornecedorRepositorio = await _baseRepository.ObterEntidadePorId(dados.Id);
            if (fornecedorRepositorio is null)
            {
                Notificar($"Id {dados.Id} não cadastrado na base dados.");
                return Result.Fail("Id não encontrado.");
            }

            var fornecedores = await _baseRepository.ObterTodos();
            foreach (var pessoa in fornecedores)
            {
                if (pessoa.Documento == dados.Documento)
                {
                    Notificar($"Documento cadastrado para o fornecedor {pessoa.Nome}.");
                    return Result.Fail("Documento duplicado");
                }
            }

            var fornecedor = _mapper.Map<Fornecedor>(dados);
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return Result.Fail("Erro ao validar produto.");

            _mapper.Map(dados, fornecedorRepositorio);

            await _baseRepository.Atualizar(fornecedorRepositorio);
            return Result.Ok();
        }

    }
}
