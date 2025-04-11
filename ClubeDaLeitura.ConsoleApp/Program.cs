using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program : TelaPrincipal
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            TelaAmigo telaAmigo = new TelaAmigo();
            string opcao;

            do
            {
                Console.Clear();
                opcao = telaPrincipal.MenuPrincipal();

                switch (opcao)
                {
                    case "1":
                        telaAmigo.GerenciarAmigos();
                        break;

                    case "2":
                        // GerenciarCaixas
                        break;

                    case "3":
                        // GerenciarRevistas
                        break;

                    case "4":
                        // GerenciarEmpréstimos
                        break;

                    case "S":
                        Console.WriteLine("Saindo do sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }

            } while (opcao != "S");
            
            
        }
    }

}
