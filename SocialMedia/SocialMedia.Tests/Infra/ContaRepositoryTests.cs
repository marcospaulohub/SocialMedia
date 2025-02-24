using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Repositories;

namespace SocialMedia.Tests.Infra
{
    public class ContaRepositoryTests
    {
        public readonly IContaRepository mockContasRepository;

        public ContaRepositoryTests()
        {
            IList<Conta> contas = new List<Conta>
            {
                new("Nome Completo 1", "senha1", "email1@email.com", "99 88888888", DateTime.Now.AddYears(-18)),
                new("Nome Completo 2", "senha2", "email2@email.com", "99 88888888", DateTime.Now.AddYears(-20))
            };

            Mock<IContaRepository> mockContaRepository = new Mock<IContaRepository>();

            // return a product by Email
            mockContaRepository.Setup(mr => mr.GetByEmail(
                It.IsAny<string>())).Returns((string s) => contas.Where(x => x.Email == s).SingleOrDefault());

            mockContaRepository.Setup(mr => mr.Insert(It.IsAny<Conta>())).Returns(
                (Conta target) =>
                {

                    if (target.Id.Equals(default(int)))
                    {
                        //target.Id = contas.Count() + 1;
                        contas.Add(target);
                    }
                    else
                    {
                        var original = contas.Where(q => q.Id == target.Id).Single();

                        if (original is null)
                        {
                            return 0;
                        }

                        original = new Conta(target.NomeCompleto, target.Senha, target.Email, target.Telefone, target.DataNascimento);
                    }
                    return 1;
                });

            this.mockContasRepository = mockContaRepository.Object;
        }

        [Fact]
        public void TestaGetByEmail()
        {
            //Arange + Act
            var testConta = this.mockContasRepository.GetByEmail("email1@email.com");

            //Assert
            Assert.NotNull(testConta);
        }

        [Fact]
        public void TestaInsert()
        {
            //Arange
            Conta novaConta = new Conta("Nome Completo 3", "senha3", "email3@email.com", "99 88888888", DateTime.Now.AddYears(-20));
            this.mockContasRepository.Insert(novaConta);

            //Act
            var testConta = mockContasRepository.GetByEmail("email3@email.com");

            //Assert
            Assert.NotNull(testConta);
            Assert.Equal(DateTime.Now.Date, mockContasRepository.GetByEmail("email3@email.com").CreatedAt.Date);
        }

        [Fact]
        public void TestaUpdateComNome_e_DataNascimento()
        {
            //Arange + 
            var conta = this.mockContasRepository.GetByEmail("email1@email.com");

            var novoNome = "Novo Nome Completo 1";
            var novaDataNascimento = DateTime.Now.AddYears(-30);

            conta.Update(novoNome, novaDataNascimento);

            //Act
            this.mockContasRepository.Update(conta);


            //Assert
            Assert.Equal(DateTime.Now.Date, mockContasRepository.GetByEmail("email1@email.com").CreatedAt.Date);
            Assert.Equal(novoNome, mockContasRepository.GetByEmail("email1@email.com").NomeCompleto);
            Assert.Equal(novaDataNascimento, mockContasRepository.GetByEmail("email1@email.com").DataNascimento);

        }

        [Fact]
        public void TestaUpdateComNome()
        {
            //Arange + 
            var conta = this.mockContasRepository.GetByEmail("email1@email.com");

            var novoNome = "Novo Nome Completo 1";
            var novaDataNascimento = default(DateTime);

            conta.Update(novoNome, novaDataNascimento);

            //Act
            this.mockContasRepository.Update(conta);


            //Assert
            Assert.Equal(DateTime.Now.Date, mockContasRepository.GetByEmail("email1@email.com").UpdatedAt.GetValueOrDefault().Date);
            Assert.Equal(novoNome, mockContasRepository.GetByEmail("email1@email.com").NomeCompleto);
            Assert.NotEqual(novaDataNascimento, mockContasRepository.GetByEmail("email1@email.com").DataNascimento);
        }

        [Fact]
        public void TestaUpdateComDataNascimento()
        {
            //Arange + 
            var conta = this.mockContasRepository.GetByEmail("email1@email.com");

            var novoNome = default(string);
            var novaDataNascimento = DateTime.Now.AddYears(-30);

            conta.Update(novoNome, novaDataNascimento);

            //Act
            this.mockContasRepository.Update(conta);


            //Assert
            Assert.Equal(DateTime.Now.Date, mockContasRepository.GetByEmail("email1@email.com").UpdatedAt.GetValueOrDefault().Date);
            Assert.Equal(novaDataNascimento, mockContasRepository.GetByEmail("email1@email.com").DataNascimento);
            Assert.NotEqual(novoNome, mockContasRepository.GetByEmail("email1@email.com").NomeCompleto);
        }

        [Fact]
        public void TestaMudarSenha()
        {
            //Arange + 
            var conta = this.mockContasRepository.GetByEmail("email1@email.com");

            var novoSenha = "novaSenha";

            conta.MudarSenha(novoSenha);

            //Act
            this.mockContasRepository.Update(conta);


            //Assert
            Assert.Equal(DateTime.Now.Date, mockContasRepository.GetByEmail("email1@email.com").UpdatedAt.GetValueOrDefault().Date);
            Assert.Equal(novoSenha, mockContasRepository.GetByEmail("email1@email.com").Senha);
        }

        [Fact]
        public void TestaDelete()
        {
            //Arange
            Conta conta = new Conta("Nome Completo 3", "senha3", "email3@email.com", "99 88888888", DateTime.Now.AddYears(-20));
            this.mockContasRepository.Delete(conta);

            //Act
            var testConta = mockContasRepository.GetByEmail("email3@email.com");

            //Assert
            Assert.Null(testConta);
        }
    }
}
