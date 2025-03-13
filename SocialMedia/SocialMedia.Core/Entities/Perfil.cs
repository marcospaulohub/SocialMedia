namespace SocialMedia.Core.Entities
{
    public class Perfil(int idConta, Conta conta, string nomeExibicao, string sobre, string foto, string localidade, string profissao) : BaseEntity()
    {
        public int IdConta { get; private set; } = idConta;
        public Conta Conta { get; private set; } = conta;
        public string NomeExibicao { get; private set; } = nomeExibicao;
        public string Sobre { get; private set; } = sobre;
        public string Foto { get; private set; } = foto;
        public string Localidade { get; private set; } = localidade;
        public string Profissao { get; private set; } = profissao;

        public void Update(string nomeExibicao, string sobre, string foto, string localidade, string profissao)
        {
            NomeExibicao = nomeExibicao;
            Sobre = sobre;
            Foto = foto;
            Localidade = localidade;
            Profissao = profissao;
        }
    }
}
