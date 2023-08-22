using System;

using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
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
