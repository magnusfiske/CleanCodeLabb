namespace CleanCodeLabb.Interfaces
{
    public interface IIoService
    {
        List<Player> ReadAll();
        void Save(string playerName, int numberOfGuesses);
        void SetResultTable(string gameName);
    }
}
