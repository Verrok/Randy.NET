using System;
using System.Collections.Generic;
using System.Text;

namespace Randy.Enums
{
    [Flags]
    public enum CharSet
    {
        Lower = 1,
        Upper = 2,
        Digits = 4,
        Symbols = 8,
        Alphabet = Lower | Upper,
        AlphaNumeric = Alphabet | Digits,
        All = AlphaNumeric | Symbols
    }
}
