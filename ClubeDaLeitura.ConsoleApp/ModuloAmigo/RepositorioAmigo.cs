using ClubeDaLeitura.ConsoleApp.Compatilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class RepositorioAmigo
{
    public Amigo Nome;
    public Amigo Responsavel;
    public Amigo Telefone;


    public Amigo[] vetorDeAmigos = new Amigo[100];
    public int contAmigos = 0;

    public void InserirNovoAmigo(Amigo novoAmigo)
    {
       novoAmigo.Id = GeradorDeId.GerarIdAmigo();

       vetorDeAmigos[contAmigos++] = novoAmigo;
    }

    public bool EditarAmigoCadastrado(int idAmigo, Amigo amigoEditado)
    {
        for (int i = 0; i < vetorDeAmigos.Length; i++)
        {
            if (vetorDeAmigos[i] != null) 
                continue;
            else if (vetorDeAmigos[i].Id == idAmigo)
            {
                vetorDeAmigos[i].Nome = amigoEditado.Nome;
                vetorDeAmigos[i].Responsavel = amigoEditado.Responsavel;
                vetorDeAmigos[i].Telefone = amigoEditado.Telefone;

                return true;
            }
        }
        return false;
    }

    public bool ExcluirAmigoCadastrado(int idAmigo)
    {
        for (int i = 0; i < vetorDeAmigos.Length; i++)
        {
            if (vetorDeAmigos[i] != null)
                continue;
            else if (vetorDeAmigos[i].Id == idAmigo)
            {
                vetorDeAmigos[i] = null;
                
                return true;
            }
        }
        return false;
    }

    public Amigo ObterAmigoPorId(int idAmigo)
    {
        for (int i = 0; i < vetorDeAmigos.Length; i++)
        {
            Amigo amigo = vetorDeAmigos[i];

            if (amigo == null) continue;

            else if (amigo.Id == idAmigo)
                return amigo;
        }

        return null;
    }

    public Amigo[] ObterTodosOsAmigos()
    {
        return vetorDeAmigos;
    }

    public void VisualizarAmigosCadastrados()
    {
        Console.WriteLine("Lista de Amigos Cadastrados:");
        Console.WriteLine("-----------------------------------------------------\n");
        for (int i = 0; i < vetorDeAmigos.Length; i++)
        {
            if (vetorDeAmigos[i] != null)
            {
                Console.WriteLine($"ID: {vetorDeAmigos[i].Id}, Nome: {vetorDeAmigos[i].Nome}, Responsável: {vetorDeAmigos[i].Responsavel}, Telefone: {vetorDeAmigos[i].Telefone}");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }
    }

}