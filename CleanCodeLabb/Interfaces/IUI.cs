﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb.Interfaces
{
    internal interface IUI
    {
        string GetString();
        void PutString(string value);
        void Exit();
        void Clear();

    }
}