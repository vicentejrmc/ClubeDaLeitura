using ClubeDaLeitura.ConsoleApp.Compatilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class ReposCaixaArquivo : ReposBaseArquivo<Caixa>, IRepositorioCaixa
    {

        protected override List<Caixa> ObterRegistros()
        {
           return new List<Caixa>();
        }
    }
}
