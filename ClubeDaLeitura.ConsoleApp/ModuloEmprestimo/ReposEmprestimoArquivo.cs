using ClubeDaLeitura.ConsoleApp.Compatilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class ReposEmprestimoArquivo : ReposBaseArquivo<Emprestimo>, IRepositorioEmprestimo
    {
        protected override List<Emprestimo> ObterRegistros()
        {
            return new List<Emprestimo>();
        }
    }

}
