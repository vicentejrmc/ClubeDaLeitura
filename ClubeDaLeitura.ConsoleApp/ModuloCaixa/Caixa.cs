using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Util;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa : EntidadeBase<Caixa>
    {

        public string Etiqueta{ get; set; }
        public string Cor { get; init; }
        public int DiasEmprestimo { get; set; }

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
        }

        RepositorioCaixa repositorioCaixa;
        public Caixa(RepositorioCaixa repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
        }

        public override string Validar()
        {
            string errosValidacao = "";

            if (String.IsNullOrWhiteSpace(Etiqueta))
                errosValidacao += "Erro! A etiqueta não pode ser vazia, ou conter espaços em branco.\n";

            if (Etiqueta.Length < 3 || Etiqueta.Length > 50)
                errosValidacao += "Erro! A etiqueta deve ter entre 3 e 50 caracteres.\n";

            return errosValidacao;
        }

        public void AdicionarRevista(Revista revista)
        {
            throw new NotImplementedException();

        }
        public void RemoverRevista(Revista revista)
        {
            throw new NotImplementedException();
        }

        public override void AtualizarRegistro(Caixa resgitroEditado)
        {
            throw new NotImplementedException();
        }
    }
}