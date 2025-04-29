namespace ClubeDaLeitura.ConsoleApp.Compatilhado;

public interface ITelaCrud
{
    void InserirRegistro();
    void VisualizarRegistros();
    void EditarRegistro();
    void ExcluirRegistro();
    char ApresentarMenu();
}
