using System;

namespace SocialMedia.App.Models.Contas
{
    public class UpdateContaInputModel
    {
        public UpdateContaInputModel(string? nomeCompleto, DateTime dataNascimento)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
        }

        public string? NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
