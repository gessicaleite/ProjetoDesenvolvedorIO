using ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor;
using ProjetoDesenvolvedor.IO.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDesenvolvedor.IO.Data.Dtos.Endereco
{
    public class ReadEnderecoDto
    {
        public int Id { get; set; }

        public string Rua { get; set; }

        public int Numero { get; set; }

        public string Cidade { get; set; }

        public EUfEstado Estado { get; set; }

        public int IdFornecedor { get; set; }

        [Display(Name = "Fornecedor")]
        public BaseFornecedorDto FornecedorDto { get; set; }
    }
}
