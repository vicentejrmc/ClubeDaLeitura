using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.Util;
using System.Collections;
using System.Collections.Generic;


namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCaixa : TelaBase<Caixa>, ITelaCrud
    {
        public IRepositorioCaixa repositorioCaixa;
        public TelaCaixa(IRepositorioCaixa repositorioCaixa) : base("Caixa", repositorioCaixa)
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

            return novaCaixa;
        }

        public string PaletaCor()
        {
            Console.WriteLine("Escolha uma cor para a caixa:");

            Notificar.ExibirCores("[1] Azul", ConsoleColor.Blue);
            Notificar.ExibirCores("[2] Verde", ConsoleColor.Green);
            Notificar.ExibirCores("[3] Vermelho", ConsoleColor.Red);
            Notificar.ExibirCores("[4] Amarelo", ConsoleColor.Yellow);
            Notificar.ExibirCores("[5] Ciano", ConsoleColor.Cyan);
            Notificar.ExibirCores("[6] Cinza", ConsoleColor.Gray);
            Notificar.ExibirCores("[7] Magenta", ConsoleColor.Magenta);
            Notificar.ExibirCores("[8] Vermelho-Escuro", ConsoleColor.DarkRed);
            Notificar.ExibirCores("[9] Branco", ConsoleColor.White);

            Console.WriteLine("------------------------------------------");


            Console.Write("Escolha uma opção válida: ");
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

        public override void InserirRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Cadastrando Caixa.");
            Console.WriteLine("------------------------------------------\n");

            Caixa novaCaixa = (Caixa)ObterDados();

            string ehValido = novaCaixa.Validar();

            if (ehValido.Length > 0)
            {
                Notificar.ExibirMensagem(ehValido, ConsoleColor.Red);
                InserirRegistro();
                return;
            }

            foreach (Caixa caixa in repositorioCaixa.SelecionarTodos())
            {
                if (caixa.Etiqueta.Equals(novaCaixa.Etiqueta))
                {
                    Notificar.ExibirMensagem("Erro! Já existe uma caixa cadastrada com a mesma etiqueta.", ConsoleColor.Red);
                    return;
                }
            }

            repositorioCaixa.CadastrarRegistro(novaCaixa);

            Notificar.ExibirMensagem($"Cadastro de {nomeEntidade} realizado com sucesso!", ConsoleColor.Green);
        }

        public override void VisualizarRegistros()
        {
            ExibirCabecalho();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Visualizando Caixas.");
            Console.WriteLine("------------------------------------------\n");

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -15} | {4, -10}", "ID", "Etiqueta", "Cor da Caixa", "Dias Emprestimo", "Qtd. Revistas");

            if (repositorioCaixa.SelecionarTodos().Count == 0)
            {
                Notificar.ExibirMensagem("Não há caixas cadastradas!", ConsoleColor.Red);
                return;
            }

            List<Caixa> registros = repositorioCaixa.SelecionarTodos();

            foreach (var caixa in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -15} | {4, -10}",
                    caixa.Id, caixa.Etiqueta, caixa.Cor, caixa.DiasEmprestimo, caixa.QtdRevistas);
            }

            Console.WriteLine();
            Notificar.ExibirMensagem("Pressione [Enter] para continuar", ConsoleColor.Yellow);

        }

        public override void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Editando Caixa.");
            Console.WriteLine("------------------------------------------\n");

            VisualizarRegistros();

            Console.Write("Digite o ID da Caixa que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine()!);

            Caixa caixaSelecionado = (Caixa)repositorioCaixa.SelecionarRegistroPorId(id);

            Caixa caixaEditada = (Caixa)ObterDados();

            string ehValido = caixaEditada.Validar();

            if (ehValido.Length > 0)
            {
                Notificar.ExibirMensagem(ehValido, ConsoleColor.Red);

                return;
            }

            bool conseguiuEditar = repositorioCaixa.EditarRegistro(id, caixaEditada);

            if (!conseguiuEditar)
            {
                Notificar.ExibirMensagem($"Erro! Não foi possível editar a Caixa com ID {id}.", ConsoleColor.Red);

                return;
            }

            Notificar.ExibirMensagem("Caixa Editada com Sucesso!", ConsoleColor.Green);


        }

        public override void ExcluirRegistro()
        {
            ExibirCabecalho();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Excluindo Caixa.");
            Console.WriteLine("------------------------------------------\n");

            if (repositorioCaixa.SelecionarTodos().Count == 0)
            {
                Notificar.ExibirMensagem("Não há caixas cadastradas para excluir.", ConsoleColor.Red);
                return;
            }

            VisualizarRegistros();

            Console.Write("Digite o ID da Caixa que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine()!);

            Caixa caixaSelecionada = (Caixa)repositorioCaixa.SelecionarRegistroPorId(id);

            if (caixaSelecionada.QtdRevistas > 0)
            {
                Notificar.ExibirMensagem("Erro! Não é possível excluir uma caixa que contém revistas.", ConsoleColor.Red);
                return;
            }

            bool conseguiuExcluir = repositorioCaixa.ExcluirRegistro(id);

            if (!conseguiuExcluir)
            {
                Notificar.ExibirMensagem($"Erro! Não foi possível excluir a Caixa com ID {id}.", ConsoleColor.Red);
                return;
            }

            Notificar.ExibirMensagem($"Caixa {caixaSelecionada.Etiqueta} excluída com sucesso!", ConsoleColor.Green);
        }
    }
}
