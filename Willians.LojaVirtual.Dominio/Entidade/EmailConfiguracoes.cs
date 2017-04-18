using System.Net.Mail;

namespace Willians.LojaVirtual.Dominio.Entidade
{
    public class EmailConfiguracoes
    {
        public string Usuario = "williansfr@hotmail.com";

        public string Senha = "loading4";

        public bool UsarSsl = false;

        public string ServidorSmtp = "smtp.live.com";

        public int ServidorPorta = 587;

        public bool EscreverArquivo = false;

        public string PastaArquivos = @"d:\envioEmail";

        public string De = "williansfr@hotmail.com";

        public string Para = "williansfr@hotmail.com";
    }
}