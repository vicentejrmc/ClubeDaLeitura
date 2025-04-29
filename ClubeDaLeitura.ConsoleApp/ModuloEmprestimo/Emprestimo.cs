using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo : EntidadeBase<Emprestimo>
    {
        public ReposEmprestimoMemoria repositorioEmprestimo;

        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public string Situacao { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double Multa { get; set; }

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
            Emprestimo emprestimoAtualizado = (Emprestimo)registroAtualizado;

            Amigo = emprestimoAtualizado.Amigo;
            Revista = emprestimoAtualizado.Revista;
            DataEmprestimo = emprestimoAtualizado.DataEmprestimo;
            Situacao = emprestimoAtualizado.Situacao;
            DataDevolucao = emprestimoAtualizado.DataDevolucao;
        }

        public override string Validar()
        {
            string errosValidacao = "";

            if (Revista.StatusEmprestimo.Equals("Reservada"))
                errosValidacao += "Erro! Não é possível realizar o empréstimo, pois a revista está reservada.\n";

            if (Revista.StatusEmprestimo.Equals("Emprestada"))
                errosValidacao += "Erro! Não é possível realizar o empréstimo, pois a revista já está emprestada.\n";

            if (Amigo.status.Equals("Bloqueado"))
                errosValidacao += "Erro! Não é possível realizar o empréstimo. O amigo está Inativo ou com Multa Pentende.\n";

            if (Amigo.Multa > 0)
                errosValidacao += "Erro! Não é possível realizar o empréstimo. O amigo está Inativo ou com Multa Pentende.\n";

            return errosValidacao;
        }

        public void RegistrarDevolucao()
        {
            foreach (var emprestimo in repositorioEmprestimo.SelecionarTodos())
            {
                if (emprestimo.Revista.Id == this.Revista.Id)
                {
                    emprestimo.Situacao = "Concluído";
                    emprestimo.DataDevolucao = DateTime.Now;
                    break;
                }
            }
        }

        public void ObterMulta(Emprestimo emprestimoSelecionado)
        {
            int diasAtraso = (int)(DateTime.Now - emprestimoSelecionado.DataDevolucao).TotalDays;
            double valorMulta = 2;   // 2 reais por dia de atraso
            double valorTotal = diasAtraso * valorMulta;

            emprestimoSelecionado.Multa = valorTotal;
        }
    }
}
