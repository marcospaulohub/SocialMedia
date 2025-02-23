using System;
using FluentValidation;
using SocialMedia.App.Models.Contas;
using SocialMedia.Core.Messages.ContaMessages;

namespace SocialMedia.App.Validators.ContaValidator
{
    public class UpdateContaInputModelValidator : AbstractValidator<UpdateContaInputModel>
    {
        public UpdateContaInputModelValidator()
        {
            RuleFor(c => c.NomeCompleto)
                .MaximumLength(150)
                    .WithMessage(ContaMsgs.GetNomeCompletoMaxLength());

            RuleFor(c => c.DataNascimento)
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage(ContaMsgs.GetDataNascimentoMinAge());
        }
    }
}
