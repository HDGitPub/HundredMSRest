﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundredMSRest.Lib.Interfaces
{
    internal interface ITokenProvider
    {
        IToken GenerateToken();
    }
}
