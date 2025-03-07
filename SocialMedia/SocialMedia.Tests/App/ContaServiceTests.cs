using NSubstitute;
using SocialMedia.App.Services.Contas;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Messages.ContaMessages;
using SocialMedia.Core.Repositories;
using SocialMedia.Tests.Fakes;

namespace SocialMedia.Tests.App
{
    public class ContaServiceTests
    {
        [Fact]
        public void Insert_ContaIsOk_Success()
        {
            // Arrange
            var createContaInputModel = FakeDataHelper.CreateContaInputModelFaker();

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

        [Fact]
        public void Update_ContaIsOk_Success()
        {
            // Arrange
            var conta = FakeDataHelper.CreateFakerConta();
            var updateContaInputModel = FakeDataHelper.UpdateContaInputModelFaker();

            var repository = Substitute.For<IContaRepository>();

            repository
               .GetById(1)
               .Returns(conta);

            var service = new ContaService(repository);

            // Act
            var result = service.Update(1, updateContaInputModel);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(conta.NomeCompleto, updateContaInputModel.NomeCompleto);
            Assert.Equal(conta.DataNascimento, updateContaInputModel.DataNascimento);

        }

        [Fact]
        public void GetById_Exists_Success()
        {
            // Arrange
            var conta = FakeDataHelper.CreateFakerConta();
            var repository = Substitute.For<IContaRepository>();

            repository
                .GetById(1)
                .Returns(conta);

            // Act
            var result = new ContaService(repository).GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.IsSuccess);
            Assert.Equal(conta.Id, result.Data.Id);

            repository.Received(1).GetById(1);
        }

        [Fact]
        public void GetByEmail_Exists_Success()
        {
            // Arrange
            var conta = FakeDataHelper.CreateFakerConta();
            var repository = Substitute.For<IContaRepository>();

            repository
                .GetByEmail(conta.Email)
                .Returns(conta);

            // Act
            var result = new ContaService(repository).GetByEmail(conta.Email);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.True(result.IsSuccess);
            Assert.Equal(conta.Id, result.Data.Id);

            repository.Received(1).GetByEmail(conta.Email);
        }

        [Fact]
        public void Login_Ok_Success()
        {
            // Arrange
            var conta = FakeDataHelper.CreateFakerConta();
            var repository = Substitute.For<IContaRepository>();

            repository
                .GetByEmail(conta.Email)
                .Returns(conta);

            // Act
            var result = new ContaService(repository).Login(conta.Email,conta.Senha);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);

            repository.Received(1).GetByEmail(conta.Email);
        }

        [Fact]
        public void Login_Senha_Error()
        {
            // Arrange
            var conta = FakeDataHelper.CreateFakerConta();
            var repository = Substitute.For<IContaRepository>();

            repository
                .GetByEmail(conta.Email)
                .Returns(conta);

            // Act
            var result = new ContaService(repository).Login(conta.Email, conta.Senha + "erro");

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Equal(result.Message, ContaMsgs.GetSenhaInvalid());
        }

        [Fact]
        public void Login_Email_Error()
        {
            // Arrange
            var conta = FakeDataHelper.CreateFakerConta();
            var repository = Substitute.For<IContaRepository>();

            repository
                .GetByEmail(conta.Email + "erro")
                .Returns(conta);

            // Act
            var result = new ContaService(repository).Login(conta.Email, conta.Senha);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Equal(result.Message, ContaMsgs.GetContaNotExist());
        }

    }
}

