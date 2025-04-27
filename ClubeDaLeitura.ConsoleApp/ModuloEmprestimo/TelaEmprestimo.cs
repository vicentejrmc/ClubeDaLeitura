using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Util;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class TelaEmprestimo : TelaBase<Emprestimo>, ItelaCrud
    {
        public RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioRevista repositorioRevista;
        public RepositorioAmigo repositorioAmigo;
        public RepositorioCaixa repositorioCaixa;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioRevista repositorioRevista, RepositorioAmigo repositorioAmigo)
            : base("Empréstimo", repositorioEmprestimo)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioRevista = repositorioRevista;
            this.repositorioAmigo = repositorioAmigo;
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

            //Fazer Validações Classe Amigo

            DateTime dataEmprestimo = DateTime.Now;
            Console.WriteLine($"A data do Emprestimo é: {dataEmprestimo}");

            Revista emprestarRevista = repositorioRevista.SelecionarRegistroPorId(idRevista);

            string statusEmprestimo = emprestarRevista.StatusEmprestimo;

            if (emprestarRevista.StatusEmprestimo.Equals(statusEmprestimo))
            {
                Notificar.ExibirMensagem("Erro! Não é possível realizar o empréstimo, pois a revista está emprestada.", ConsoleColor.Red);

                return null;
            }


            Emprestimo emprestimo = new Emprestimo(amigoSelecionado, emprestarRevista, dataEmprestimo, "Emprestada" );

            return emprestimo;
        }

        public override void VisualizarRegistros()
        {
            throw new NotImplementedException();
        }




        //Inserir(), Editar(), Excluir(),
        //VisualizarTodos() // Ver todas as revistas e seu status
        //VisualizarRevistas(),
        //VisualizarAmigos(),
        //RegistrarDevolucao()

    }
}