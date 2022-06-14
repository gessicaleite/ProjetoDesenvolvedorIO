using ProjetoDesenvolvedor.IO.Enum;

namespace ProjetoDesenvolvedor.IO.Data.Dtos.Endereco
{
    public class UpdateEnderecoDto
    {
        public int Id { get; set; }
        public string Rua { get; set; }

        public int Numero { get; set; }

        public string Cidade { get; set; }

        public EUfEstado Estado { get; set; }

    }
}
