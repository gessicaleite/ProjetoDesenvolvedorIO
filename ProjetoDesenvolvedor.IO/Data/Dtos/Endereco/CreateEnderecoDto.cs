using ProjetoDesenvolvedor.IO.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDesenvolvedor.IO.Data.Dtos.Endereco
{
    public class CreateEnderecoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, 5, ErrorMessage = "Favor selecionar entre as opções de {1} a {2}.")]
        public EUfEstado Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int IdFornecedor { get; set; }
    }
}
