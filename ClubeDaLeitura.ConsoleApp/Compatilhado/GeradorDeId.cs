namespace ClubeDaLeitura.ConsoleApp.Compatilhado
{
    public class GeradorDeId
    {
        public static int idAmigo = 0;

        public static int GerarIdAmigo()
        {
            idAmigo++;

            return idAmigo;
        }

    }
}
