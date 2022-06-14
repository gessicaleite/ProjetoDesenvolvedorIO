using FluentValidation;
using ProjetoDesenvolvedor.IO.Entities;

namespace ProjetoDesenvolvedor.IO.Validation
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar em branco.");

            RuleFor(f => f.Documento)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar em branco.");

            RuleFor(f => f.Situacao)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar em branco.")
                .IsInEnum();

            RuleFor(f => f.TipoPessoa)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar em branco.")
                .IsInEnum();

        }
    }
}
