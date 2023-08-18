﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabb
{
    internal interface IUI
    {
        public string GetString();
        public void PutString(string value);
        public void Exit();

        public void Clear();

    }
}
