namespace CleanCodeLabb.Interfaces
{
    internal interface IDAO
    {
        List<Player> ReadAll();
        void Save(string playerName, int numberOfGuesses);
        void SetResultTable(string gameName);
    }
}
