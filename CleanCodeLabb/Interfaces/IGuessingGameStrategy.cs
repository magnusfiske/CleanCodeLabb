using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb.Interfaces
{
    public interface IGuessingGameStrategy
    {
        int NumberOfUniqueDigitsInObjective { get; }
        bool IsValidNumber(string randomDigit, string gameObjective);
        string CheckGameResult(string gameObjective, string guess);
    }
}
