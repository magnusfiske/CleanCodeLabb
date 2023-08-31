using CleanCodeLabb.Interfaces;

namespace CleanCodeLabb
{
    internal class ConsoleUI : IUI
    {
        public void Exit()
        {
            System.Environment.Exit(0);
        }

        public string GetString()
        {
            try
            {
                return Console.ReadLine();
            }
            catch(ArgumentNullException e) 
            { 
                throw e; 
            }
            

        }

        public void PutString(string value)
        {
           Console.WriteLine(value);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
