using System;

namespace SocialMedia.App.Models.Contas
{
    public class CreateContaInputModel
    {
        public CreateContaInputModel() { }
        public CreateContaInputModel(string nomeCompleto, string senha, string email, string telefone, DateTime dataNascimento)
        {
            NomeCompleto = nomeCompleto;
            Senha = senha;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
        }

        public  string NomeCompleto { get; set; }
        public  string Senha { get; set; }
        public  string Email { get; set; }
        public  string Telefone { get; set; }
        public  DateTime DataNascimento { get; set; }
    }
}
