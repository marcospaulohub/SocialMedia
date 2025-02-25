using System;
using NSubstitute;
using SocialMedia.App.Models.Contas;
using SocialMedia.App.Services.Contas;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Repositories;

namespace SocialMedia.Tests.App
{
    public class ContaServiceTests
    {
        [Fact]
        public void Insert_ContaIsOk_Success()
        {
            // Arrange
            var createContaInputModel = new CreateContaInputModel
            {
                NomeCompleto = "Nome Completo",
                Senha = "senha",
                Email = "email@email.com.br",
                Telefone = "88 88888888",
                DataNascimento = DateTime.Now.AddYears(-18)
            };

            var repository = Substitute.For<IContaRepository>();

            repository
                .Insert(Arg.Any<Conta>())
                .Returns(1);

            var service = new ContaService(repository);

            // Act
            var result = service.Insert(createContaInputModel);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.Data);

            repository.ReceivedWithAnyArgs().Insert(default);

            repository.Received(1).Insert(Arg.Is<Conta>(
                c => c.NomeCompleto == createContaInputModel.NomeCompleto &&
                c.Email == createContaInputModel.Email));
        }

       
    }
}

