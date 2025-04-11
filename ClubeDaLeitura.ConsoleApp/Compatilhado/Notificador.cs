namespace ClubeDaLeitura.ConsoleApp.Compatilhado
{
    internal class Notificador
    {
        public static void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void ExibirErros(string[] erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();

            for (int i = 0; i < erros.Length; i++)
                Console.WriteLine(erros[i]);

            Console.ResetColor();

            Console.Write("Pressione ENTER para tentar novamente...");
            Console.ReadLine();
        }
    }
}
