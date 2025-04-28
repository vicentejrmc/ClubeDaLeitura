using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo : EntidadeBase<Emprestimo>
    {
        public RepositorioEmprestimo repositorioEmprestimo;

        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public string Situacao { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo, string situacao, DateTime dataDevolucao)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = dataEmprestimo;
            Situacao = situacao;
            DataDevolucao = dataDevolucao;
        }

        public override void AtualizarRegistro(Emprestimo registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string Validar()
        {
            string errosValidacao = "";

            if (Revista.StatusEmprestimo.Equals("Reservada"))
                errosValidacao += "Erro! Não é possível realizar o empréstimo, pois a revista está reservada.\n";

            foreach (var emprestimo in repositorioEmprestimo.SelecionarTodos())
            {
                if (emprestimo.Revista.Id == this.Revista.Id)
                    errosValidacao += "Erro! Não é possível realizar o empréstimo, pois a revista já está emprestada.\n";

                if (emprestimo.Amigo.Id == this.Amigo.Id)
                    errosValidacao += "Erro! Não é possível realizar o empréstimo, pois o amigo já possui uma revista emprestada.\n";
            }

            return errosValidacao;
        }
        
        public void RegistrarDevolucao()
        {
           
        }
    } 
}
