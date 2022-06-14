using ProjetoDesenvolvedor.IO.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor
{
    public class CreateFornecedorDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Favor utilizar somente letras.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Documento { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório.")]
        //[Range(1, 2, ErrorMessage = "Favor selecionar entre as opções {1} ou {2}.")]
        public EAtivoInativo Situacao { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório.")]
        //[Range(1, 2, ErrorMessage = "Favor selecionar entre as opções {1} ou {2}.")]
        public ETipoCliente TipoPessoa { get; set; }
    }
}
