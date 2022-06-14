using FluentValidation;
using ProjetoDesenvolvedor.IO.Entities;

namespace ProjetoDesenvolvedor.IO.Validation
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar em branco.");

            RuleFor(p => p.Valor)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar em branco.");

            RuleFor(f => f.Situacao)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar em branco.")
                .IsInEnum();

            RuleFor(f => f.Imagem)
                .NotEmpty();
        }
    }
}
