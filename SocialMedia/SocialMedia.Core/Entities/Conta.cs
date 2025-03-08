using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities
{
    public class Conta : BaseEntity
    {
        public Conta() { }
        public Conta(string nomeCompleto, string senha, string email, string telefone, DateTime dataNascimento)
            : base()
        {
            NomeCompleto = nomeCompleto;
            Senha = senha;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;

            Perfis = [];
        }

        public string NomeCompleto { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public List<Perfil> Perfis { get; private set; }

        public void Update(string? nomeCompleto, DateTime dataNascimento)
        {
            if(dataNascimento != default)
                DataNascimento = dataNascimento;

            if(nomeCompleto != default)
                NomeCompleto = nomeCompleto;

            SetAsUpdated();
        }

        public void MudarSenha(string novaSenha)
        {
            Senha = novaSenha;

            SetAsUpdated();
        }
    }
}
