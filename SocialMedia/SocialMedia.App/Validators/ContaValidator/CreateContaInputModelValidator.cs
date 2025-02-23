using System;
using FluentValidation;
using SocialMedia.App.Models.Contas;
using SocialMedia.Core.Messages.ContaMessages;

namespace SocialMedia.App.Validators.ContaValidator
{
    public class CreateContaInputModelValidator : AbstractValidator<CreateContaInputModel>
    {
        public CreateContaInputModelValidator()
        {
            RuleFor(c => c.NomeCompleto)
                .NotEmpty()
                    .WithMessage(ContaMsgs.GetNomeCompletoNotEmpty())
                .MaximumLength(150)
                    .WithMessage(ContaMsgs.GetNomeCompletoMaxLength());

            RuleFor(c => c.Senha)
                .NotEmpty()
                    .WithMessage(ContaMsgs.GetSenhaNotEmpty())
                .MaximumLength(15)
                    .WithMessage(ContaMsgs.GetSenhaMaxLength());

            RuleFor(c => c.Email)
                .NotEmpty()
                    .WithMessage(ContaMsgs.GetEmailNotEmpty())
                .MaximumLength(150)
                    .WithMessage(ContaMsgs.GetEmailMaxLength())
                .EmailAddress()
                    .WithMessage(ContaMsgs.GetEmailInvalid());

            RuleFor(c => c.Telefone)
                .NotEmpty()
                    .WithMessage(ContaMsgs.GetTelefoneNotEmpty())
                .MaximumLength(20)
                    .WithMessage(ContaMsgs.GetTelefoneMaxLength());

            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                    .WithMessage(ContaMsgs.GetDataNascimentoNotEmpty())
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage(ContaMsgs.GetDataNascimentoMinAge());

        }
    }
}
