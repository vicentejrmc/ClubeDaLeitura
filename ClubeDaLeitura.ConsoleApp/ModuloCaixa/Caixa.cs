using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
using System.Data;
using System.Drawing;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa
    {
        public int IdCaixa;
        public string Etiqueta;
        public string CorCaixa;   /// Construtor precisa ser corrigo para passar uma cor
        public int DiasEmprestimo;

        public Caixa(string etiqueta, string corCaixa, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            CorCaixa = corCaixa;
            DiasEmprestimo = diasEmprestimo;
        }

        public string ValidarCaixa()
        {
            string caixaEhvalida = "";

            if (Etiqueta.Length > 50)
                caixaEhvalida += "!...A Etiqueda deve conter um texto de no maximo 50 caracteres sem espaços em branco...!";

            // Implementar Validaçoes para: Etiqueta Duplicada, Dias Emprestimo(caso esteja em brando/Usar ou Não, valor padrão)

            return caixaEhvalida;
        }


        public void AdicionarRevista(Revista novaRevista)
        {
            Revista revista = novaRevista;
        }


        public void RemoverRevista()
        {
            throw new NotImplementedException();
        }

       
    }
}
