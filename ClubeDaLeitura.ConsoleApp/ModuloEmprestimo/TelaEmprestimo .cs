using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo
{
    public RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();


    public RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
    public TelaRevista telaRevista = new TelaRevista();
    public RepositorioRevista repoRevista = new RepositorioRevista();

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("|              Clube da Leitura                     |");
        Console.WriteLine("-----------------------------------------------------\n");
    }

    public void GerenciarEmprestimo()
    {
        ExibirCabecalho();

        Console.WriteLine("1 - Registrar novo Empréstimo: ");
        Console.WriteLine("2 - Registrar devolução:");
        Console.WriteLine("3 - Visualizar Empréstimos"); //abertos e fechados
        Console.WriteLine("-----------------------------------------------------");

        Console.Write("Escolha uma opção válida: ");
        string opcao = Console.ReadLine()!;

        switch (opcao)
        {
            case "1":
                Inserir();
                break;
            case "2":
                Editar();
                break;

            case "3":
                VisualizarTodos();
                break;
            default:
                return;
        }

    }
    public void Inserir()
    {
        ExibirCabecalho();

        Console.WriteLine("Registrando Emprestimo...");
        Console.WriteLine("-----------------------------------------------------\n");

        repositorioAmigo.VisualizarAmigosCadastrados();

        Console.Write("Selecione o Id do Amigo / Obter o Emprestimo: ");
        int idAmigo = Convert.ToInt32(Console.ReadLine());
        Amigo amigoEmp = repositorioAmigo.ObterAmigoPorId(idAmigo);
        Console.WriteLine();

        telaRevista.VisualizarRevistas();
        Console.Write("Selecione o Id da Revista: ");
        int idRevista = Convert.ToInt32(Console.ReadLine());
        
        Revista revistaEmp = repoRevista.SelecionarPorId(idRevista);
        revistaEmp.EmprestarRevista(idRevista);

        Emprestimo novoEmprestimo = new Emprestimo(revistaEmp, "Emprestada", DateTime.Now, amigoEmp);

        repositorioEmprestimo.Inserir(novoEmprestimo);

        NotificarCor.ExibirMensagem($"Revista {revistaEmp} emprestada para {amigoEmp.Nome}", ConsoleColor.Yellow);

        Console.ReadLine();

    }
    public void Editar() { }
    public void Excluir() { }
    public void VisualizarTodos() // Visualizar Emprestimos
    {
    
    }
    public void RegistrarDevolucao()// abertos e fechados
    { }
}
