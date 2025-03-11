namespace SocialMedia.Core.Messages.ContaMessages
{
    public static class ContaMsgs
    {
        private const string fileNameResx = "SocialMedia.Core.Messages.ContaMessages.ContaMsgsResource";

        public static string GetContaNotExist()
        {
            return BaseMsgs.GetResource("ContaNotExist", fileNameResx);
        }
        public static string GetContaExist()
        {
            return BaseMsgs.GetResource("ContaExist", fileNameResx);
        }

        public static string GetNomeCompletoNotEmpty()
        {
            return BaseMsgs.GetResource("ContaNomeCompletoNotEmpty", fileNameResx);
        }

        public static string GetNomeCompletoMaxLength()
        {
            return BaseMsgs.GetResource("ContaNomeCompletoMaxLength", fileNameResx);
        }

        public static string GetSenhaNotEmpty()
        {
            return BaseMsgs.GetResource("ContaSenhaNotEmpty", fileNameResx);
        }

        public static string GetSenhaMaxLength()
        {
            return BaseMsgs.GetResource("ContaSenhaMaxLength", fileNameResx);
        }
        public static string GetSenhaInvalid()
        {
            return BaseMsgs.GetResource("ContaSenhaInvalid", fileNameResx);
        }

        public static string GetEmailNotEmpty()
        {
            return BaseMsgs.GetResource("ContaEmailNotEmpty", fileNameResx);
        }

        public static string GetEmailMaxLength()
        {
            return BaseMsgs.GetResource("ContaEmailMaxLength", fileNameResx);
        }

        public static string GetEmailInvalid()
        {
            return BaseMsgs.GetResource("ContaEmailInvalid", fileNameResx);
        }
        
        public static string GetTelefoneNotEmpty()
        {
            return BaseMsgs.GetResource("ContaTelefoneNotEmpty", fileNameResx);
        }

        public static string GetTelefoneMaxLength()
        {
            return BaseMsgs.GetResource("ContaTelefoneMaxLength", fileNameResx);
        }

        public static string GetDataNascimentoNotEmpty()
        {
            return BaseMsgs.GetResource("ContaDataNascimentoNotEmpty", fileNameResx);
        }

        public static string GetDataNascimentoMinAge()
        {
            return BaseMsgs.GetResource("ContaDataNascimentoMinAge", fileNameResx);
        }
    }
}
