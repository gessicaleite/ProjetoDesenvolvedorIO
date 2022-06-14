using ProjetoDesenvolvedor.IO.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDesenvolvedor.IO.Data.Dtos.Produto
{
    public class CreateProdutoDto
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public double Valor { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, 2, ErrorMessage = "Favor selecionar entre as opções {1} ou {2}.")]
        public EAtivoInativo Situacao { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; }


        public string Imagem { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int IdFornecedor { get; set; }
    }
}
