using FluentValidation;
using ProjetoDesenvolvedor.IO.Entities;

namespace ProjetoDesenvolvedor.IO.Validation
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(e => e.Rua)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar em branco.");

            RuleFor(e => e.Numero)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar em branco.");

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar em branco.");

            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar em branco.")
                .IsInEnum();
        }
    }
}
