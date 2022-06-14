using AutoMapper;
using FluentResults;
using ProjetoDesenvolvedor.IO.Data.Dtos.Endereco;
using ProjetoDesenvolvedor.IO.Entities;
using ProjetoDesenvolvedor.IO.Interfaces;
using ProjetoDesenvolvedor.IO.Validation;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Services
{
    public class EnderecoService : BaseService<Endereco, ReadEnderecoDto, CreateEnderecoDto, UpdateEnderecoDto, BaseEnderecoDto>, IEnderecoService
    {
        private readonly IFornecedorService _fornecedorService;

        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper, IFornecedorService fornecedorService, INotificador notificador) : base(enderecoRepository, mapper, notificador)
        {
            _fornecedorService = fornecedorService;
        }

        public override async Task<ReadEnderecoDto> Adicionar(CreateEnderecoDto dadosDto)
        {
            var endereco = _mapper.Map<Endereco>(dadosDto);

            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return default;

            var fornecedor = await _fornecedorService.ObterPorId(dadosDto.IdFornecedor);

            if (fornecedor is null)
            {
                Notificar($"Não existe fornecedor cadastrado para o id {dadosDto.IdFornecedor}");
                return default;
            }

            if (fornecedor.EnderecoDto is not null)
            {
                Notificar($"O fornecedor {fornecedor.Nome} já possui um endereço cadastrado.");
                return default;
            }
            return await base.Adicionar(dadosDto);
        }

        public async Task<Result> Atualizar(UpdateEnderecoDto dados)
        {
            var enderecoRepositorio = await _baseRepository.ObterEntidadePorId(dados.Id);

            if (enderecoRepositorio is null)
            {
                Notificar($"Id {dados.Id} não cadastrado na base dados.");
                return Result.Fail("Id não encontrado.");
            }

            var endereco = _mapper.Map<Endereco>(dados);
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return Result.Fail("Erro");

            _mapper.Map(dados, enderecoRepositorio);

            await _baseRepository.Atualizar(enderecoRepositorio);

            return Result.Ok();
        }
    }
}
