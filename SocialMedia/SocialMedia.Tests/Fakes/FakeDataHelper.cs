using System;
using Bogus;
using SocialMedia.App.Models.Contas;
using SocialMedia.Core.Entities;

namespace SocialMedia.Tests.Fakes
{
    public class FakeDataHelper
    {
        private static readonly Faker _faker = new();

        #region _contaFaker
        public static Conta CreateFakerConta()
        {
            return new Conta(
                _faker.Name.FullName(),
                _faker.Internet.Password(10),
                _faker.Internet.Email(),
                _faker.Phone.PhoneNumber(),
                DateTime.Now.AddYears(-20)
             );

        }

        public static Conta CreateFakerContaV2() => _contaFaker.Generate();

        private static readonly Faker<Conta> _contaFaker = new Faker<Conta>()
            .RuleFor(c => c.Id, f => f.Random.Int(1, 1000))
            .RuleFor(c => c.NomeCompleto, f => f.Name.FullName())
            .RuleFor(c => c.Senha, f => f.Internet.Password(10))
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.DataNascimento, DateTime.Now.AddYears(-20));

        #endregion

        #region _createContaInputModel
        public static CreateContaInputModel CreateContaInputModelFaker()
        {
            return new CreateContaInputModel(
                _faker.Name.FullName(),
                _faker.Internet.Password(10),
                _faker.Internet.Email(),
                _faker.Phone.PhoneNumber(),
                DateTime.Now.AddYears(-20)
            );
        }

        public static CreateContaInputModel CreateContaInputModelFakerV2() => _createContaInputModel.Generate();
        
        private static readonly Faker<CreateContaInputModel> _createContaInputModel = new Faker<CreateContaInputModel>()
            .RuleFor(c => c.NomeCompleto, f => f.Name.FullName())
            .RuleFor(c => c.Senha, f => f.Internet.Password(10))
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.DataNascimento, DateTime.Now.AddYears(-20));

        #endregion

        #region _updateContaInputModelFake
        public static UpdateContaInputModel UpdateContaInputModelFaker()
        {
            return new UpdateContaInputModel(
                _faker.Name.FullName(),
                DateTime.Now.AddYears(-20)
            );
        }

        public static UpdateContaInputModel UpdateContaInputModelFakerV2() => _updateContaInputModelFake.Generate();

        private static readonly Faker<UpdateContaInputModel> _updateContaInputModelFake = new Faker<UpdateContaInputModel>()
            .RuleFor(c => c.NomeCompleto, f => f.Name.FullName())
            .RuleFor(c => c.DataNascimento, DateTime.Now.AddYears(-20));
        
        #endregion
    }
}
