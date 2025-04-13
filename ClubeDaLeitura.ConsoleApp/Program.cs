using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program : TelaPrincipal
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            TelaAmigo telaAmigo = new TelaAmigo();
            TelaCaixa telaCaixa = new TelaCaixa();
            TelaRevistas telaRevistas = new TelaRevistas();

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
                        telaCaixa.GerenciarCaixas();
                        break;

                    case "3":
                        telaRevistas.GerenciarRevistas();
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
