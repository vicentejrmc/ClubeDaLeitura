using ClubeDaLeitura.ConsoleApp.Compatilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaAmigo : TelaBase
    {
        public RepositorioAmigo repositorioAmigo;

        public TelaAmigo(RepositorioBase repositorio) 
            : base("Amigo", repositorio)
        {
            this.repositorioAmigo = (RepositorioAmigo?)repositorio;
        }

        public override EntidadeBase ObterDados()
        {
            throw new NotImplementedException();
        }

        public override void VisualizarRegistros(bool e)
        {
            throw new NotImplementedException();
        }
    }
}
