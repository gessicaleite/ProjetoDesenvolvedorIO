using AutoMapper;
using ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor;
using ProjetoDesenvolvedor.IO.Entities;
using System.Linq;

namespace ProjetoDesenvolvedor.IO.Services
{
    public class FornecedorProfile : Profile
    {
        public FornecedorProfile()
        {
            CreateMap<UpdateFornecedorDto, Fornecedor>().ReverseMap();
            CreateMap<CreateFornecedorDto, Fornecedor>();
            CreateMap<Fornecedor, BaseFornecedorDto>();
            CreateMap<Fornecedor, ReadFornecedorDto>()
                .ForMember(
                    produtos => produtos.ProdutosDto,
                    map => map.MapFrom(src => src.Produtos.Select
                    (p => new { p.Nome, p.Situacao, p.Valor, p.Descricao, p.Imagem })))
                .ForMember(
                    endereco => endereco.EnderecoDto, map => map
                    .MapFrom(src => src.Endereco));
        }
    }
}
