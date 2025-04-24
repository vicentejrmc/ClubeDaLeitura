using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.Util;
using System.Collections;
using System.Collections.Generic;


namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCaixa : TelaBase<Caixa>, ItelaCrud
    {
        public RepositorioCaixa repositorioCaixa;
        public TelaCaixa(RepositorioCaixa repositorioCaixa) : base("Caixa", repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
        }


        public override Caixa ObterDados()
        {
            Console.Write("Insira o nome da Etiqueta (Sem espaços em branco): ");
            string etiqueta = Console.ReadLine().Trim(' ');

            string cor = PaletaCor();

            Console.Write("Insira o número de dias para empréstimo: ");
            int diasEmprestimo = Convert.ToInt32(Console.ReadLine());

            Caixa novaCaixa = new Caixa(etiqueta, cor, diasEmprestimo);

            foreach (var caixa in repositorioCaixa.SelecionarTodos())
            {
                if (caixa.Etiqueta.Equals(etiqueta))
                {
                    Notificar.ExibirMensagem("Erro! Já existe uma caixa cadastrada com a mesma etiqueta.", ConsoleColor.Red);

                    return null;
                }
            }

            return novaCaixa;

        }

        public string PaletaCor()
        {
            Console.WriteLine("Escolha uma cor para a caixa:");

            Notificar.ExibirMensagem("[1] Azul", ConsoleColor.Blue);
            Notificar.ExibirMensagem("[2] Verde", ConsoleColor.Green);
            Notificar.ExibirMensagem("[3] Vermelho", ConsoleColor.Red);
            Notificar.ExibirMensagem("[4] Amarelo", ConsoleColor.Yellow);
            Notificar.ExibirMensagem("[5] Ciano", ConsoleColor.Cyan);
            Notificar.ExibirMensagem("[6] Cinza", ConsoleColor.Gray);
            Notificar.ExibirMensagem("[7] Magenta", ConsoleColor.Magenta);
            Notificar.ExibirMensagem("[8] Preto", ConsoleColor.Black);
            Notificar.ExibirMensagem("[9] Branco", ConsoleColor.White);

            int opcao = Convert.ToInt32(Console.ReadLine());

            string corEscolhida = "";
            switch (opcao)
            {
                case 1:
                    corEscolhida = "Azul";
                    break;
                case 2:
                    corEscolhida = "Verde";
                    break;
                case 3:
                    corEscolhida = "Vermelho";
                    break;
                case 4:
                    corEscolhida = "Amarelo";
                    break;
                case 5:
                    corEscolhida = "Ciano";
                    break;
                case 6:
                    corEscolhida = "Cinza";
                    break;
                case 7:
                    corEscolhida = "Magenta";
                    break;
                case 8:
                    corEscolhida = "Preto";
                    break;
                case 9:
                    corEscolhida = "Branco";
                    break;
                default:
                    Notificar.ExibirMensagem("Opção inválida!", ConsoleColor.Red);
                    break;
            }

            return corEscolhida;
        }

        public override void VisualizarRegistros()
        {
            ExibirCabecalho();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Visualizando Caixas.");
            Console.WriteLine("------------------------------------------\n");

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -15}", "ID", "Etiqueta", "Cor da Caixa", "Dias Emprestimo");

            List<Caixa> registros = repositorioCaixa.SelecionarTodos();

            foreach (var caixa in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -15}",
                    caixa.Id, caixa.Etiqueta, caixa.Cor, caixa.DiasEmprestimo);
            }

            Console.WriteLine();
            Notificar.ExibirMensagem("Pressione entera para continuar", ConsoleColor.Yellow);

        }
    }
}
