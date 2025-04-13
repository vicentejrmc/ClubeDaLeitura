namespace ClubeDaLeitura.ConsoleApp.Compatilhado
{
    public class GeradorDeId
    {
        public static int IdAmigo = - 1;
        public static int IdCaixa = - 1;
        public static int IdRevista = - 1;

        public static int GerarIdAmigo()
        {
            IdAmigo++;

            return IdAmigo;
        }

        public static int GerarIdCaixa()
        {
            IdCaixa++;

            return IdCaixa;
        }

        public static int GerarIdRevista()
        {
            IdRevista++;

            return IdRevista;
        }

    }
}
