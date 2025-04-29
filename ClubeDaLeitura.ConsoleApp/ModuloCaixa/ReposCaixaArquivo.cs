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
        public ReposCaixaArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Caixa> ObterRegistros()
        {
           return contexto.Caixas;
        }
    }
}
