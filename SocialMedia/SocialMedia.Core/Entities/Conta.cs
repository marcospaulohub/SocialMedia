using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities
{
    public class Conta(string nomeCompleto, string senha, string email, string telefone, DateTime dataNascimento) : BaseEntity()
    {
        public string NomeCompleto { get; private set; } = nomeCompleto;
        public string Senha { get; private set; } = senha;
        public string Email { get; private set; } = email;
        public string Telefone { get; private set; } = telefone;
        public DateTime DataNascimento { get; private set; } = dataNascimento;
        public List<Perfil> Perfis { get; private set; } = [];

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
