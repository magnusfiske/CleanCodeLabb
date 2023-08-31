namespace CleanCodeLabb.Interfaces
{
    internal interface IGame
    {
        bool HasStrategyOptions { get; }
        int NumberOfGuesses { get; }
        string GetStrategy();
        string GetStrategyOptions();
        void SetStrategy(int userInput);
        string NewGame();
        string ValidateUserInput(string input);
        string CheckResult(string guess);
        bool IsWin();
        string CreateWinMessage();
        string Cheat();
    }
}
