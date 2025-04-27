using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo : EntidadeBase<Emprestimo>
    {
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public string Situacao { get; set; }

        public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo, string situacao)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = dataEmprestimo;
            Situacao = situacao;
        }

        public override void AtualizarRegistro(Emprestimo registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    } 
}
