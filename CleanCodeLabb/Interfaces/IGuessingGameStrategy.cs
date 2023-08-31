namespace CleanCodeLabb.Interfaces
{
    public interface IGuessingGameStrategy
    {
        int NumberOfUniqueDigitsInObjective { get; }
        bool IsValidNumber(string randomDigit, string gameObjective);
        string CheckGameResult(string gameObjective, string guess);
    }
}
