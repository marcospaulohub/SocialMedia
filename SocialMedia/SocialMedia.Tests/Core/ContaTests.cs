using System;
using SocialMedia.Core.Entities;
using SocialMedia.Tests.Fakes.Contas;

namespace SocialMedia.Tests.Core
{
    public class ContaTests
    {
        [Fact]
        public void CriaContaComDadosOk_Sucesso()
        {
            // Arrange
            var nomeCompleto = "Nome Completo";
            var senha = "senha";
            var email = "email@email.com";
            var telefone = "8888888888";
            var dataNascimento = DateTime.Now.AddYears(-18);

            // Act
            var conta = new Conta(nomeCompleto, senha, email, telefone, dataNascimento);

            // Assert
            Assert.NotNull(conta);
            Assert.Equal(nomeCompleto, conta.NomeCompleto);
            Assert.Equal(senha, conta.Senha);
            Assert.Equal(email, conta.Email);
            Assert.Equal(telefone, conta.Telefone);
            Assert.Equal(dataNascimento, conta.DataNascimento);
            Assert.True(DateTime.Now.Date == conta.CreatedAt.Date);
        }

        [Fact]
        public void UpdateComDadosOk_Sucesso()
        {
            // Arrange
            var conta = new ContaFake().Generate();

            var novoNomeCompleto = "Novo Nome Completo";
            var novoDataNascimento = DateTime.Now.AddYears(-20);

            // Act
            conta.Update(novoNomeCompleto, novoDataNascimento);
            conta.SetAsUpdated();

            // Assert
            Assert.Equal(novoNomeCompleto, conta.NomeCompleto);
            Assert.Equal(novoDataNascimento, conta.DataNascimento);
            Assert.True(DateTime.Now.Date == conta.UpdatedAt.GetValueOrDefault().Date);

        }

        [Fact]
        public void MudarSenhaComDadosOk_Sucesso()
        {
            // Arrange
            var conta = new ContaFake().Generate();
            var novaSenha = "novaSenha";

            // Act
            conta.MudarSenha(novaSenha);
            conta.SetAsUpdated();

            // Assert
            Assert.Equal(novaSenha, conta.Senha);
            Assert.True(DateTime.Now.Date == conta.UpdatedAt.GetValueOrDefault().Date);
        }

        [Fact]
        public void DeleteContaOk_Sucesso()
        {
            // Arrange
            var conta = new ContaFake().Generate();

            // Act
            conta.SetAsDeleted();

            // Assert
            Assert.True(DateTime.Now.Date == conta.DeletedAt.GetValueOrDefault().Date);
        }
    }
}
