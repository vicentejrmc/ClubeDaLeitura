using ClubeDaLeitura.ConsoleApp.Compatilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class ReposAmigoArquivo : ReposBaseArquivo<Amigo>, IRepositorioAmigo
    {
        protected override List<Amigo> ObterRegistros()
        {
            return new List<Amigo>();
        }
    }
}
