namespace SocialMedia.Core.Entities
{
    public class Perfil : BaseEntity
    {
        public int IdConta { get; private set; }
        public Conta Conta { get; private set; }
        public string NomeExibicao { get; private set; }
        public string Sobre { get; private set; }
        public string Foto { get; private set; }
        public string Localidade { get; private set; }
        public string Profissao { get; private set; }

        public Perfil()
        {
            
        }

        public Perfil(int idConta, Conta conta, string nomeExibicao, string sobre, string foto, string localidade, string profissao) : base()
        {
            IdConta = idConta;
            Conta = conta;
            NomeExibicao = nomeExibicao;
            Sobre = sobre;
            Foto = foto;
            Localidade = localidade;
            Profissao = profissao;
        }

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
