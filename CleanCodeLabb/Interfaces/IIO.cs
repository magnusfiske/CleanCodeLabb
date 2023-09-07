namespace CleanCodeLabb.Interfaces
{
    internal interface IIO
    {
        void SetGameForResults(string gameName);
        string GenerateTopList();
        void SaveResult(string playerName, int numberOfGuesses);
    }
}
