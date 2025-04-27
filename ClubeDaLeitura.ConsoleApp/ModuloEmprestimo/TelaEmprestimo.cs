using ClubeDaLeitura.ConsoleApp.Compatilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class TelaEmprestimo : TelaBase<Emprestimo>, ItelaCrud
    {
        public RepositorioEmprestimo repositorioEmprestimo;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo) : base("Empréstimo", repositorioEmprestimo)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
        }

        public override Emprestimo ObterDados()
        {
            throw new NotImplementedException();
        }

        public override void VisualizarRegistros()
        {
            throw new NotImplementedException();
        }
    }
}