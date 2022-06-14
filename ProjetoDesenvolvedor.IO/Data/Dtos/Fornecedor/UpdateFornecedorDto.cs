using ProjetoDesenvolvedor.IO.Enum;

namespace ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor
{
    public class UpdateFornecedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Documento { get; set; }

        public EAtivoInativo Situacao { get; set; }

        public ETipoCliente TipoPessoa { get; set; }
    }
}
