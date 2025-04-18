using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compatilhado
{
    public abstract class RepositorioBase
    {
        private EntidadeBase[] registros = new EntidadeBase[100];
        private int contadorIds = 0;

        private void InserirRegistro(EntidadeBase registro)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                {
                    registros[i] = registro;
                    return;
                }
            }
        }

        public void CadastrarRegistro(EntidadeBase novoRegistro)
        {
            novoRegistro.Id = ++contadorIds;

            InserirRegistro(novoRegistro);

        }

        public bool EditarRegistro(int idRegistro, EntidadeBase registroEditado)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null) continue;

                else if (registros[i].Id == idRegistro)
                {
                   registros[i].AtualizarRegistro(registroEditado);
                    return true;
                }
            }
            return false;
        }

        public bool ExcluirRegistro(int idRegistro)
        {
            for(int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null) continue;

                else if(registros[i].Id == idRegistro)
                {
                    registros[i] = null;
                    return true;
                }
            }
            return false;
        }

        public EntidadeBase SelecionarRegistroPorId(int idRegistro)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                EntidadeBase ent = registros[i];

                if (ent == null) continue;

                else if(ent.Id == idRegistro)
                    return ent;
            }
            return null;
        }

        public EntidadeBase[] SelecionarTodos()  // Método a ser usado pelos repositorios filhos ao pelo método Visualizar()
        {
            return registros;
        }


    }
}
