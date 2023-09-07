namespace CleanCodeLabb.Interfaces
{
    public interface IIoService
    {
        List<Player> GetAllResults();
        void Save(string playerName, int numberOfGuesses);
        void SetResultTable(string gameName);
    }
}
