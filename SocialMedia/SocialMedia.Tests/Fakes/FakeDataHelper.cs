using System;
using Bogus;
using SocialMedia.App.Models.Contas;
using SocialMedia.Core.Entities;

namespace SocialMedia.Tests.Fakes
{
    public class FakeDataHelper
    {
        public static Conta CreateFakerConta() => _contaFaker.Generate();

        #region _contaFaker
        private static readonly Faker<Conta> _contaFaker = new Faker<Conta>()
            .RuleFor(c => c.Id, f => f.Random.Int(1, 1000))
            .RuleFor(c => c.NomeCompleto, f => f.Name.FullName())
            .RuleFor(c => c.Senha, f => f.Internet.Password(10))
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.DataNascimento, DateTime.Now.AddYears(-20));
        #endregion

        public static CreateContaInputModel CreateContaInputModelFaker() => _createContaInputModel.Generate();

        #region _createContaInputModel
        private static readonly Faker<CreateContaInputModel> _createContaInputModel = new Faker<CreateContaInputModel>()
            .RuleFor(c => c.NomeCompleto, f => f.Name.FullName())
            .RuleFor(c => c.Senha, f => f.Internet.Password(10))
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.DataNascimento, DateTime.Now.AddYears(-20));
        #endregion

        public static UpdateContaInputModel UpdateContaInputModelFaker() => _updateContaInputModelFake.Generate();

        #region _updateContaInputModelFake
        private static readonly Faker<UpdateContaInputModel> _updateContaInputModelFake = new Faker<UpdateContaInputModel>()
            .RuleFor(c => c.NomeCompleto, f => f.Name.FullName())
            .RuleFor(c => c.DataNascimento, DateTime.Now.AddYears(-20));
        #endregion
    }
}
