namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program : TelaPrincipal
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            string opcao = telaPrincipal.MenuPrincipal();


            Console.ReadLine();
        }
    }

}
