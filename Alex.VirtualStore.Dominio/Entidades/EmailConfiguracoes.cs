namespace Alex.VirtualStore.Dominio.Entidades
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = false;
        public string ServidorSmtp = "smtp.gmail.com.br";
        public int ServidorPorta = 587;
        public string Usuario = "carvalho220980";
        public bool EscreverArquivo = false;
        public string PastaArquivo = @"c:\envioemail";
        public string De = "carvalho220980@gmail.com";
        public string Para = "carvalho2209@hotmail.com";
    }
}
