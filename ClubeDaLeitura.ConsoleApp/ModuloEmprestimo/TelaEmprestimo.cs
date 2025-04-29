using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Util;
using System.Reflection.Metadata;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class TelaEmprestimo : TelaBase<Emprestimo>, ItelaCrud
    {
        public RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioRevista repositorioRevista;
        public RepositorioAmigo repositorioAmigo;
        public RepositorioCaixa repositorioCaixa;
        public Emprestimo emprestimo;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioRevista repositorioRevista, RepositorioAmigo repositorioAmigo,
            RepositorioCaixa repositorioCaixa) : base("Empréstimo", repositorioEmprestimo)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioRevista = repositorioRevista;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioCaixa = repositorioCaixa;
        }

        public override char ApresentarMenu()
        {
            Console.Clear();
            ExibirCabecalho();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"[1] Cadastrar Emprestimo");
            Console.WriteLine($"[2] Visualizar Emprestimos");
            Console.WriteLine($"[3] Editar Emprestimo");
            Console.WriteLine($"[4] Excluir Emprestimo");
            Console.WriteLine($"[5] Registrar Devolução");

            Console.WriteLine($"[S] Sair...");
            Console.WriteLine("------------------------------------------");

            Console.Write("Escolha uma opção válida: ");
            char opcao = Convert.ToChar(Console.ReadLine()!.ToUpper());

            if(opcao == '5')
                RegistrarDevolucao();

            return opcao;
        }
    
        public override void InserirRegistro()
        {
            ExibirCabecalho();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Cadastrando Empréstimo.");
            Console.WriteLine("------------------------------------------\n");

            if (repositorioRevista.SelecionarTodos().Count == 0)
            {
                Notificar.ExibirMensagem("Não há Revistas cadastradas!", ConsoleColor.Red);
                return;
            }

            if (repositorioAmigo.SelecionarTodos().Count == 0)
            {
                Notificar.ExibirMensagem("Não há amigos cadastrados!", ConsoleColor.Red);
                return;
            }

            Emprestimo novoEmprestimo = ObterDados();

            string ehValido = novoEmprestimo.Validar();

            if (ehValido.Length > 0)
            {
                Notificar.ExibirMensagem(ehValido, ConsoleColor.Red);
                return;
            }

            foreach (var amigo in repositorioEmprestimo.SelecionarTodos())
            {
                if (amigo.Amigo.Nome.Equals(novoEmprestimo.Amigo.Nome))
                {
                    Notificar.ExibirMensagem("Erro! Já existe um amigo cadastrado com o mesmo Nome.", ConsoleColor.Red);
                    return;
                }
            }

            Revista revistaEmprestada = novoEmprestimo.Revista;
            revistaEmprestada.Emprestar(novoEmprestimo.Revista);

            repositorioEmprestimo.CadastrarRegistro(novoEmprestimo);


            Notificar.ExibirMensagem($"Empréstimo cadastrado com sucesso!", ConsoleColor.Green);
        }

        public override Emprestimo ObterDados()
        {
            TelaAmigo verAmigos = new TelaAmigo(repositorioAmigo);
            verAmigos.VisualizarRegistros();

            Console.Write("Selecione o ID do Amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine()!);
            Amigo amigoSelecionado = repositorioAmigo.SelecionarRegistroPorId(idAmigo);

            TelaRevista verRevistas = new TelaRevista(repositorioRevista, repositorioCaixa);
            verRevistas.VisualizarRegistros();

            Console.Write("Selecione o Id da Revista: ");
            int idRevista = Convert.ToInt32(Console.ReadLine()!);
            Revista revistaSelecionada = repositorioRevista.SelecionarRegistroPorId(idRevista);

            DateTime dataEmprestimo = DateTime.Now;

            int diasEmprestimo = revistaSelecionada.Caixa.DiasEmprestimo;

            DateTime devolucaoEmprestimo = DateTime.Now.AddDays(diasEmprestimo);

            Emprestimo novoEmprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada, dataEmprestimo, "Aberto", devolucaoEmprestimo);

            return novoEmprestimo;
        }

        public override void VisualizarRegistros()
        {
            ExibirCabecalho();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Visualizando Emprestimos.");
            Console.WriteLine("------------------------------------------\n");

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, -15}", "ID", "Revista", "Amigo", "Data Emprestimo", "Data Devolução", "Situação");

            if (repositorioEmprestimo.SelecionarTodos().Count == 0)
            {
                Notificar.ExibirMensagem("Não há empréstimos cadastrados!", ConsoleColor.Red);
                return;
            }

            List<Emprestimo> registros = repositorioEmprestimo.SelecionarTodos();

            foreach (Emprestimo emp in registros)
            {
                if (DateTime.Now > emp.DataDevolucao)
                {
                    emp.Situacao = "Atrasado";
                }

                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, -15}",
                    emp.Id, emp.Revista.Titulo, emp.Amigo.Nome, emp.DataEmprestimo.ToString("dd/MM/yyyy"), emp.DataDevolucao.ToString("dd/MM/yyyy"), emp.Situacao
                    );
            }

            Console.WriteLine();
            Notificar.ExibirMensagem("Pressione [Enter] para continuar", ConsoleColor.Yellow);
        }

        public void VisualizarRevistasEmprestadas()
        {
            // Adicionar Id na visualização

            ExibirCabecalho();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Visualizando Emprestimos.");
            Console.WriteLine("------------------------------------------\n");

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -10} | {4, -10} | {5, -15}","ID", "Revista", "Amigo", "Data Emprestimo", "Data Devolução", "Situação");

            if (repositorioEmprestimo.SelecionarTodos().Count == 0)
            {
                Notificar.ExibirMensagem("Não há empréstimos cadastrados!", ConsoleColor.Red);
                return;
            }

            List<Emprestimo> registros = repositorioEmprestimo.SelecionarTodos();

            foreach (Emprestimo emp in registros)
            {
                if (DateTime.Now > emp.DataDevolucao)
                {
                    emp.Situacao = "Atrasado";
                }

                if (emp.Revista.StatusEmprestimo.Equals("Emprestada") || emp.Situacao.Equals("Atrasado"))
                {
                    Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -10} | {4, -10} | {5, -15}",
                        emp.Id, emp.Revista.Titulo, emp.Amigo.Nome, emp.DataEmprestimo.ToString("dd/MM/yyyy"), emp.DataDevolucao.ToString("dd/MM/yyyy"), emp.Situacao
                        );
                }
            }

            Console.WriteLine();
        }

        public  void RegistrarDevolucao()
        {
            ExibirCabecalho();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Registrar Devolução.");
            Console.WriteLine("------------------------------------------\n");

            if (repositorioEmprestimo.SelecionarTodos().Count == 0)
            {
                Notificar.ExibirMensagem("Não há empréstimos cadastrados!", ConsoleColor.Red);
                return;
            }

            VisualizarRevistasEmprestadas();

            Console.Write("Digite o ID do Empréstimo que deseja registrar a devolução: ");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine()!);

            Emprestimo emprestimoSelecionado = repositorioEmprestimo.SelecionarRegistroPorId(idEmprestimo);

            if (emprestimoSelecionado == null)
            {
                Notificar.ExibirMensagem("Empréstimo não encontrado!", ConsoleColor.Red);
                return;
            }

            if (emprestimoSelecionado.Situacao.Equals("Fechado"))
            {
                Notificar.ExibirMensagem("Esse empréstimo já foi devolvido!", ConsoleColor.Red);
                return;
            }

            #region Verifica se o emprestimo está em atrazo ou se tem multa pendente
            if (DateTime.Now > emprestimoSelecionado.DataDevolucao)
            {
                Emprestimo emprestimo = emprestimoSelecionado;
                emprestimo.ObterMulta(emprestimoSelecionado);

                Notificar.ExibirCores("\nEsse empréstimo está atrasado!", ConsoleColor.Red);
                Notificar.ExibirCores($"Multa: R$ {emprestimo.Multa}", ConsoleColor.Red);

                Console.WriteLine();

                Notificar.ExibirCores("Você precisa Pagar a multa para realizar à devolução!", ConsoleColor.Yellow);
                Notificar.ExibirCores("Caso contrario não poderá realizar Novos Emprestimos!", ConsoleColor.Yellow);

                Console.Write("Deseja pagar a multa agora? S/N: ");
                char opcao = Convert.ToChar(Console.ReadLine()!.ToUpper());

                if (opcao == 'S')
                {
                    PagarMulta(emprestimo);
                }
                else if (opcao == 'N')
                {
                    Console.WriteLine("Deseja prosseguir com a Devolução? S/N");
                    char opcaoDevolucao = Convert.ToChar(Console.ReadLine()!.ToUpper());

                    if (opcaoDevolucao == 'N')
                    {
                        Notificar.ExibirMensagem("Devolução cancelada pelo usuário.", ConsoleColor.Yellow);
                        return;
                    }
                    else if (opcaoDevolucao == 'S')
                    {
                        emprestimoSelecionado.Amigo.status = "Bloqueado";
                        emprestimoSelecionado.Amigo.Multa = emprestimo.Multa;
                        Notificar.ExibirCores("Você não poderá fazer novos emprestimos até pagar a multa atual.!", ConsoleColor.Red);
                    }
                }
            }
            #endregion

            emprestimoSelecionado.RegistrarDevolucao();

            Revista revistaDevolvida = emprestimoSelecionado.Revista;
            revistaDevolvida.Devolver(emprestimoSelecionado.Revista);

            Notificar.ExibirMensagem($"Devolução registrada com sucesso!", ConsoleColor.Green);
        }

        public override void EditarRegistro()
        {
            ExibirCabecalho();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Editando Empréstimo.");
            Console.WriteLine("------------------------------------------\n");

            if (repositorioEmprestimo.SelecionarTodos().Count == 0)
            {
                Notificar.ExibirMensagem("Não há empréstimos cadastrados!", ConsoleColor.Red);
                return;
            }

            VisualizarRegistros();

            Console.Write("Digite o ID do Empréstimo que deseja editar: ");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine()!);

            Emprestimo emprestimoSelecionado = repositorioEmprestimo.SelecionarRegistroPorId(idEmprestimo);

            if (emprestimoSelecionado == null)
            {
                Notificar.ExibirMensagem("Empréstimo não encontrado!", ConsoleColor.Red);
                return;
            }

            Emprestimo emprestimoEditado = ObterDados();

            bool conseguiuEditar = repositorioEmprestimo.EditarRegistro(idEmprestimo, emprestimoEditado);
            if (!conseguiuEditar)
            {
                Notificar.ExibirMensagem($"Erro! Não foi possível editar o Empréstimo com ID {idEmprestimo}.", ConsoleColor.Red);
                return;
            }

            Notificar.ExibirMensagem($"Empréstimo editado com sucesso!", ConsoleColor.Green);
        }

        public override void ExcluirRegistro()
        {
            ExibirCabecalho();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Excluindo Empréstimo.");
            Console.WriteLine("------------------------------------------\n");

            if (repositorioEmprestimo.SelecionarTodos().Count == 0)
            {
                Notificar.ExibirMensagem("Não há empréstimos cadastrados!", ConsoleColor.Red);
                return;

            }

            VisualizarRegistros();

            Console.Write("Digite o ID do Empréstimo que deseja excluir: ");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine()!);

            Emprestimo emprestimoSelecionado = repositorioEmprestimo.SelecionarRegistroPorId(idEmprestimo);

            if (emprestimoSelecionado == null)
            {
                Notificar.ExibirMensagem("Empréstimo não encontrado!", ConsoleColor.Red);
                return;
            }

            if (emprestimoSelecionado.Situacao.Equals("Aberto"))
            {
                Notificar.ExibirMensagem("Esse empréstimo não pode ser excluído, pois está aberto!", ConsoleColor.Red);
                return;
            }

            bool conseguiuExcluir = repositorioEmprestimo.ExcluirRegistro(idEmprestimo);

            if (!conseguiuExcluir)
            {
                Notificar.ExibirMensagem($"Erro! Não foi possível excluir o Empréstimo com ID {idEmprestimo}.", ConsoleColor.Red);
                return;
            }

            Notificar.ExibirMensagem($"Empréstimo excluído com sucesso!", ConsoleColor.Green);
        }

        public void PagarMulta(Emprestimo emprestimoSelecionado)
        {
            ExibirCabecalho();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Pagamento de Multa.");
            Console.WriteLine("------------------------------------------\n");

            double valorMulta = emprestimoSelecionado.Multa;
            Console.WriteLine($"Valor da Multa: R$ {valorMulta}");

            Console.Write("Digite o valor pago: ");
            double valorPago = Convert.ToDouble(Console.ReadLine());

            if (valorPago < valorMulta)
            {
                Notificar.ExibirMensagem("Valor pago é menor que o valor da multa!", ConsoleColor.Red);
                return;
            }

            if (valorPago >= valorMulta)
            {
                double troco = valorPago - valorMulta;

                Notificar.ExibirMensagem($"Troco = {troco.ToString("F2")}", ConsoleColor.Yellow);
            }

            emprestimoSelecionado.Amigo.Multa = 0;
            emprestimoSelecionado.Amigo.status = "Ativo";

            Notificar.ExibirMensagem("Multa paga com sucesso!", ConsoleColor.Green);
        }
    }
}