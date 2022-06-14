using ProjetoDesenvolvedor.IO.Data.Dtos.Endereco;
using ProjetoDesenvolvedor.IO.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor
{
    public class ReadFornecedorDto
    {
        public int Id { get; set; }

        public string Nome { get; private set; }

        public string Documento { get; private set; }

        public EAtivoInativo Situacao { get; private set; }

        public ETipoCliente TipoPessoa { get; private set; }

        [Display(Name = "Endereco")]
        public BaseEnderecoDto EnderecoDto { get; set; }

        [Display(Name = "Produtos")]
        public object ProdutosDto { get; set; }
    }
}
